using FluentValidation;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SportStore.Blazor;
using SportStore.Domen.Models;
using SportStore.Domen.Validations;
using System.Reflection;
using SportStore.Application;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7214") });

builder.Services.AddScoped<IValidator<User>, UserValidator>();

var assembly = AppDomain.CurrentDomain.Load("SportStore.Application");
builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(
                            Assembly.GetExecutingAssembly(), assembly));

builder.Services.AddApplicationServices();

await builder.Build().RunAsync();
