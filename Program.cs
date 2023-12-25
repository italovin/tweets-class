using System.Text.Json;
using blazor_test.Configurations;
using blazor_test.Data;
using blazor_test.Features;
using blazor_test.Models;
using blazor_test.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddDbContext<ConnectionDbContext>(options => options.UseSqlite(
    builder.Configuration.GetConnectionString("SqliteConnection")
));

builder.Services.AddTransient<AccessKeyRepository>();
builder.Services.AddTransient<PhraseRepository>();
builder.Services.AddTransient<LabelingRepository>();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

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
