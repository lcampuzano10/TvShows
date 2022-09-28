using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using PersonalTVShows;
using PersonalTVShows.Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//var config = builder.Configuration.GetSection("TvShows").Get<List<int>>();

builder.Services.AddMudServices();

builder.Services.ConfigureHttpClient();
builder.Services.ConfigureAPiServices();

await builder.Build().RunAsync();
