using System;

namespace ConsoleDevice
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Please Enter Device ID:");

			string deviceID = Console.ReadLine();

			Console.WriteLine($"DeviceID {deviceID} was entered.  Press any key to continue ...");

			Console.ReadLine();
		}
	}
}
