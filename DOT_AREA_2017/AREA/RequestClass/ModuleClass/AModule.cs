using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace AREA
{
    public abstract class AModule
    {
        abstract public Task<T> GetAsync<T>(RequestParam _params);
        abstract public Task PostAsync(RequestParam _params);

        public HttpClient _httpClient;

        protected AModule(string base_adress)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(base_adress)
            };
            _httpClient.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}