using FastEndpoints;
using FeDemoWebApi.Repositories;

namespace FeDemoWebApi.Endpoints;

public class RemoveBookEndpoint(IBookRepository bookRepository)
	: Endpoint<RemoveBookEndpoint.Request>
{
	public record Request(long Id);

	public override void Configure()
	{
		Delete("/books/{id:long}");
		AllowAnonymous();
	}

	public override async Task HandleAsync(Request request, CancellationToken ct)
	{
		bookRepository.Delete(request.Id);
		await SendOkAsync(ct);
	}
}
