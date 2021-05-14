using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TimeKeeper.Domain.Models;

namespace TimeKeeper.Services
{
    public class TimeEntryService : ITimeEntryService
    {
        private readonly HttpClient _httpClient;

        public TimeEntryService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<TimeEntry> CreateAsync(TimeEntry timeEntry)
        {
            var json = new StringContent(JsonSerializer.Serialize(timeEntry), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("api/timeentry", json);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<TimeEntry>(
                    await response.Content.ReadAsStreamAsync(),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return null;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var httpResponseMessage = await _httpClient.DeleteAsync($"api/timeentry/delete/{id}");

            return httpResponseMessage.IsSuccessStatusCode;
        }

        public async Task<TimeEntry> GetByIdAsync(int id)
        {
            return await JsonSerializer.DeserializeAsync<TimeEntry>(
                await _httpClient.GetStreamAsync($"api/timeentry/{id}"),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<TimeEntriesView>> GetForUserOnSelectedDateAsync(int userId, DateTime selectedDate)
        {
            string url = $"api/timeentry/GetForUserOnSelectedDate?userId={userId}" +
                $"&selectedDate={selectedDate.ToString("s", System.Globalization.CultureInfo.InvariantCulture)}";

            return await JsonSerializer.DeserializeAsync<IEnumerable<TimeEntriesView>>
                (await _httpClient.GetStreamAsync(url), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<TimeEntry> UpdateAsync(TimeEntry timeEntry)
        {
            var json = new StringContent(JsonSerializer.Serialize(timeEntry), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync("api/timeentry", json);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<TimeEntry>(
                    await response.Content.ReadAsStreamAsync(),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return null;
        }
    }
}
