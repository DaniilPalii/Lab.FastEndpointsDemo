namespace FeDemoWebApi.Exceptions;

public sealed class EntityNotFoundException(long id)
	: Exception(message: $"Entity not found (id: {id})");
