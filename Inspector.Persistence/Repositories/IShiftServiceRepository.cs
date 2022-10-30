using Inspector.Domain.Entities;
using Inspector.Domain.Helpers;
using System;
using System.Threading.Tasks;

namespace Inspector.Persistence.Repositories
{
    public interface IShiftServiceRepository
    {
        Task<ShiftEntity> CreateNewShiftCommand(ShiftEntity shift);
        Task<PagedList<ShiftEntity>> GetAllShiftQuery(QueryStringParameters shift);
        Task<ShiftEntity> GetShiftByIdQuery(Guid? id);
        Task<ShiftEntity> DeleteShitByIdCommand(ShiftEntity shift);
        Task<ShiftEntity> UpdatShiftByIdCommand(ShiftEntity shift);
        
    }
}
