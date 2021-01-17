using MassTransit;
using Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDevice
{
	public class ActivateConsumer : IConsumer<IDeviceStatus>
	{
		public Task Consume(ConsumeContext<IDeviceStatus> context)
		{
			Console.WriteLine($"Device {context.Message.DeviceId} should now have status {context.Message.Status}.");
			return Task.CompletedTask;
		}
	}
}
