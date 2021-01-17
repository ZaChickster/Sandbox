using MassTransit;
using Messaging;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AngularUX.Controllers
{
	[Route("api/[controller]")]
	public class DeviceController : Controller
	{
		private readonly IBusControl _busControl;

        public DeviceController(IBusControl endpoint)
        {
            _busControl = endpoint;
        }

        [HttpPost("{deviceId}/assign")]
        public async Task<IActionResult> Assign(string deviceId, CancellationToken token)
        {
            await _busControl.StartAsync(token);

            try
            {
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

            return Ok();
        }
    }
}
