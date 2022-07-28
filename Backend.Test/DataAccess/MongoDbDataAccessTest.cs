using Sandbox.Backend.DataAccess;
using Sandbox.Backend.Models;
using Sandbox.Messaging;
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

		[Fact]
		public async Task GetStatusData_Should_Get_List_From_Mongo()
		{
			List<DataCollection> pulled = await _mongoDb.GetStatusData(5);

			Assert.True(pulled.Count == 5);
		}

		[Fact]
        public async Task PersistStatus_Should_Get_Add_To_Collection()
        {
            long before = await _mongoDb.GetStatusDataCount();
            
            await _mongoDb.PersistStatus(new DataCollection
            {
                DeviceId = Guid.NewGuid().ToString(),
				Status = "For Testing",
				When = DateTime.UtcNow

			});

            long after = await _mongoDb.GetStatusDataCount();

            Assert.True(after > before);
        }
	}
}
