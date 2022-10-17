using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using EchoDashboard.Client;
using Fluxor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyLab.Platform.Frontend.Framework.Facades;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<StateFacadeRegistry>();

builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();

builder.Services.AddFluxor(options =>
{
    var executingAssembly = Assembly.GetExecutingAssembly();
    options.ScanAssemblies(executingAssembly, AppDomain.CurrentDomain.GetAssemblies());
    options.UseReduxDevTools();
});

await builder.Build().RunAsync();
