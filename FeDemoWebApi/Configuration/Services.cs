using FeDemoWebApi.Repositories;

namespace FeDemoWebApi.Configuration;

public static class Services
{
	public static void Inject(IHostApplicationBuilder builder)
	{
		builder.Services.AddSingleton<IBookRepository, InMemoryBookRepository>();
	}
}
