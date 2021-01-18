namespace Sandbox.Messaging
{
	public interface IDeviceStatus
	{
		string DeviceId { get; set; }
		string Status { get; set; }
	}

	public class DeviceStatus : IDeviceStatus
	{
		public const string QUEUE_NAME_FORMAT = "device-{0}-q";

		public string DeviceId { get; set; }
		public string Status { get; set; }
	}
}
