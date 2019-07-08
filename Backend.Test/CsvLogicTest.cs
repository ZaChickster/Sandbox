using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Backend.Core;
using Backend.Models;
using FluentAssertions;
using Xunit;

namespace Backend.Test
{
	public class CsvLogicTest
	{
		private readonly CsvLogic _logic;

		public CsvLogicTest()
		{
			_logic = new CsvLogic(null);
		}

		[Fact]
		public void ReadFile_Should_ReadFile()
		{
			using (Stream stream = File.OpenRead("fixtures/sample.csv"))
			{
				IEnumerable<FileData> records = _logic.ReadFile(stream);

				records.Count().Should().BeGreaterThan(0);
			}
		}
	}
}
