using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AREA
{
    public class FacebookModule : AModule
    {
        public FacebookModule() : base("https://graph.facebook.com/v2.11/")
        {
        }

        public async override Task<T> GetAsync<T>(RequestParam myParams)
        {
            FacebookParameters rightParams = myParams as FacebookParameters;
            var response = await _httpClient.GetAsync($"{rightParams.endpoint}?access_token={rightParams.accessToken}&{rightParams.args}");
            if (!response.IsSuccessStatusCode)
                return default(T);

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(result);
        }

        public async override Task PostAsync(RequestParam myParams)
        {
            FacebookParameters rightParams = myParams as FacebookParameters;
            var payload = GetPayload(rightParams.data);
            string myrequest = $"{rightParams.endpoint}?access_token={rightParams.accessToken}&{rightParams.args}";
            var response = await _httpClient.PostAsync(myrequest, payload);
            if (!response.IsSuccessStatusCode)
                return;
        }

        private  static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);

            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}