using FastEndpoints;
using FeDemoWebApi.Repositories;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddFastEndpoints();

builder.Services.AddSingleton<IBookRepository, InMemoryBookRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
	app.MapScalarApiReference("docs");
}

app.UseHttpsRedirection();
app.UseFastEndpoints();

app.Run();
