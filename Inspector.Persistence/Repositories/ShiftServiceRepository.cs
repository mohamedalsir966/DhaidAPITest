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
    public class ShiftServiceRepository : IShiftServiceRepository
    {
        private readonly ApplicationDbContext _context;
        private ISortHelper<ShiftEntity> _sortHelper;
        public ShiftServiceRepository(ApplicationDbContext context, ISortHelper<ShiftEntity> sortHelper)
        {
            _context = context;
            _sortHelper = sortHelper;
        }
        public async Task<ShiftEntity> CreateNewShiftCommand(ShiftEntity shift)
        {
            _context.Shift.Add(shift);
            await _context.SaveChangesAsync();
            return shift;
        }

        public async Task<PagedList<ShiftEntity>> GetAllShiftQuery(QueryStringParameters queryParams)
        {
            var query = _context.Shift.Where(x=>x.IsDeleted==false).AsQueryable();
            query = _sortHelper.ApplySort(query, queryParams.OrderBy, queryParams.order.ToString());
            if (!string.IsNullOrWhiteSpace(queryParams.Search))
                query = query.Where(x => x.Name.ToLower().Contains(queryParams.Search.ToLower()));

            return await PagedList<ShiftEntity>.ToPagedList(query, queryParams.PageNumber, queryParams.PageSize);
        }
        public async Task<ShiftEntity> GetShiftByIdQuery(Guid? id)
        {
            var shiftService = await _context.Shift.Where(x => x.Id == id && x.IsDeleted==false).FirstOrDefaultAsync();
            return shiftService;
        }
      
        public async Task<ShiftEntity> DeleteShitByIdCommand(ShiftEntity shift)
        {
            shift.IsDeleted = true;
            await _context.SaveChangesAsync();
            return shift;
        }
        public async Task<ShiftEntity> UpdatShiftByIdCommand(ShiftEntity shift)
        {
            await _context.SaveChangesAsync();
            return shift;
        }
    }
}
