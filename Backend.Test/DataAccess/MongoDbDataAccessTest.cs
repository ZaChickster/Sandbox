using Sandbox.Backend.DataAccess;
using Sandbox.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sandbox.Backend.Test.DataAccess
{
	public class MongoDbDataAccessTest
	{
		private readonly MongoDbDataAccess _mongoDb;

		public MongoDbDataAccessTest()
		{
			_mongoDb = new MongoDbDataAccess();
		}

		[Fact]
		public async Task InsertDevice_Should_Persist_Device_To_Mongo()
		{
			Device device = new Device { Id = Guid.NewGuid().ToString(), Name = Guid.NewGuid().ToString(), Status = "New" };

			await _mongoDb.InsertDevice(device);

			Device pulled = await _mongoDb.GetDevice(device.Id);

			Assert.Equal(device.Name, pulled.Name);
		}
	}
}
