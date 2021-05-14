using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TimeKeeper.Domain.Models;

namespace TimeKeeper.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            var json = new StringContent(JsonSerializer.Serialize(category), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("api/category", json);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Category>(
                    await response.Content.ReadAsStreamAsync(),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return null;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var httpResponseMessage = await _httpClient.DeleteAsync($"api/category/delete/{id}");

            return httpResponseMessage.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Category>>(
                await _httpClient.GetStreamAsync("api/category"),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await JsonSerializer.DeserializeAsync<Category>(
                await _httpClient.GetStreamAsync($"api/category/{id}"),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            var json = new StringContent(JsonSerializer.Serialize(category), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync("api/category", json);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Category>(
                    await response.Content.ReadAsStreamAsync(),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return null;
        }
    }
}
