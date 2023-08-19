using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RecipeApp;
using RecipeApp.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<UserServices>();
builder.Services.AddHttpClient<IUserServicese, UserServices>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7006/");
});
builder.Services.AddSingleton<RecipeService>();
builder.Services.AddHttpClient<IRecipeService, RecipeService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7006/");
});

await builder.Build().RunAsync();
