using FastEndpoints;
using FeDemoWebApi.Repositories;

namespace FeDemoWebApi.Endpoints;

public sealed class GetBookEndpoint(IBookRepository bookRepository)
	: Endpoint<GetBookEndpoint.Request, DTO.Book>
{
	public record Request(long Id);

	public override void Configure()
	{
		Get("/books/{id:long}");
		AllowAnonymous();
	}

	public override async Task HandleAsync(Request request, CancellationToken ct)
	{
		var entity = bookRepository.Get(request.Id);

		if (entity is null)
		{
			await SendNotFoundAsync(ct);
			return;
		}

		var dto = new DTO.Book(entity);
		await SendOkAsync(dto, ct);
	}
}
