using Azure.Identity;
using DotNetEnv;
using Microsoft.Graph;
using RewardsSharePointIntegration.Services;

var builder = WebApplication.CreateBuilder(args);

// Carregar vari�veis de ambiente do arquivo .env
//DotNetEnv.Env.Load();
Env.Load();

// Adiciona configura��es do appsettings.json e tamb�m vari�veis do ambiente
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();  // Isso adiciona as vari�veis carregadas pelo DotNetEnv ao IConfiguration

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adicione o GraphServiceClient usando a autentica��o com ClientSecretCredential
builder.Services.AddSingleton<GraphServiceClient>(sp =>
{
    var clientId = builder.Configuration["AzureAd:ClientId"];
    var tenantId = builder.Configuration["AzureAd:TenantId"];
    var clientSecret = builder.Configuration["AzureAd:ClientSecret"];

    var clientSecretCredential = new ClientSecretCredential(
        tenantId, 
        clientId, 
        clientSecret
    );

    return new GraphServiceClient(clientSecretCredential);
});

builder.Services.AddSingleton<ISharePointService, SharePointService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
