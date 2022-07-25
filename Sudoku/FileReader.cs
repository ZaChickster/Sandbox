using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sandbox.Sudoku
{
	public interface IFileReader
	{
		List<string> ToList(string filename);
	}

	public class FileReader : IFileReader
	{
		public List<string> ToList(string filename)
		{
			return File.ReadAllLines(filename)?.ToList();
		}
	}
}
