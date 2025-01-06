using System.Net;
using BrennansWebsite.Components;
using BrennansWebsite.Data;
using BrennansWebsite.Models;
using BrennansWebsite.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
//Connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MySqlConnection")));
// Scoped lifetime
builder.Services.AddScoped<GardensService>();
builder.Services.AddScoped<GardenersService>();
builder.Services.AddScoped<PlotsServices>();  
builder.Services.AddScoped<BannedCropsService>();  
builder.Services.AddScoped<ClaimedByService>();  
builder.Services.AddScoped<CropsGrowingService>();  
builder.Services.AddScoped<ApplicationDbContext>();
builder.Services.AddScoped<UserAccountService>();
//cookie stuff
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login";
        options.Cookie.Name = "auth_token";
        options.Cookie.MaxAge = TimeSpan.FromHours(1);
        options.AccessDeniedPath = "/";//add acess deined page !!!!later
    });
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();

//
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();