using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WorkScheduleBlazorApp.Authentication;
using WorkScheduleBlazorApp.Data;
using WorkScheduleBlazorApp.Data.Notifications;
using WorkScheduleBlazorApp.Data.Refresh;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddScoped<ICompany, CompanyService>();
builder.Services.AddScoped<IShift, ShiftService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<IRefreshServiceInvShift, RefreshServiceInvShift>();
builder.Services.AddScoped<IRefreshServiceNavMem, RefreshServiceNavMem>();
builder.Services.AddSingleton<NotificationManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();