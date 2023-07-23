using Microsoft.EntityFrameworkCore;

namespace NanoSurvery.WebApi.Extensions
{
	public static class WebApplicationExtensions
	{
		public static WebApplication MigrateDatabase<T>(this WebApplication host) where T : DbContext
		{
			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				try
				{
					var db = services.GetRequiredService<T>();
					db.Database.Migrate();
				}
				catch (Exception ex)
				{
					var logger = services.GetRequiredService<ILogger<Program>>();
					logger.LogError(ex, "An error occurred while migrating the database.");
				}
			}
			return host;
		}
	}
}
