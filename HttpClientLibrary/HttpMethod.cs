using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Http.Lib {

    public class HttpMethod {

        private readonly HttpClient httpClient;
        private JsonSerializerOptions jsonSerializerOptions;

        public HttpMethod() {
            httpClient = new HttpClient();
            jsonSerializerOptions = new JsonSerializerOptions() {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public void AddHeader(string headerName, string headerValue) {
            httpClient.DefaultRequestHeaders.Add(headerName, headerValue);
        }

        public async Task Get(string url) {
            var httpMessageResponse = await httpClient.GetAsync(url);
            var httpContent = await httpMessageResponse.Content.ReadAsStringAsync();
            var users = JsonSerializer.Deserialize<User[]>(httpContent, jsonSerializerOptions);
        }
        //public async Task Post() {

        //}
        //public async Task Put() {

        //}
        //public async Task Delete() {

        //}
    }
}

