using FastEndpoints;
using FeDemoWebApi.DTO;
using FeDemoWebApi.Repositories;

namespace FeDemoWebApi.Endpoints;

public class AddBookEndpoint(IBookRepository bookRepository)
	: Endpoint<NewBook>
{
	public override void Configure()
	{
		Post("/books");
		AllowAnonymous();
	}

	public override async Task HandleAsync(NewBook newBook, CancellationToken ct)
	{
		var entity = newBook.ToEntity();
		bookRepository.Add(entity);
		await SendOkAsync(ct);
	}
}
