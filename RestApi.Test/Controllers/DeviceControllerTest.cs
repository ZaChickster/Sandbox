using Moq;
using System.Threading.Tasks;
using Xunit;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using System;
using Sandbox.Messaging;
using Sandbox.RestApi.Controllers;

namespace Sandbox.AngularUX.Test.Controllers
{
	public class DeviceControllerTest
	{
		private readonly Mock<IRabbitMqAbstraction> _rabbitMock;
		private readonly DeviceController _controller;

		public DeviceControllerTest()
		{
			_rabbitMock = new Mock<IRabbitMqAbstraction>();
			_controller = new DeviceController(_rabbitMock.Object);
		}

		[Fact]
		public async Task Assign_Should_Return_Ok_When_Send_Message_Completes_Normally()
		{
			string deviceId = "testDeviceId";
			CancellationToken token = new CancellationToken();

			_rabbitMock.Setup(r => r.SendAssignDeviceMsg(deviceId, token)).Returns(Task.CompletedTask);

			var result = await _controller.Assign(deviceId, token);

			Assert.True(result is OkResult);
		}

		[Fact]
		public async Task Assign_Should_Return_BadRequest_When_Send_Message_Errors()
		{
			string deviceId = "testDeviceId";
			CancellationToken token = new CancellationToken();
			Exception boom = new Exception("boom");

			_rabbitMock.Setup(r => r.SendAssignDeviceMsg(deviceId, token)).ThrowsAsync(boom);

			var result = await _controller.Assign(deviceId, token);

			Assert.True(result is BadRequestObjectResult);
		}
	}
}
