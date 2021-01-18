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

	public class RabbitMqAbstraction
	{
		private readonly IBusControl _busControl;

		public RabbitMqAbstraction(IBusControl endpoint)
		{
			_busControl = endpoint;
		}

		public async Task SendAssignDeviceMsg(string deviceId, CancellationToken token)
		{
			try
			{
				await _busControl.StartAsync(token);

				var endpoint = await _busControl.GetSendEndpoint(new Uri($"queue:{string.Format(DeviceStatus.QUEUE_NAME_FORMAT, deviceId)}"));

				await endpoint.Send<IDeviceStatus>(new DeviceStatus
				{
					DeviceId = deviceId,
					Status = "Assigned"
				});
			}
			finally
			{
				await _busControl.StopAsync();
			}
		}

	}
}
