using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.DataAccess
{
	public class SampleDataAccess : ISampleDataAccess
	{
		private readonly ISampleDbContext _db;

		public SampleDataAccess(ISampleDbContext db)
		{
			_db = db;
		}

		public async Task<int> InsertData(IEnumerable<FileData> newdata, CancellationToken token)
		{
			await _db.Data.AddRangeAsync(newdata, token);
			return await _db.SaveChangesAsync(true, token);
		}

		public IEnumerable<FileData> GetSampleData()
		{
			return _db.Data.ToList();
		}
	}
}
