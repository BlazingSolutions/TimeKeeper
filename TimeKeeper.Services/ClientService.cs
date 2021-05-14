using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TimeKeeper.Domain.Models;

namespace TimeKeeper.Services
{
    public class ClientService : IClientService
    {
        private readonly HttpClient _httpClient;

        public ClientService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<Client> CreateAsync(Client client)
        {
            var json = new StringContent(JsonSerializer.Serialize(client), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("api/client", json);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Client>(
                    await response.Content.ReadAsStreamAsync(),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return null;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var httpResponseMessage = await _httpClient.DeleteAsync($"api/client/delete/{id}");

            return httpResponseMessage.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Client>>(
                await _httpClient.GetStreamAsync("api/client"),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            return await JsonSerializer.DeserializeAsync<Client>(
                await _httpClient.GetStreamAsync($"api/client/{id}"),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Client> UpdateAsync(Client client)
        {
            var json = new StringContent(JsonSerializer.Serialize(client), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync("api/client", json);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Client>(
                    await response.Content.ReadAsStreamAsync(),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return null;
        }
    }
}
