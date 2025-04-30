using FastEndpoints;
using FeDemoWebApi.DTO;
using FeDemoWebApi.Repositories;

namespace FeDemoWebApi.Endpoints;

public class UpdateBookEndpoint(IBookRepository bookRepository)
	: Endpoint<UpdateBookEndpoint.Request, NewBook>
{
	public record Request(long Id, NewBook NewBook);

	public override void Configure()
	{
		Put("/books/{id:long}");
		AllowAnonymous();
	}

	public override async Task HandleAsync(Request request, CancellationToken ct)
	{
		var entity = request.NewBook.ToEntity();
		entity.Id = request.Id;
		bookRepository.Update(entity);
		await SendOkAsync(ct);
	}
}
