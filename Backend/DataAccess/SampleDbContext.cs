using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.DataAccess
{
	public class SampleDbContext : DbContext, ISampleDbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			// don't like this but don't want to go down the .NET Core configuration rabbit hole.
			// since i wanted to test data access from a class library best to but connection string here.
			optionsBuilder.UseSqlite("Data Source=C:/data/sample.db");
		}

		public DbSet<FileData> Data { get; set; }
	}
}
