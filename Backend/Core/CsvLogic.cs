using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backend.DataAccess;
using Backend.Models;
using CsvHelper;
using CsvHelper.Configuration;

namespace Backend.Core
{
	public class CsvLogic : ICsvLogic
	{
		private readonly ISampleDataAccess _data;

		public CsvLogic(ISampleDataAccess data)
		{
			_data = data;			
		}

		public async Task<int> InsertCsvData(Stream file, CancellationToken token)
		{
			using (_data)
			{
				IEnumerable<FileData> records = ReadFile(file);
				return await _data.InsertData(records, token);
			}
		}

		public IEnumerable<FileData> ReadFile(Stream file)
		{
			using (StreamReader reader = new StreamReader(file))
			using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
			{
				csv.Configuration.RegisterClassMap<FileDataMap>();
				csv.Configuration.HasHeaderRecord = true;
				return csv.GetRecords<FileData>().ToList();
			}
		}

		public async Task<IEnumerable<FileData>> GetData(CancellationToken token)
		{
			using (_data)
			{
				return await _data.GetSampleData(token);
			}
		}
	}
}
