using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WorkScheduleBlazorApp.Models;

namespace WorkScheduleBlazorApp.Data
{
    public class UserService : IUser
    {
        private const string Uri = "https://localhost:7038";
        private readonly HttpClient _client;

        public UserService()
        {
            _client = new HttpClient();
        }

        public async Task<User> ValidateUser(User user)
        {
            string userAsJson = JsonSerializer.Serialize(new LoginUserDTO()
            {
                Username = user.Username,
                Password = user.Password,
            });
            HttpContent content = new StringContent(userAsJson,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage response = await _client.PostAsync($"{Uri}/User/Login", content);
            User result = await response.Content.ReadFromJsonAsync<User>() ?? 
                          throw new Exception("User not found");
            return result;
        }

        public async Task<User> GetFromIdAsync(int id)
        {
            HttpResponseMessage responseMessage = await _client.GetAsync($"{Uri}/User/{id}");
            User result = await responseMessage.Content.ReadFromJsonAsync<User>() ??
                          throw new Exception("User not retrieved");
            return result;
        }

        public async Task DeleteUser(int userId)
        {
            HttpResponseMessage responseMessage = await _client.DeleteAsync($"{Uri}/User/{userId}");
            
        }
    }
}