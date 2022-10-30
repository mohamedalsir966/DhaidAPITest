using Inspector.Domain.Entities;
using Inspector.Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Persistence.Repositories
{
    public class InspectorShiftServiceRepository : IInspectorShiftServiceRepository
    {
        private readonly ApplicationDbContext _context;
        private ISortHelper<InspectorShiftEntity> _sortHelper;
        public InspectorShiftServiceRepository(ApplicationDbContext context, ISortHelper<InspectorShiftEntity> sortHelper)
        {
            _context = context;
            _sortHelper = sortHelper;
        }
        public async Task<InspectorShiftEntity> CreateInspectorShiftCommand(InspectorShiftEntity inspectorShiftEntity)
        {
            _context.InspectorShif.Add(inspectorShiftEntity);
            await _context.SaveChangesAsync();
            return inspectorShiftEntity;
        }

      
        public async Task<PagedList<InspectorShiftEntity>> GetAllInspectorShiftQuery(QueryStringParameters queryParams)
        {
            var query = _context.InspectorShif.Include(x=>x.InspectorEntity).Include(x=>x.ShiftEntity).Where(x => x.IsDeleted == false).AsQueryable();
            query = _sortHelper.ApplySort(query, queryParams.OrderBy, queryParams.order.ToString());
            if (!string.IsNullOrWhiteSpace(queryParams.Search))
                query = query.Where(x => x.InspectorEntity.Name.ToLower().Contains(queryParams.Search.ToLower()));

            return await PagedList<InspectorShiftEntity>.ToPagedList(query, queryParams.PageNumber, queryParams.PageSize);
        }



    }
}
