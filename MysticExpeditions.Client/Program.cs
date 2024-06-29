using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using MysticExpeditions.Client;
using MysticExpeditions.Server.Data;
using MysticExpeditions.Server.Data.Repositories;
using MysticExpeditions.Server.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddDbContext<GameDbContext>(options => options.UseSqlite("Data Source=mysticexpeditions.db"));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();

builder.Services.AddSingleton<GameStateService>();
builder.Services.AddSingleton<ScenarioService>();

await builder.Build().RunAsync();
