using CustomerPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPortal.Persistence.Repositories
{
    public class CoustomerRepository : ICoustomerRepository
    {
        private readonly ApplicationDbContext _context;
        private ISortHelper<CustomerEntity> _sortHelper;
        public CoustomerRepository(ApplicationDbContext context, ISortHelper<CustomerEntity> sortHelper)
        {
            _context = context;
            _sortHelper = sortHelper;
        }

        public async Task<CustomerEntity> CreateNewCoustomerCommand(CustomerEntity customerEntity)
        {
            _context.Customer.Add(customerEntity);
            await _context.SaveChangesAsync();
            return customerEntity;
        }

        public async Task<CustomerEntity> DeleteCoustomerByIdCommand(CustomerEntity customerEntity)
        {
            customerEntity.IsDeleted = true;
            await _context.SaveChangesAsync();
            return customerEntity;
        }

        public async Task<PagedList<CustomerEntity>> GetAllCoustomersQuery(QueryStringParameters queryParams)
        {
            var query = _context.Customer.Where(x => x.IsDeleted == false).AsQueryable();
            query = _sortHelper.ApplySort(query, queryParams.OrderBy, queryParams.order.ToString());
            if (!string.IsNullOrWhiteSpace(queryParams.Search))
                query = query.Where(x => x.Name.ToLower().Contains(queryParams.Search.ToLower()));

            return await PagedList<CustomerEntity>.ToPagedList(query, queryParams.PageNumber, queryParams.PageSize);
        }


        public async Task<CustomerEntity> GetCoustomerByIdQuery(Guid? id)
        {
            var customer = await _context.Customer.Where(a => a.IsDeleted == false && a.Id == id).FirstOrDefaultAsync();
            return customer;
        }

        public async Task<CustomerEntity> UpdateCoustomerByIdCommand(CustomerEntity customerEntity)
        {
            await _context.SaveChangesAsync();
            return customerEntity;
        }
    }
}
