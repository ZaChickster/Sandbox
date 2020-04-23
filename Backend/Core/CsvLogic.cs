using System.Collections.Generic;
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

		private readonly Configuration _configuration = new Configuration
		{
			HasHeaderRecord = true
		};

		public CsvLogic(ISampleDataAccess data)
		{
			_data = data;
			_configuration.RegisterClassMap<FileDataMap>();
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
			using (var csv = new CsvReader(reader, _configuration))
			{
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
