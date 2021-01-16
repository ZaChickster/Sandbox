using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

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
			
			try
			{
				return await _db.SaveChangesAsync(true, token);
			}
			catch(Exception e)
			{
				throw new Exception("Issue with SqlLite DB.  Did you copy {repo root}/Backend/sample.db to C:/data?", e);
			}
		}

		public async Task<IEnumerable<FileData>> GetSampleData(CancellationToken token)
		{
			return await _db.Data.ToListAsync(token);
		}

		public void Dispose()
		{
			_db?.Dispose();
		}
	}
}
