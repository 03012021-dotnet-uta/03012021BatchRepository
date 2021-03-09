using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LoggingTestingDelegates
{
	class Program
	{
		static void Main(string[] args)
		{
			var serviceCollection = new ServiceCollection();
			ConfigureServices(serviceCollection);

			using ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
			MathClass mc = serviceProvider.GetService<MathClass>();
			mc.LoggingMethod();


		}

		private static void ConfigureServices(IServiceCollection services)
		{
			services.AddLogging(configure =>
			{
				configure.ClearProviders();
				configure.AddConsole();
				configure.SetMinimumLevel(LogLevel.Trace);
			})
			.AddTransient<MathClass>();
		}
	}
}
