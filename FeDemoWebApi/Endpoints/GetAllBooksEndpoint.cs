using FastEndpoints;
using FeDemoWebApi.Repositories;

namespace FeDemoWebApi.Endpoints;

public sealed class GetAllBooksEndpoint(IBookRepository bookRepository)
	: EndpointWithoutRequest<IEnumerable<DTO.Book>>
{
	public override void Configure()
	{
		Get("/books");
		AllowAnonymous();
	}

	public override async Task HandleAsync(CancellationToken ct)
	{
		var books = bookRepository.GetAll();
		var dtos = books.Select(entity => new DTO.Book(entity));

		await SendOkAsync(dtos, ct);
	}
}
