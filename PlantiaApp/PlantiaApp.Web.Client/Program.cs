using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PlantiaApp.Shared.Services;
using PlantiaApp.Web.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add device-specific services used by the PlantiaApp.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

await builder.Build().RunAsync();
