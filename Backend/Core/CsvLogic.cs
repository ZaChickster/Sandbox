using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Backend.Models;
using CsvHelper;
using CsvHelper.Configuration;

namespace Backend.Core
{
	public class CsvLogic
	{
		private readonly Configuration _configuration = new Configuration
		{
			HasHeaderRecord = true
		};

		public CsvLogic()
		{
			_configuration.RegisterClassMap<FileDataMap>();
		}

		public int InsertCsvData(Stream file)
		{
			IEnumerable<FileData> records = ReadFile(file);
			return records?.Count() ?? 0;
		}

		public IEnumerable<FileData> ReadFile(Stream file)
		{
			using (StreamReader reader = new StreamReader(file))
			using (var csv = new CsvReader(reader, _configuration))
			{
				return csv.GetRecords<FileData>().ToList();
			}
		}
	}
}
