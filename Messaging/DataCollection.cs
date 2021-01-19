using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sandbox.Messaging
{
	public class DataCollection
	{
		public ObjectId Id { get; set; }
		public string DeviceId { get; set; }
		public string Status { get; set; }
	}
}
