using Inspector.Domain.Entities;
using Inspector.Domain.Helpers;
using System;
using System.Threading.Tasks;

namespace Inspector.Persistence.Repositories
{
    public interface IInspectorServiceRepository
    {
        Task<InspectorEntity> CreateNewInspectorCommand(InspectorEntity inspector);
        Task<PagedList<InspectorEntity>> GetAllInspectorQuery(QueryStringParameters inspector);
        Task<InspectorEntity> GetInspectorByIdQuery(Guid? id);
        Task<InspectorEntity> DeleteInspectorByIdCommand(InspectorEntity inspector);
        Task<InspectorEntity> UpdateInspectorByIdCommand(InspectorEntity inspector);
        
    }
}
