using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ShoppingOnline.Web;
using ShoppingOnline.Web.Services;
using ShoppingOnline.Web.Services.Contracts;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//Configure BaseAddress to point to API URI
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7213") });

//Register Interfaces
builder.Services.AddScoped<IProductService, ProductService>();

await builder.Build().RunAsync();
