using Microsoft.EntityFrameworkCore;
using Sandbox.Backend.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sandbox.Backend.DataAccess
{
	public interface ISampleDbContext : IDisposable
	{
		DbSet<FileData> Data { get; set; }
		Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken);
	}

	public class SampleDbContext : DbContext, ISampleDbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			// don't like this but don't want to go down the .NET Core configuration rabbit hole.
			// since i wanted to test data access from a class library best to put connection string here.
			optionsBuilder.UseSqlite("Data Source=C:/data/sample.db");
		}

		public DbSet<FileData> Data { get; set; }
	}
}
