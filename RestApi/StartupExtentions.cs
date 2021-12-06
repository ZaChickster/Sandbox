using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using Sandbox.RestApi.Consumer;

namespace Sandbox.Messaging
{
	public static class StartupExtentions
	{
		public static IServiceCollection SetupRabbitMq(this IServiceCollection services)
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
					var sp = services.BuildServiceProvider();
					e.Consumer(() => sp.GetService<IDataCollectionConsumer>());
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
