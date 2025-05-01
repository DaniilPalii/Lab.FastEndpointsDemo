using System.Net;
using System.Net.Mime;

namespace FeDemoWebApi.Exceptions;

public class ExceptionHandlingMiddleware : IMiddleware
{
	public async Task InvokeAsync(HttpContext context, RequestDelegate next)
	{
		try
		{
			await next(context);
		}
		catch (Exception ex)
		{
			await HandleExceptionAsync(context, ex);
		}
	}

	private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
	{
		var response = exception switch
		{
			EntityNotFoundException _ => new ExceptionResponse(HttpStatusCode.NotFound, exception.Message),
			_ => new(HttpStatusCode.InternalServerError, "Internal server error."),
		};

		context.Response.ContentType = MediaTypeNames.Application.Json;
		context.Response.StatusCode = (int)response.StatusCode;
		await context.Response.WriteAsJsonAsync(response);
	}

	private record ExceptionResponse(
		HttpStatusCode StatusCode,
		string Message);
}
