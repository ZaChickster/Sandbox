using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sudoku
{
    public class FileParser
    {
        public const string WRONG_ROW_LENGTH = "invalid row size";
        public const string NON_NUMERIC = "row contains non-numeric chars or zeros";
        public const string FILE_TOO_LONG = "too many rows in file";
        public const string FILE_TOO_SHORT = "too few rows in file";

        private readonly IFileReader _reader;

        public FileParser(IFileReader reader)
        {
            _reader = reader;
        }

        public List<string> LoadFile(string filename)
        {
            var lines = _reader.ToList(filename);

            if (lines == null || lines.Count < 9)
            {
                throw new Exception(FILE_TOO_SHORT);
            }

            if (lines.Count > 9)
            {
                throw new Exception(FILE_TOO_LONG);
            }

            return lines;
        }

        public SudokuFile ParseFile(string filename)
        {
            var lines = LoadFile(filename);
            var file = new SudokuFile(filename);

            foreach (string l in lines)
            {
                if (!string.IsNullOrWhiteSpace(l))
                    file.AddRow(ParseRow(l));
            }

            return file;
        }

        public List<int> ParseRow(string row)
        {
            char[] onlyNumbers = row.Where(c => char.IsDigit(c) && int.Parse(c.ToString()) > 0).ToArray();
            char[] nowhitespace = row.Where(c => !char.IsWhiteSpace(c)).ToArray();

            if (new string(onlyNumbers) != new string(nowhitespace))
                throw new Exception(NON_NUMERIC);

            if (onlyNumbers.Length != 9)
                throw new Exception(WRONG_ROW_LENGTH);

            return onlyNumbers.Select(c => int.Parse(c.ToString())).ToList();
        }
    }
}
