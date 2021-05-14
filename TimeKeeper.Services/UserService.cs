using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TimeKeeper.Domain.Models;

namespace TimeKeeper.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<User> CreateAsync(User user)
        {
            var json = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("api/user", json);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<User>(
                    await response.Content.ReadAsStreamAsync(),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return null;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var httpResponseMessage = await _httpClient.DeleteAsync($"api/user/delete/{id}");

            return httpResponseMessage.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<User>>(
                await _httpClient.GetStreamAsync("api/user"),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await JsonSerializer.DeserializeAsync<User>(
                await _httpClient.GetStreamAsync($"api/user/{id}"),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<User> UpdateAsync(User user)
        {
            var json = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync("api/user", json);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<User>(
                    await response.Content.ReadAsStreamAsync(),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return null;
        }
    }
}
