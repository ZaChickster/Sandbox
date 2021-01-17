using MassTransit;
using System;

namespace ConsoleDevice
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Please Enter Device ID:");
			string deviceID = Console.ReadLine();

			var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
			{
				cfg.Host("localhost", "/", h =>
				{
					h.Username("localuser");
					h.Password("localuser");
				});
			});

			Console.WriteLine($"DeviceID {deviceID} was entered.  Press any key to continue ...");
			Console.ReadLine();
		}
	}
}
