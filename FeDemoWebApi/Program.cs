using FastEndpoints;
using FastEndpoints.Swagger;
using FeDemoWebApi.Repositories;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
	.AddFastEndpoints()
	.SwaggerDocument();

builder.Services.AddSingleton<IBookRepository, InMemoryBookRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseOpenApi(configure => configure.Path = "/openapi/{documentName}.json");
	app.MapScalarApiReference("docs");
}

app.UseHttpsRedirection();
app.UseFastEndpoints();

app.Run();
