using System;

namespace Sandbox.Messaging
{
	public interface IDeviceStatus
	{
		string DeviceId { get; set; }
		string Status { get; set; }
		DateTime When { get; set; }
	}
}
