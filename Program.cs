using blazor_test.Data;
using blazor_test.Features;
using blazor_test.Repositories;
using blazor_test.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var mySqlConnectionString = builder.Configuration.GetConnectionString("MySqlConnection");

if(builder.Environment.IsProduction()){
    if(builder.Environment.IsStaging()){
        builder.Host.ConfigureWebHostDefaults(webBuilder => {webBuilder.UseStaticWebAssets();});
    }
    builder.Services.AddDbContext<ConnectionDbContext>(options => options.UseMySql(mySqlConnectionString, ServerVersion.AutoDetect(mySqlConnectionString)));
}

builder.Services.AddTransient<AccessKeyRepository>();
builder.Services.AddTransient<PhraseRepository>();
builder.Services.AddTransient<LabelingRepository>();

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
