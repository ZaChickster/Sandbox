using Microsoft.AspNetCore.Mvc;
using Sandbox.Backend.DataAccess;
using Sandbox.Backend.Models;
using Sandbox.Messaging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sandbox.RestApi.Controllers
{
	[Route("api/[controller]")]
	public class DeviceController : Controller
	{
		private readonly IRabbitMqAbstraction _rabbitMq;
		private readonly IMongoDbDataAccess _mongoDb;

		public DeviceController(IRabbitMqAbstraction rabbit, IMongoDbDataAccess mongo)
		{
			_rabbitMq = rabbit;
			_mongoDb = mongo;
		}

		[HttpPost("{deviceId}/assign")]
		public async Task<IActionResult> Assign(string deviceId, CancellationToken token)
		{
			try
			{
				List<Task> tasks = new List<Task>();
				tasks.Add(_rabbitMq.SendAssignDeviceMsg(deviceId, token));
				tasks.Add(_mongoDb.InsertDevice(new Device { Id = deviceId, Name = $"Device {deviceId}", Status = "New" }));

				await Task.WhenAll(tasks);

				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
		}
	}
}
