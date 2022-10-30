using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Service.Dto.Common;
using System.Collections.Generic;
using CustomerPortal.Domain.Entities;

namespace CustomerPortal.Service.RequestService.Service
{
    public class InspectorService : IInspectorService
    {
        private readonly HttpClient _httpClient;
        public InspectorService(IOptions<InspectorServiceOptions> options)
        {
            var handler = new HttpClientHandler();
            this._httpClient = new(handler)
            {
                BaseAddress = new Uri(options.Value.BaseUri)
            };
        }
        public async Task<PagedResponse<List<InspectorShiftEntityResponse>>> GetRequstServiceAsync(QueryStringParameters queryStringParameters)
        {
            var request = await _httpClient.GetAsync($"InspectorShift?={ queryStringParameters }");
            request.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeObject<PagedResponse<List<InspectorShiftEntityResponse>>>(await request.Content.ReadAsStringAsync())!;

            return result;
        }
    }
}
