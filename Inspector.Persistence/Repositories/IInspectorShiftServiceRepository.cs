using Inspector.Domain.Entities;
using Inspector.Domain.Helpers;
using System;
using System.Threading.Tasks;

namespace Inspector.Persistence.Repositories
{
    public interface IInspectorShiftServiceRepository
    {
        Task<InspectorShiftEntity> CreateInspectorShiftCommand(InspectorShiftEntity inspectorShiftEntity);
        Task<PagedList<InspectorShiftEntity>> GetAllInspectorShiftQuery(QueryStringParameters inspectorShiftEntity);

        
    }
}
