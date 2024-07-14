using Data;
using Repositories;
using Services;
using Microsoft.EntityFrameworkCore;
using tweets_class.Features;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var mySqlConnectionString = builder.Configuration.GetConnectionString("MySqlConnection");

if(builder.Environment.IsProduction() || builder.Environment.IsStaging()){
    if(builder.Environment.IsStaging()){
        builder.WebHost.UseStaticWebAssets();
    }
    builder.Services.AddDbContextFactory<ConnectionDbContext>(options => options.UseMySql(mySqlConnectionString, ServerVersion.AutoDetect(mySqlConnectionString)));
}

builder.Services.AddScoped<AccessKeyRepository>();
builder.Services.AddScoped<PhraseRepository>();
builder.Services.AddScoped<LabelingRepository>();

builder.Services.AddScoped<AccessKeyService>();
builder.Services.AddScoped<LabelingService>();

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
