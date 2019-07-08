using System.Threading;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.DataAccess
{
	public interface ISampleDbContext
	{
		DbSet<FileData> Data { get; set; }
		Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken);
	}
}