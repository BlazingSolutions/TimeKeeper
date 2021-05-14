using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TimeKeeper.Domain.Models;

namespace TimeKeeper.Services
{
    public class RegionalOfficeService : IRegionalOfficeService
    {
        private readonly HttpClient _httpClient;

        public RegionalOfficeService(HttpClient regionalOffice)
        {
            _httpClient = regionalOffice;
        }

        public async Task<RegionalOffice> CreateAsync(RegionalOffice regionalOffice)
        {
            var json = new StringContent(JsonSerializer.Serialize(regionalOffice), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("api/regionaloffice", json);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<RegionalOffice>(
                    await response.Content.ReadAsStreamAsync(),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return null;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var httpResponseMessage = await _httpClient.DeleteAsync($"api/regionaloffice/delete/{id}");

            return httpResponseMessage.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<RegionalOffice>> GetAllAsync()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<RegionalOffice>>(
                await _httpClient.GetStreamAsync("api/regionaloffice"),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<RegionalOffice> GetByIdAsync(int id)
        {
            return await JsonSerializer.DeserializeAsync<RegionalOffice>(
                await _httpClient.GetStreamAsync($"api/regionaloffice/{id}"),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<RegionalOffice> UpdateAsync(RegionalOffice regionalOffice)
        {
            var json = new StringContent(JsonSerializer.Serialize(regionalOffice), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync("api/regionaloffice", json);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<RegionalOffice>(
                    await response.Content.ReadAsStreamAsync(),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return null;
        }
    }
}
