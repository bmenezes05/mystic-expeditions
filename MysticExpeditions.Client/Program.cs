using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MysticExpeditions.Client;
using MysticExpeditions.Domain.Apis;
using MysticExpeditions.Domain.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient<IApiClient, ApiClient>();

builder.Services.AddScoped<IGameSaveService, GameSaveService>();
builder.Services.AddScoped<GameStateService>();

await builder.Build().RunAsync();