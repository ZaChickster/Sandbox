using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku
{
    public class FileReader
    {
        public const string WRONG_LENGTH = "invalid row size";
        public const string NON_NUMERIC = "row contains non-numeric chars";

        public string FileName { get; set; }

        public List<int> ParseRow(string row)
        {
            char[] onlyNumbers = row.Where(c => char.IsDigit(c)).ToArray();
            char[] nowhitespace = row.Where(c => !char.IsWhiteSpace(c)).ToArray();

            if (new string(onlyNumbers) != new string(nowhitespace))
                throw new Exception(NON_NUMERIC);

            if (onlyNumbers.Length != 9)
                throw new Exception(WRONG_LENGTH);

            return onlyNumbers.Select(c => int.Parse(c.ToString())).ToList();
        }
    }
}
