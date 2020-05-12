﻿using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GrandEventCentral.Client.Helpers
{
    public class HttpService : IHttpService
    {
        private readonly CustomHttpClientFactory customHttpClientFactory;

        private JsonSerializerOptions defaultJsonSerializerOptions =>
            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public HttpService(CustomHttpClientFactory customHttpClientFactory)
        {
            this.customHttpClientFactory = customHttpClientFactory;
        }

        private async Task<HttpClient> GetHttpClient(bool includeToken = true)
        {
            if (includeToken)
            {
                return await customHttpClientFactory.GetHttpClientWithToken();
            }
            else
            {
                return customHttpClientFactory.GetHttpClientWithoutToken();
            }
        }

        public async Task<HttpResponseWrapper<T>> Get<T>(string url, bool includeToken = true)
        {
            var httpClient = await GetHttpClient(includeToken);
            var responseHTTP = await httpClient.GetAsync(url);

            if (responseHTTP.IsSuccessStatusCode)
            {
                var response = await Deserialize<T>(responseHTTP, defaultJsonSerializerOptions);
                return new HttpResponseWrapper<T>(response, true, responseHTTP);
            }
            else
            {
                return new HttpResponseWrapper<T>(default, false, responseHTTP);
            }
        }

        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T data)
        {
            var httpClient = await GetHttpClient();

            var dataJson = JsonSerializer.Serialize(data);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, stringContent);
            return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
        }

        public async Task<HttpResponseWrapper<object>> Put<T>(string url, T data)
        {
            var httpClient = await GetHttpClient();

            var dataJson = JsonSerializer.Serialize(data);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(url, stringContent);
            return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
        }

        public async Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data, bool includeToken = true)
        {
            var httpClient = await GetHttpClient(includeToken);

            var dataJson = JsonSerializer.Serialize(data);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, stringContent);
            if (response.IsSuccessStatusCode)
            {
                var responseDeserialized = await Deserialize<TResponse>(response, defaultJsonSerializerOptions);
                return new HttpResponseWrapper<TResponse>(responseDeserialized, true, response);
            }
            else
            {
                return new HttpResponseWrapper<TResponse>(default, false, response);
            }
        }

        public async Task<HttpResponseWrapper<object>> Delete(string url)
        {
            var httpClient = await GetHttpClient();

            var responseHTTP = await httpClient.DeleteAsync(url);
            return new HttpResponseWrapper<object>(null, responseHTTP.IsSuccessStatusCode, responseHTTP);
        }

        private async Task<T> Deserialize<T>(HttpResponseMessage httpResponse, JsonSerializerOptions options)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseString, options);
        }
    }
}
