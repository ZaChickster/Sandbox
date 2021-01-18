using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace Sandbox.Messaging
{
	public static class StartupExtentions
	{
		public static IServiceCollection SetupRabbitMq(this IServiceCollection services)
		{
			services.AddSingleton(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
			{
				cfg.Host("localhost", "/",
					h =>
					{
						h.Username("localuser");
						h.Password("localuser");
					});

				cfg.ExchangeType = ExchangeType.Direct;
			}));

			services.AddSingleton<IBus>(provider => provider.GetRequiredService<IBusControl>());

			return services;
		}
	}
}
