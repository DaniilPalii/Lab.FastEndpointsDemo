namespace FeDemoWebApi.DTO;

public record NewBook(
	string Title,
	string Author,
	DateOnly DateOfPublication)
{
	public Entities.Book ToEntity()
	{
		return new()
		{
			Title = Title,
			Author = Author,
			DateOfPublication = DateOfPublication,
		};
	}
}
