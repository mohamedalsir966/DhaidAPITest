using Inspector.Domain.Entities;
using Inspector.Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Persistence.Repositories
{
    public class InspectorServiceRepository : IInspectorServiceRepository
    {
        private readonly ApplicationDbContext _context;
        private ISortHelper<InspectorEntity> _sortHelper;
        public InspectorServiceRepository(ApplicationDbContext context, ISortHelper<InspectorEntity> sortHelper)
        {
            _context = context;
            _sortHelper = sortHelper;
        }
        public async Task<InspectorEntity> CreateNewInspectorCommand(InspectorEntity inspector)
        {
            _context.Inspector.Add(inspector);
            await _context.SaveChangesAsync();
            return inspector;
        }

        public async Task<PagedList<InspectorEntity>> GetAllInspectorQuery(QueryStringParameters queryParams)
        {
            var query = _context.Inspector.Where(x=>x.IsDeleted==false).AsQueryable();
            query = _sortHelper.ApplySort(query, queryParams.OrderBy, queryParams.order.ToString());
            if (!string.IsNullOrWhiteSpace(queryParams.Search))
                query = query.Where(x => x.Name.ToLower().Contains(queryParams.Search.ToLower()));

            return await PagedList<InspectorEntity>.ToPagedList(query, queryParams.PageNumber, queryParams.PageSize);
        }
        public async Task<InspectorEntity> GetInspectorByIdQuery(Guid? id)
        {
            var inspector = await _context.Inspector.Where(x => x.Id == id && x.IsDeleted==false).FirstOrDefaultAsync();
            return inspector;
        }
      
        public async Task<InspectorEntity> DeleteInspectorByIdCommand(InspectorEntity inspector)
        {
            inspector.IsDeleted = true;
            await _context.SaveChangesAsync();
            return inspector;
        }
        public async Task<InspectorEntity> UpdateInspectorByIdCommand(InspectorEntity existinginspector)
        {
            await _context.SaveChangesAsync();
            return existinginspector;
        }
    }
}
