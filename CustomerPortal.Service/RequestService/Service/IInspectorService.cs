using CustomerPortal.Domain.Entities;
using Service.Dto.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPortal.Service.RequestService.Service
{
    public interface IInspectorService
    {
        Task<PagedResponse<List<InspectorShiftEntityResponse>>> GetRequstServiceAsync(QueryStringParameters queryStringParameters);
    }
}
