namespace FeDemoWebApi.Entities;

public sealed class Book
{
	public long Id { get; set; }

	public string Title { get; set; }

	public string Author { get; set; }

	public DateOnly DateOfPublication { get; set; }
}
