using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Vinynvest.Infra.CrossCutting
{
    public class ApiClient
    {
        private readonly HttpClient _client;

        public ApiClient(string url)
        {
            _client = new HttpClient { BaseAddress = new Uri(url) };
        }

        public async Task<T> Get<T>(string method)
        {
            HttpResponseMessage responseMessage;

            responseMessage = await _client.GetAsync(method);

            if (!responseMessage.IsSuccessStatusCode)
                throw new WebException($"The following error occurred: {JsonConvert.DeserializeObject<string>(responseMessage.Content.ReadAsStringAsync().Result)}");

            return JsonConvert.DeserializeObject<T>(await responseMessage.Content.ReadAsStringAsync());
        }
    }
}
