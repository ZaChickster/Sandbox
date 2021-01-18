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

				cfg.AutoStart = true;
			}));

			services.AddSingleton<IBus>(provider => provider.GetRequiredService<IBusControl>());
			services.AddScoped<IRabbitMqAbstraction, RabbitMqAbstraction>();

			return services;
		}
	}
}
