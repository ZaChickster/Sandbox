using MassTransit;
using Sandbox.Messaging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sandbox.ConsoleDevice
{
	public class Program
	{
		public static async Task Main()
		{
			Console.WriteLine("Please Enter Device ID:");
			string deviceId = Console.ReadLine();

			var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
			{
				sbc.Host("rabbitmq://localhost");

				sbc.ReceiveEndpoint(string.Format(RabbitMqAbstraction.QUEUE_NAME_FORMAT, deviceId), ep =>
				{
					ep.Handler<IDeviceStatus>(context =>
					{
						return Console.Out.WriteLineAsync($"Device {context.Message.DeviceId} should now have status {context.Message.Status}.");
					});
				});
			});

			await bus.StartAsync(); // This is important!

			var endpoint = await bus.GetSendEndpoint(new Uri($"queue:device-data-collection"));
			var random = new Random();

			while(true)
			{
				int seed = random.Next(1, 12);
				string status = "";

				switch(seed % 3)
				{
					case 0:
						status = "Awake";
						break;
					case 1:
						status = "Sleeping";
						break;
					case 2:
						status = "Running";
						break;
				}

				await endpoint.Send(new DataCollection { DeviceId = deviceId, Status = status });
				Console.WriteLine($"status {status} sent");
				Thread.Sleep(10000);
			}
		}
	}
}
