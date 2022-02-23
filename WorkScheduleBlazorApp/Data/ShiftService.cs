using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WorkScheduleBlazorApp.Models;

namespace WorkScheduleBlazorApp.Data
{
    public class ShiftService : IShift
    {
        private const string Uri = "https://localhost:7038";
        private readonly HttpClient _client;

        public ShiftService()
        {
            _client = new HttpClient();
        }

        public async Task<List<GetShiftDTO>> GetShiftsFromUserId(int userId)
        {
            HttpResponseMessage responseMessage = await _client.GetAsync(Uri + $"/Shifts/{userId}");
            if (!responseMessage.IsSuccessStatusCode)
            {
                // NOT GOOD
            }
            return await responseMessage.Content.ReadFromJsonAsync<List<GetShiftDTO>>()?? throw new Exception("Shifts not found");
        }
    }
}