using System;
using System.Collections.Generic;
using System.Linq;

namespace Sandbox.Sudoku
{
	public class SudokuFile
	{
		private List<List<int>> _rawData;

		public SudokuFile() : this(new List<List<int>>()) { }

		public SudokuFile(List<List<int>> data)
		{
			_rawData = data;
		}

		public SudokuFile AddRow(List<int> row)
		{
			_rawData.Add(row);
			return this;
		}

		// Combinations of these three values constitue 
		// the upper left corner of each cube section of 
		// the Sudoku board.  Other 8 values are calculated.
		private static readonly int[] _cubeIndicies = { 0, 3, 6 };

		public SudokuFile Validate()
		{
			for (int i = 0; i < 9; i++)
			{
				ValidateRow(i);
				ValidateColumn(i);
			}

			foreach (int x in _cubeIndicies)
			{
				foreach (int y in _cubeIndicies)
				{
					ValidateCube(x, y);
				}
			}

			return this;
		}

		public SudokuFile ValidateRow(int i)
		{
			return ValidateSection(_rawData[i], $"row {i + 1}");
		}

		public SudokuFile ValidateColumn(int i)
		{
			List<int> columnInts = new List<int>();
			_rawData.ForEach(r => columnInts.Add(r[i]));

			return ValidateSection(columnInts, $"column {i + 1}");
		}

		public SudokuFile ValidateCube(int startX, int startY)
		{
			List<int> columnInts = new List<int>();

			// starting from upper left of cube to validate,
			// find the other eight values; aka two columns over
			// and two rows down.
			for (int x = 0; x < 3; x++)
			{
				for (int y = 0; y < 3; y++)
				{
					columnInts.Add(_rawData[startX + x][startY + y]);
				}
			}

			return ValidateSection(columnInts, $"cube ({startX + 1}, {startY + 1})");
		}

		private SudokuFile ValidateSection(List<int> columnInts, string message)
		{
			string rowStr = string.Join("", columnInts);

			int uniqueInts = rowStr.Distinct().Count();

			if (uniqueInts != 9)
			{
				throw new Exception($"duplicate number found in {message}");
			}

			return this;
		}
	}
}
