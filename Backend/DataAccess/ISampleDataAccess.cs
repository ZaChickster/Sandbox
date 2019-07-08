using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.DataAccess
{
	public interface ISampleDataAccess
	{
		Task<int> InsertData(IEnumerable<FileData> newdata, CancellationToken token);
		IEnumerable<FileData> GetSampleData();
	}
}