using CarRental.Business.Services;
using CarRental.Data.Classes;
using CarRental.Data.Interfaces;
using CarRental.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<CarRentalService>();
builder.Services.AddScoped<IData, Data>();
await builder.Build().RunAsync();
