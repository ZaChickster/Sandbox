using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sandbox.Messaging
{
	public class DataCollection : IDeviceStatus
	{
		public ObjectId Id { get; set; }
		public DateTime When { get; set; }
		public string DeviceId { get; set; }
		public string Status { get; set; }
	}
}
