﻿using MongoDB.Driver;
using Sandbox.Backend.Models;
using Sandbox.Messaging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sandbox.Backend.DataAccess
{
	public interface IMongoDbDataAccess
	{
		Task InsertDevice(Device device);
		Task<Device> GetDevice(string deviceId);
		Task PersistStatus(DataCollection message);
		Task<List<DataCollection>> GetDataForDevice(string deviceId);
	}


	public class MongoDbDataAccess : IMongoDbDataAccess
	{
		private IMongoDatabase _mongoDb;

		public MongoDbDataAccess()
		{
			IMongoClient client = new MongoClient("mongodb://localhost:27017");
			_mongoDb = client.GetDatabase("ams");
		}

		public async Task InsertDevice(Device device)
		{
			await _mongoDb.GetCollection<Device>("devices").InsertOneAsync(device);
		}

		public async Task<Device> GetDevice(string deviceId)
		{
			var result = await _mongoDb
				.GetCollection<Device>("devices")
				.FindAsync(d => d.Id == deviceId);

			return result.FirstOrDefault();
		}

		public async Task PersistStatus(DataCollection message)
		{
			await _mongoDb.GetCollection<DataCollection>("devicestatus").InsertOneAsync(message);
		}

		public async Task<List<DataCollection>> GetDataForDevice(string deviceId)
		{
			var result = await _mongoDb
				.GetCollection<DataCollection>("devicestatus")
				.FindAsync(d => d.DeviceId == deviceId);

			return result.ToList();
		}
	}
}
