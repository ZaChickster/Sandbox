using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku
{
    public class SudokuFile
    {
        private List<List<int>> _rawData;

        public string FileName { get; private set; }

        public SudokuFile(string filename) : this(filename, new List<List<int>>()) { }

        public SudokuFile(string filename, List<List<int>> data)
        {
            FileName = filename;
            _rawData = data;
        }

        public SudokuFile AddRow(List<int> row)
        {
            _rawData.Add(row);
            return this;
        }

        public SudokuFile Validate()
        {
            for(int i = 0; i < 9; i++)
            {
                ValidateRow(i);
                ValidateColumn(i);
            }

            ValidateCube(0, 0);
            ValidateCube(3, 0);
            ValidateCube(6, 0);
            ValidateCube(0, 3);
            ValidateCube(3, 3);
            ValidateCube(6, 3);
            ValidateCube(0, 6);
            ValidateCube(3, 6);
            ValidateCube(6, 6);

            return this;
        }

        public SudokuFile ValidateRow(int i)
        {
            return ValidateSection(_rawData[i], $"row {i}");
        }

        public SudokuFile ValidateColumn(int i)
        {
            List<int> columnInts = new List<int>();
            _rawData.ForEach(r => columnInts.Add(r[i]));

            return ValidateSection(columnInts, $"column {i}");
        }

        public SudokuFile ValidateCube(int startX, int startY)
        {
            List<int> columnInts = new List<int>
            {
                _rawData[startX][startY],
                _rawData[startX][startY + 1],
                _rawData[startX][startY + 2],
                _rawData[startX + 1][startY],
                _rawData[startX + 1][startY + 1],
                _rawData[startX + 1][startY + 2],
                _rawData[startX + 2][startY],
                _rawData[startX + 2][startY + 1],
                _rawData[startX + 2][startY + 2]
            };

            return ValidateSection(columnInts, $"cube ({startX}, {startY})");
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
