using FastEndpoints;
using FastEndpoints.Swagger;
using FeDemoWebApi.Configuration;
using FeDemoWebApi.Exceptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
	.AddFastEndpoints()
	.SwaggerDocument();

builder.Services.AddTransient<ExceptionHandlingMiddleware>();

Services.Inject(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwaggerGen();
}

app.UseHttpsRedirection();
app.UseFastEndpoints();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();
