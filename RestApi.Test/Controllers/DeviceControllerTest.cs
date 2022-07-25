using Moq;
using System.Threading.Tasks;
using Xunit;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using System;
using Sandbox.Messaging;
using Sandbox.RestApi.Controllers;
using Sandbox.Backend.DataAccess;
using Sandbox.Backend.Models;

namespace Sandbox.AngularUX.Test.Controllers
{
	public class DeviceControllerTest
	{
		private readonly Mock<IRabbitMqAbstraction> _rabbitMock;
		private readonly Mock<IMongoDbDataAccess> _mongoMock;
		private readonly DeviceController _controller;

		public DeviceControllerTest()
		{
			_rabbitMock = new Mock<IRabbitMqAbstraction>();
			_mongoMock = new Mock<IMongoDbDataAccess>();
			_controller = new DeviceController(_rabbitMock.Object, _mongoMock.Object);
		}

		[Fact]
		public async Task Assign_Should_Return_Ok_When_Tasks_Complete_Normally()
		{
			string deviceId = "testDeviceId";
			CancellationToken token = new CancellationToken();

			_rabbitMock.Setup(r => r.SendAssignDeviceMsg(deviceId, token)).Returns(Task.CompletedTask);
			_mongoMock.Setup(m => m.InsertDevice(It.IsAny<Device>())).Returns(Task.CompletedTask);

			var result = await _controller.Assign(deviceId, token);

			Assert.True(result is OkObjectResult);
		}

		[Fact]
		public async Task Assign_Should_Return_BadRequest_When_Send_Message_Errors()
		{
			string deviceId = "testDeviceId";
			CancellationToken token = new CancellationToken();
			Exception boom = new Exception("boom");

			_rabbitMock.Setup(r => r.SendAssignDeviceMsg(deviceId, token)).ThrowsAsync(boom);
			_mongoMock.Setup(m => m.InsertDevice(It.IsAny<Device>())).Returns(Task.CompletedTask);

			var result = await _controller.Assign(deviceId, token);

			Assert.True(result is BadRequestObjectResult);
		}

		[Fact]
		public async Task Assign_Should_Return_BadRequest_When_Add_Mongo_Errors()
		{
			string deviceId = "testDeviceId";
			CancellationToken token = new CancellationToken();
			Exception boom = new Exception("boom");

			_rabbitMock.Setup(r => r.SendAssignDeviceMsg(deviceId, token)).Returns(Task.CompletedTask);
			_mongoMock.Setup(m => m.InsertDevice(It.IsAny<Device>())).ThrowsAsync(boom);

			var result = await _controller.Assign(deviceId, token);

			Assert.True(result is BadRequestObjectResult);
		}

		[Fact]
		public async Task Message_Should_Return_Ok_When_Tasks_Complete_Normally()
		{
			string deviceId = "testDeviceId";
			CancellationToken token = new CancellationToken();

			_rabbitMock.Setup(r => r.SendAssignDeviceMsg(deviceId, token)).Returns(Task.CompletedTask);
			_mongoMock.Setup(m => m.GetDevice(deviceId)).ReturnsAsync(new Device { Id = deviceId});

			var result = await _controller.Message(deviceId, "sent message", token);

			Assert.True(result is OkObjectResult);
		}

		[Fact]
		public async Task Message_Should_Return_BadRequest_When_Send_Message_Errors()
		{
			string deviceId = "testDeviceId";
			string sentMessage = "sent message";
			CancellationToken token = new CancellationToken();
			Exception boom = new Exception("boom");

			_rabbitMock.Setup(r => r.SendDeviceMessage(deviceId, sentMessage, token)).ThrowsAsync(boom);
			_mongoMock.Setup(m => m.GetDevice(deviceId)).ReturnsAsync(new Device { Id = deviceId });

			var result = await _controller.Message(deviceId, sentMessage, token);

			Assert.True(result is BadRequestObjectResult);
		}

		[Fact]
		public async Task Message_Should_Return_NotFound_When_Message_Errors()
		{
			string deviceId = "testDeviceId";
			CancellationToken token = new CancellationToken();
			Device device = null;

			_mongoMock.Setup(m => m.GetDevice(deviceId)).ReturnsAsync(device);

			var result = await _controller.Message(deviceId, "sent message", token);

			Assert.True(result is NotFoundObjectResult);
		}
	}
}
