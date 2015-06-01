using System;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace CarPool
{
    public class HttpClient
    {
        private readonly string _baseAddress;
        private System.Net.Http.HttpClient _httpClient;

        public HttpClient(string baseAddress)
        {
            _baseAddress = baseAddress;
        }

        public T GetAsync<T>(string uri)
        {
            _httpClient = new System.Net.Http.HttpClient { BaseAddress = new Uri(_baseAddress) };

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));

            var response = _httpClient.GetAsync(uri).Result;

            response.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
        }
    }
}