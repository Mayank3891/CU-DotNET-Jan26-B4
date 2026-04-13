using System.Net.Http;
using System.Net.Http.Json;
using azurefront.Models;

namespace azurefront.Services
{
    public class StudentService
    {
        private readonly HttpClient _client;

        public StudentService(HttpClient client)
        {
            _client = client;
        }

       
        public async Task<List<student>> GetAllAsync()
        {
            var data = await _client.GetFromJsonAsync<List<student>>("api/students");
            return data ?? new List<student>();
        }

       
        public async Task<student?> GetByIdAsync(int id)
        {
            try
            {
                return await _client.GetFromJsonAsync<student>($"api/students/{id}");
            }
            catch
            {
                return null;
            }
        }

  
        public async Task<bool> CreateAsync(student students)
        {
            var response = await _client.PostAsJsonAsync("api/students", students);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(int id, student students)
        {
            var response = await _client.PutAsJsonAsync($"api/students/{id}", students);
            return response.IsSuccessStatusCode;
        }

  
        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"api/students/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}