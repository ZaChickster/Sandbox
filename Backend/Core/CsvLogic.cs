﻿using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using Sandbox.Backend.DataAccess;
using Sandbox.Backend.Models;

namespace Backend.Core
{
	public interface ICsvLogic
	{
		Task<int> InsertCsvData(Stream file, CancellationToken token);
		Task<IEnumerable<FileData>> GetData(CancellationToken token);
	}

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
			var config = new CsvConfiguration(CultureInfo.InvariantCulture)
			{
				HasHeaderRecord = true
			};

			using (StreamReader reader = new StreamReader(file))
			using (var csv = new CsvReader(reader, config))
			{
				csv.Context.RegisterClassMap<FileDataMap>();
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
