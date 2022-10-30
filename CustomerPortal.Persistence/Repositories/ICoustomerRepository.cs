using CustomerPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPortal.Persistence.Repositories
{
    public interface ICoustomerRepository
    {
        Task<CustomerEntity> GetCoustomerByIdQuery(Guid? id);
        Task<CustomerEntity> DeleteCoustomerByIdCommand(CustomerEntity customerEntity);
        Task<CustomerEntity> UpdateCoustomerByIdCommand(CustomerEntity customerEntity);
        Task<CustomerEntity> CreateNewCoustomerCommand(CustomerEntity customerEntity);
        Task<PagedList<CustomerEntity>> GetAllCoustomersQuery(QueryStringParameters queryString);
    }
}
