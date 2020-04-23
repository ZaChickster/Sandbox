using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku
{
    public interface IFileParser
    {
        string FileName { get; }
        SudokuFile ParseFile(string[] args);
    }

    public class FileParser : IFileParser
    {
        public const string BAD_ROW = "row does not contain 9 non-zero integers";
        public const string MISSING_FILENAME = "missing filename argument";
        public const string FILE_TOO_LONG = "too many rows in file";
        public const string FILE_TOO_SHORT = "too few rows in file";

        private readonly IFileReader _reader;

        public string FileName { get; private set; }

        public FileParser(IFileReader reader)
        {
            _reader = reader;
        }

        public List<string> LoadFile(string[] args)
        {
            if (args == null || args.Length < 1 || string.IsNullOrWhiteSpace(args[0]))
            {
                throw new Exception(MISSING_FILENAME);
            }

            FileName = args[0];
            List<string> lines = _reader.ToList(FileName);

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

        public SudokuFile ParseFile(string[] args)
        {
            List<string> lines = LoadFile(args);
            SudokuFile file = new SudokuFile();

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

            if (onlyNumbers.Length != 9)
                throw new Exception($"{BAD_ROW}: '{row}'");

            return onlyNumbers.Select(c => int.Parse(c.ToString())).ToList();
        }
    }
}
