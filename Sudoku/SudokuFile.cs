using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    public class SudokuFile
    {
        private List<List<int>> _rawData;

        public string FileName { get; private set; }

        public SudokuFile(string filename)
        {
            FileName = filename;
            _rawData = new List<List<int>>();
        }

        public SudokuFile AddRow(List<int> row)
        {
            _rawData.Add(row);
            return this;
        }

        public SudokuFile Validate()
        {
            return this;
        }
    }
}
