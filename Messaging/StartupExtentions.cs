using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace Sandbox.Messaging
{
	public static class StartupExtentions
	{
		public static IServiceCollection SetupRabbitMq<T>(this IServiceCollection services) where T : class, IConsumer<DataCollection>, new()
		{
			var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
			{
				cfg.Host("localhost", "/", h =>
				{
					h.Username("localuser");
					h.Password("localuser");
				});

				cfg.ReceiveEndpoint("device-data-collection", e =>
				{
					e.Consumer<T>();
				});

				cfg.ExchangeType = ExchangeType.Direct;
			});
			bus.Start();

			services.AddSingleton(provider => bus);

			services.AddSingleton<IBus>(provider => provider.GetRequiredService<IBusControl>());
			services.AddScoped<IRabbitMqAbstraction, RabbitMqAbstraction>();

			return services;
		}
	}
}
