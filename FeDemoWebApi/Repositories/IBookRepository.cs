using FeDemoWebApi.Entities;

namespace FeDemoWebApi.Repositories;

public interface IBookRepository
{
	Book Add(Book entity);

	Book? Get(long id);

	IEnumerable<Book> GetAll();

	void Update(Book entity);

	void Delete(long id);
}
