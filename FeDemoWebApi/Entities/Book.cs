namespace FeDemoWebApi.Entities;

public class Book
{
	public long Id { get; set; }

	public string Title { get; set; }

	public string Author { get; set; }

	public DateOnly DateOfPublication { get; set; }
}
