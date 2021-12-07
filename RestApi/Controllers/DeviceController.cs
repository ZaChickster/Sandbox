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
	[Route("api/device")]
	public class DeviceController : Controller
	{
		private readonly IRabbitMqAbstraction _rabbitMq;
		private readonly IMongoDbDataAccess _mongoDb;

		public DeviceController(IRabbitMqAbstraction rabbit, IMongoDbDataAccess mongo)
		{
			_rabbitMq = rabbit;
			_mongoDb = mongo;
		}

		[HttpGet("{deviceId}/assign")]
		public async Task<IActionResult> Assign(string deviceId, CancellationToken token)
		{
			try
			{
				List<Task> tasks = new List<Task>();
				tasks.Add(_rabbitMq.SendAssignDeviceMsg(deviceId, token));
				tasks.Add(_mongoDb.InsertDevice(new Device { Id = deviceId, Name = $"Device {deviceId}", Status = "New" }));

				await Task.WhenAll(tasks);

				return Ok(1);
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
		}

		[HttpGet("{deviceId}/sendmessage")]
		public async Task<IActionResult> Message(string deviceId, [FromQuery] string message, CancellationToken token)
		{
			try
			{
				await _rabbitMq.SendDeviceMessage(deviceId, message, token);

				return Ok(1);
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
		}

		[HttpGet("{deviceId}")]
		public async Task<IActionResult> GetDevice(string deviceId)
		{
			try
			{
				Device d = await _mongoDb.GetDevice(deviceId);

				if (d == null)
					return NotFound();

				return Ok(d);
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
		}

		[HttpGet("{rowsToReturn}/datacollection")]
		public async Task<IActionResult> GetCollectedData(int rowsToReturn)
		{
			try
			{
				List<DataCollection> data = await _mongoDb.GetData(rowsToReturn);

				return Ok(data);
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
		}
	}
}
