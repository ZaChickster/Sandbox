using CsvHelper.Configuration;

namespace Sandbox.Backend.Models
{
	public sealed class FileDataMap : ClassMap<FileData>
	{
		public FileDataMap()
		{
			Map(m => m.EmailAddress).Name("Email Address");
			Map(m => m.FirstName).Name("First Name");
			Map(m => m.LastName).Name("Last Name");
		}
	}
}
