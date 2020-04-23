using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku
{
    public class FileReader
    {
        public string FileName { get; set; }

        public List<int> ParseRow(string row)
        {
            char[] onlyNumbers = row.Where(c => char.IsDigit(c)).ToArray();
            char[] nowhitespace = row.Where(c => !char.IsWhiteSpace(c)).ToArray();

            if (onlyNumbers.Length != 9)
                throw new Exception("invalid row size");

            if (new string(onlyNumbers) != new string(nowhitespace))
                throw new Exception("row contains non-numeric chars");

            return onlyNumbers.Select(c => int.Parse(c.ToString())).ToList();
        }
    }
}
