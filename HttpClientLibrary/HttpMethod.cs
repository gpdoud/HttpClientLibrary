using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using static System.Net.WebRequestMethods;

namespace Http.Lib {

    public class HttpMethod {

        private readonly HttpClient httpClient;
        private JsonSerializerOptions JsonSerializerOptions { get; private set; }
        public HttpResponseMessage HttpResponseMessage { get; private set; }
        public HttpStatusCode HttpStatusCode { get; private set; }
        public string HttpContent { get; set; }

        public HttpMethod() {
            httpClient = new HttpClient();
            JsonSerializerOptions = new JsonSerializerOptions() {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public void AddHeader(string headerName, string headerValue) {
            httpClient.DefaultRequestHeaders.Add(headerName, headerValue);
        }

        public object Deserialize(string classString) {
            var type = Type.GetType(classString);
            return JsonSerializer.Deserialize(HttpContent, type, JsonSerializerOptions);
        }

        public async Task Get(string url) {
            HttpResponseMessage = await httpClient.GetAsync(url);
            HttpStatusCode = HttpResponseMessage.StatusCode;
            HttpContent = await HttpResponseMessage.Content.ReadAsStringAsync();
        }
        //public async Task Post() {

        //}
        //public async Task Put() {

        //}
        //public async Task Delete() {

        //}
    }
}

