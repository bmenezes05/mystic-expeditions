using System.Net.Http;
using System.Net.Http.Json;
using MysticExpeditions.Domain.Models;

namespace MysticExpeditions.Domain.Apis
{
    public class ApiClient : IApiClient
    {
        public HttpClient _httpClient;
        private const string apiUrl = "/api/reservas/";

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7211/");
            _httpClient.Timeout = new TimeSpan(0, 0, 50);
        }

        public async Task<List<Race>> GetRacesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Race>>("api/races");
        }

        public async Task<List<Class>> GetClassesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Class>>("api/classes");
        }

        public async Task<List<Class>> GetSubclassesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Class>>("api/subclasses");
        }

        public async Task<HttpResponseMessage> CreateCharacterAsync(Character character)
        {
            return await _httpClient.PostAsJsonAsync("api/characters", character);            
        }
    }
}