namespace Sandbox.Messaging
{
	public interface IDeviceStatus
	{
		string DeviceId { get; set; }
		string Status { get; set; }
	}

	public class DeviceStatus : IDeviceStatus
	{
		public string DeviceId { get; set; }
		public string Status { get; set; }
	}
}
