namespace FeDemoWebApi.DTO;

public sealed record Book(
	long Id,
	string Title,
	string Author,
	DateOnly DateOfPublication)
{
	public Book(Entities.Book entity)
		: this(
			entity.Id,
			entity.Title,
			entity.Author,
			entity.DateOfPublication)
	{ }
}
