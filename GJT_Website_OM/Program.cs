using GJT_Website_OM.Components;
using GJT_Website_OM.Components.Layout;
using GJT_Website_OM.Models;
using GJT_Website_OM.Services;
using GJT_Website_OM.Utilities;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Components

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

// Clients & Context

builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<TlS2303831GjtContext>(options =>
options.UseMySql(builder.Configuration.GetConnectionString("MySqlConnection"),
new MySqlServerVersion(new Version(8, 0, 29))));

// Scoped

builder.Services.AddScoped<OpenAIHttpService>();
builder.Services.AddScoped<QuizService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<LoggedInService>();
builder.Services.AddScoped<BadgeDialog>();

// Singletons

builder.Services.AddSingleton<TopicService>();
builder.Services.AddSingleton<UserSession>();
builder.Services.AddSingleton<LoggedInService>();
builder.Services.AddSingleton<SubjectService>();


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

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
