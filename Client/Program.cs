using BootstrapBlazor.Components;
using QC.Client;
using QC.Client.Core;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<MudThemeProvider>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//Toaster
builder.Services.AddScoped<ToasterService>();


await builder.Build().RunAsync();

namespace BootstrapBlazorAppName
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //more code may be present here
            services.AddBootstrapBlazor();
        }

        //more code may be present here
    }
}
