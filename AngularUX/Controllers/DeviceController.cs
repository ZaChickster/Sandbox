using MassTransit;
using Messaging;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace AngularUX.Controllers
{
	[Route("api/[controller]")]
	public class DeviceController : Controller
	{
		private readonly IPublishEndpoint _endpoint;

        public DeviceController(IPublishEndpoint endpoint)
        {
            _endpoint = endpoint;
        }

        [HttpPost("{deviceId}/assign")]
        public async Task<IActionResult> Assign(string deviceId, CancellationToken token)
        {
            await _endpoint.Publish<IDeviceStatus>(new DeviceStatus
            {
                DeviceId = deviceId,
                Status = "Assigned"

            }, token);

            return Ok();
        }
    }
}
