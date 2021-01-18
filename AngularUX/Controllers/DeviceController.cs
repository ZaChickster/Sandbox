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
		private readonly IRabbitMqAbstraction _rabbitMq;

        public DeviceController(IRabbitMqAbstraction rabbit)
        {
            _rabbitMq = rabbit;
        }

        [HttpPost("{deviceId}/assign")]
        public async Task<IActionResult> Assign(string deviceId, CancellationToken token)
        {
			try
			{
                await _rabbitMq.SendAssignDeviceMsg(deviceId, token);
                return Ok();
            }
            catch(Exception e)
			{
                return BadRequest(e);
			}
        }
    }
}
