using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WorkScheduleBlazorApp.Models;

namespace WorkScheduleBlazorApp.Data
{
    public class CompanyService : ICompany
    {
        
        private string URI = "https://localhost:7038";
        private readonly HttpClient _client;

        public CompanyService()
        {
            _client = new HttpClient();
        }
        
        public async Task<Company> CreateCompany(Company company)
        {
            string userAsJson = JsonSerializer.Serialize(company);
            HttpContent content = new StringContent(userAsJson,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage response = await _client.PostAsync($"{URI}/Company",content);

            Company result = await response.Content.ReadFromJsonAsync<Company>() ?? throw new Exception("Company not found");
            return result;
        }
    }
}