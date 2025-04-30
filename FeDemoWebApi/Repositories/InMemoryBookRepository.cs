using System.Collections.Concurrent;

namespace FeDemoWebApi.Repositories;

public class InMemoryBookRepository : IBookRepository
{
	public Entities.Book Add(Entities.Book entity)
	{
		lock (addingLock)
		{
			entity.Id = nextId;
			dictionary[nextId] = entity;
			nextId++;
		}

		return entity;
	}

	public Entities.Book? Get(long id)
	{
		return dictionary.GetValueOrDefault(id);
	}

	public IEnumerable<Entities.Book> GetAll()
	{
		return dictionary.Values;
	}

	public void Update(Entities.Book entity)
	{
		var existingEntity = Get(entity.Id);

		if (existingEntity is null)
			throw new Exception("Book not found in repository");

		existingEntity.Title = entity.Title;
		existingEntity.Author = entity.Author;
		existingEntity.DateOfPublication = entity.DateOfPublication;
	}

	public void Delete(long id)
	{
		dictionary.Remove(id, out _);
	}

	private long nextId = 1;
	private readonly ConcurrentDictionary<long, Entities.Book> dictionary = new();
	private readonly Lock addingLock = new();
}
