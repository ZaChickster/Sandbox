using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sudoku
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
