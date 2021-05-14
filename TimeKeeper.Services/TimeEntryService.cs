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

            HttpResponseMessage response = await _httpClient.PostAsync("api/TimeEntry", json);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<TimeEntry>(
                    await response.Content.ReadAsStreamAsync(),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return null;
        }

        public async Task<IEnumerable<TimeEntry>> GetForSelectedDateAsync(int userId, DateTime selectedDate)
        {
            string url = $"api/timeentry/GetForSelectedDate?userId={userId}" +
                $"&selectedDate={selectedDate.ToString("s", System.Globalization.CultureInfo.InvariantCulture)}";

            return await JsonSerializer.DeserializeAsync<IEnumerable<TimeEntry>>
                (await _httpClient.GetStreamAsync(url), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
