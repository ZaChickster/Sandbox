using MassTransit;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sandbox.Messaging
{
	public interface IRabbitMqAbstraction
	{
		Task SendAssignDeviceMsg(string deviceId, CancellationToken token);
	}

	public class RabbitMqAbstraction : IRabbitMqAbstraction
	{
		public const string QUEUE_NAME_FORMAT = "device-{0}-q";

		private readonly IBusControl _busControl;

		public RabbitMqAbstraction(IBusControl endpoint)
		{
			_busControl = endpoint;
		}

		public async Task SendAssignDeviceMsg(string deviceId, CancellationToken token)
		{
			var endpoint = await _busControl.GetSendEndpoint(new Uri($"queue:{string.Format(QUEUE_NAME_FORMAT, deviceId)}"));

			await endpoint.Send<IDeviceStatus>(new DeviceStatus
			{
				DeviceId = deviceId,
				Status = "Assigned"
			});
		}

	}
}
