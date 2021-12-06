using MassTransit;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Sandbox.Backend.DataAccess;
using Sandbox.Messaging;
using Sandbox.RestApi.SignalR;
using System;
using System.Threading.Tasks;

namespace Sandbox.RestApi.Consumer
{
	public interface IDataCollectionConsumer : IConsumer<DataCollection> { }
	
	public class DataCollectionConsumer : IDataCollectionConsumer
	{
		private readonly IMongoDbDataAccess _mongoDb;
		private readonly IServiceProvider _provider;

		public DataCollectionConsumer(IMongoDbDataAccess mongo, IServiceProvider sp) 
		{ 
			_mongoDb = mongo;
			_provider = sp;
		}

		public async Task Consume(ConsumeContext<DataCollection> context)
		{
			Console.WriteLine($"Device {context.Message.DeviceId} submitted status {context.Message.Status}.");

			await _mongoDb.PersistStatus(context.Message);

            IHubContext<BasicHub> hub = _provider.GetService<IHubContext<BasicHub>>();
			await hub.Clients.All.SendAsync("messageRecieved", new { status = context.Message.Status, deviceId = context.Message.DeviceId });
		}
	}
}
