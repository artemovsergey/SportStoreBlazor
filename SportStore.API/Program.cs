using Microsoft.AspNetCore.ResponseCompression;
using SportStore.Application.Respositories;
using SportStore.API.Hubs;
using SportStore.Infrastructure;
using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;
using System.Reflection;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
                              
builder.Services.AddScoped<SportStoreContext>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<RoleRepository>();
builder.Services.AddCors();

builder.Services.AddSignalR();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes
    .Concat(new[] { "application/octet-stream" });
});

builder.Services.AddGrpc();

//builder.Services.AddScoped<LoginValidator>();
//builder.Services.AddHttpClient();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),@"Images")),
    RequestPath = new Microsoft.AspNetCore.Http.PathString("/Images")
});


app.UseHttpsRedirection();
app.MapHub<UserHub>("/test");
app.MapControllers();

app.UseCors(o => o.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseGrpcWeb();


app.Run();
