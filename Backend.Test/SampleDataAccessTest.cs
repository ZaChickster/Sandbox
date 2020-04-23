using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backend.DataAccess;
using Backend.Models;
using FluentAssertions;
using Xunit;

namespace Backend.Test
{
	public class SampleDataAccessTest
	{
		private readonly SampleDbContext _db;
		private readonly SampleDataAccess _data;

		public SampleDataAccessTest()
		{
			_db = new SampleDbContext();
			_data = new SampleDataAccess(_db);
		}

		[Fact]
		public async Task Should_Put_Data_In_And_Take_It_Out()
		{
			int done = await _data.InsertData(new List<FileData>
			{
				new FileData { EmailAddress = "fdsa@fdsa.com", FirstName = "fdsa", LastName = "fdsa"},
				new FileData { EmailAddress = "asdf@asdf.com", FirstName = "asdf", LastName = "asdf"}
			}, CancellationToken.None);

			done.Should().Be(2);

			IEnumerable<FileData> records = await _data.GetSampleData(CancellationToken.None);

			records.Count().Should().BeGreaterThan(0);
			records.Count(f => f.UniqueId <= 0).Should().Be(0);
		}
	}
}
