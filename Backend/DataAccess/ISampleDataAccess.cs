using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.DataAccess
{
	public interface ISampleDataAccess : IDisposable
	{
		Task<int> InsertData(IEnumerable<FileData> newdata, CancellationToken token);
		Task<IEnumerable<FileData>> GetSampleData(CancellationToken token);
	}
}