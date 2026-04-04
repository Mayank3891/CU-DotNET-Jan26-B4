// or a DTO in MVC project
using FrontEnd.Models;
using FrontEnd.Services;
using System.Net.Http;
using System.Net.Http.Json;

namespace FrontEnd.Services
{
    public class TravelService : ITravelService
    {
        private readonly HttpClient _httpClient;

        public TravelService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Destination>> GetAllAsync()
        {
            var destinations = await _httpClient.GetFromJsonAsync<IEnumerable<Destination>>("api/destinations");
            return destinations ?? new List<Destination>();
        }
    }
}