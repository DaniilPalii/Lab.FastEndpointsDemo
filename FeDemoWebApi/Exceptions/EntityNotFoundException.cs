namespace FeDemoWebApi.Exceptions;

public class EntityNotFoundException(long id)
	: Exception(message: $"Entity not found (id: {id})");
