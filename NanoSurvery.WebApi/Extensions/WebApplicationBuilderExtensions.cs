using Microsoft.EntityFrameworkCore;
using Serilog;

namespace NanoSurvery.WebApi.Extensions
{
	public static class WebApplicationBuilderExtensions
	{
		public static IHostBuilder AddSerilogConfigured(this WebApplicationBuilder builder)
			=> builder.Host.UseSerilog((context, configuration) => configuration
				.ReadFrom.Configuration(context.Configuration)
				.Enrich.FromLogContext()
				.WriteTo.Console());
	}
}
