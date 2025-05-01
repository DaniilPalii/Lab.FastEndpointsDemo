using FastEndpoints;
using FastEndpoints.Swagger;
using FeDemoWebApi.Exceptions;
using FeDemoWebApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services
	.AddFastEndpoints()
	.SwaggerDocument();

builder.Services.AddTransient<ExceptionHandlingMiddleware>();

builder.Services.AddSingleton<IBookRepository, InMemoryBookRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwaggerGen();
}

app.UseHttpsRedirection();
app.UseFastEndpoints();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();
