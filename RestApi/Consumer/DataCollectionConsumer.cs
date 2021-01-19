using MassTransit;
using Sandbox.Backend.DataAccess;
using Sandbox.Messaging;
using System;
using System.Threading.Tasks;

namespace Sandbox.RestApi.Consumer
{
	public class DataCollectionConsumer : IConsumer<DataCollection>
	{
		private readonly IMongoDbDataAccess _mongoDb;
		
		public DataCollectionConsumer() : this(new MongoDbDataAccess()) { }

		public DataCollectionConsumer(IMongoDbDataAccess mongo) 
		{ 
			_mongoDb = mongo; 
		}

		public async Task Consume(ConsumeContext<DataCollection> context)
		{
			Console.WriteLine($"Device {context.Message.DeviceId} submitted status {context.Message.Status}.");

			await _mongoDb.PersistStatus(context.Message);
		}
	}
}
