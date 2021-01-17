using MassTransit;
using Messaging;
using System;
using System.Threading.Tasks;

namespace ConsoleDevice
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

				sbc.ReceiveEndpoint(string.Format(DeviceStatus.QUEUE_NAME_FORMAT, deviceId), ep =>
				{
					ep.Handler<IDeviceStatus>(context =>
					{
						return Console.Out.WriteLineAsync($"Device {context.Message.DeviceId} should now have status {context.Message.Status}.");
					});
				});
			});

			await bus.StartAsync(); // This is important!

			Console.WriteLine($"DeviceID {deviceId} was entered.  Press any key to continue ...");
			Console.ReadLine();
		}
	}
}
