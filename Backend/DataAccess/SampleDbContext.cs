using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.DataAccess
{
	public class SampleDbContext : DbContext, ISampleDbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source=sample.db");
		}

		public DbSet<FileData> Data { get; set; }
	}
}
