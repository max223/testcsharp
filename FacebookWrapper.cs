using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace AREA
{
    public class FacebookWrapper
    {
        private readonly HttpClient _httpClient;

        public FacebookWrapper()
        {
            _httpClient = new HttpClient
            {
               BaseAddress = new Uri("https://graph.facebook.com/v2.11/")
            };
            _httpClient.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> GetAsync<T>(string accessToken, string endpoint, string args = null)
        {
            var response = await _httpClient.GetAsync($"{endpoint}?access_token={accessToken}&{args}");
            if (!response.IsSuccessStatusCode)
                return default(T);

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(result);
        }

        public async Task PostAsync(string accessToken, string endpoint, object data, string args = null) //sa arrive meme pas dans cette fonction
        {
            var payload = GetPayload(data);
            //string myrequest = "/api/users/";
          string myrequest = $"{endpoint}?access_token={accessToken}&{args}";
           var response =  await _httpClient.PostAsync(myrequest, payload);
            if (!response.IsSuccessStatusCode)
                return ;
            var a = 12;
            var b = response.StatusCode;
            var c = 0;
        }

        private static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);

            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}