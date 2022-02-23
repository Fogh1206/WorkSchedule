using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using WorkScheduleAPI.Models;
using WorkScheduleBlazorApp.Data;
using User = WorkScheduleBlazorApp.Models.User;

namespace WorkScheduleBlazorApp.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {

        private readonly IJSRuntime jsRuntime;
        private readonly IUser userService;
        
        public User cachedUser { get; set; }

        public CustomAuthenticationStateProvider(IJSRuntime jsRuntime, IUser userService)
        {
            this.jsRuntime = jsRuntime;
            this.userService = userService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            if (cachedUser == null)
            {
                string userAsJson = await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");
                if (!string.IsNullOrEmpty(userAsJson))
                {
                    User tmp = JsonSerializer.Deserialize<User>(userAsJson);
                    await ValidateLogin(tmp);
                }
            }
            else
            {
                identity = SetUpClaimsForUser(cachedUser);
            }
            ClaimsPrincipal cachedClaimsPrincipal = new ClaimsPrincipal(identity);
                return await Task.FromResult(new AuthenticationState(cachedClaimsPrincipal));
        }

        public async Task ValidateLogin(User inputUser)
        {
            Console.WriteLine("Validating login");
            if (string.IsNullOrEmpty(inputUser.Username)) throw new Exception("Enter username");
            if (string.IsNullOrEmpty(inputUser.Password)) throw new Exception("Enter password");

            ClaimsIdentity identity = new();
            try
            {
                User user = await userService.ValidateUser(inputUser);
                identity = SetUpClaimsForUser(user);
                string serialisedData = JsonSerializer.Serialize(user);
                await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", serialisedData);
                cachedUser = user;
            }
            catch (Exception e)
            {
                throw e;
            }
            NotifyAuthenticationStateChanged(
                Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
        }

        public async Task Logout()
        {
            cachedUser = null;
            var user = new ClaimsPrincipal(new ClaimsIdentity());
            await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", "");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        private ClaimsIdentity SetUpClaimsForUser(User user)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Upn, user.Username),
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.GroupSid, user.Company.Id.ToString())
            };

            ClaimsIdentity identity = new(claims, "apiauth_type");
            return identity;

        }
        
    }
}