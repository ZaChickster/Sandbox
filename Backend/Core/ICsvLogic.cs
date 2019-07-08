using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Core
{
	public interface ICsvLogic
	{
		Task<int> InsertCsvData(Stream file, CancellationToken token);
		Task<IEnumerable<FileData>> GetData(CancellationToken token);
	}
}