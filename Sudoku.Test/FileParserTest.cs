using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Sudoku.Test
{
    public class FileParserTest
    {
        private readonly FileParser _parser;
        private readonly Mock<IFileReader> _reader;
        private const string TEST_FILENAME = "c:/test/test.txt";

        public FileParserTest()
        {
            _reader = new Mock<IFileReader>();
            _parser = new FileParser(_reader.Object);
        }

        [Fact]
        public void LoadFile_Should_Throw_Exception_Null_Filename()
        {
            var ex = Assert.Throws<Exception>(() => _parser.LoadFile(null));

            Assert.Contains(FileParser.MISSING_FILENAME, ex.Message);
        }

        [Fact]
        public void LoadFile_Should_Throw_Exception_Empty_Filename()
        {
            var ex = Assert.Throws<Exception>(() => _parser.LoadFile(new[] { "   " }));

            Assert.Contains(FileParser.MISSING_FILENAME, ex.Message);
        }

        [Fact]
        public void LoadFile_Should_Load_Correct_Number_Of_Lines()
        {
            _reader.Setup(r => r.ToList(TEST_FILENAME)).Returns(new List<string> { "a", "a", "a", "a", "a", "a", "a", "a", "a" });
            var lines = _parser.LoadFile(new[] { TEST_FILENAME });

            Assert.Equal(9, lines.Count);
        }

        [Fact]
        public void LoadFile_Should_Not_Load_Bad_Row_Too_Long()
        {
            _reader.Setup(r => r.ToList(TEST_FILENAME)).Returns(new List<string> { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a" });
            var ex = Assert.Throws<Exception>(() => _parser.LoadFile(new[] { TEST_FILENAME }));

            Assert.Equal(FileParser.FILE_TOO_LONG, ex.Message);
        }

        [Fact]
        public void LoadFile_Should_Not_Load_Bad_Row_Non_Numeric()
        {
            _reader.Setup(r => r.ToList(TEST_FILENAME)).Returns(new List<string> { "a", "a", "a", "a", "a", "a", "a" });
            var ex = Assert.Throws<Exception>(() => _parser.LoadFile(new[] { TEST_FILENAME }));

            Assert.Equal(FileParser.FILE_TOO_SHORT, ex.Message);
        }

        [Fact]
        public void ParseRow_Should_Parse_Good_Row_Spaces()
        {
            List<int> read = _parser.ParseRow("4 1 7 3 6 9 8 2 5");

            Assert.Equal(9, read.Count);
            Assert.Equal(4, read[0]);
            Assert.Equal(5, read[8]);
            Assert.Equal(6, read[4]);
        }

        [Fact]
        public void ParseRow_Should_Not_Parse_Bad_Row_Spaces_With_Zero()
        {
            var ex = Assert.Throws<Exception>(() => _parser.ParseRow("4 1 7 3 0 9 8 2 5"));

            Assert.Contains(FileParser.BAD_ROW, ex.Message);
        }

        [Fact]
        public void ParseRow_Should_Parse_Good_Row_Tabs()
        {
            List<int> read = _parser.ParseRow("4	1	7	3	6	9	8	2	5");

            Assert.Equal(9, read.Count);
            Assert.Equal(4, read[0]);
            Assert.Equal(5, read[8]);
            Assert.Equal(6, read[4]);
        }

        [Fact]
        public void ParseRow_Should_Parse_Good_Row_Mixed()
        {
            List<int> read = _parser.ParseRow("4	1 7	3	6 9	8	2	5");

            Assert.Equal(9, read.Count);
            Assert.Equal(4, read[0]);
            Assert.Equal(5, read[8]);
            Assert.Equal(6, read[4]);
        }

        [Fact]
        public void ParseRow_Should_Not_Parse_Bad_Row_Too_Long()
        {
            var ex = Assert.Throws<Exception>(() => _parser.ParseRow("4 1 7 3 6 9 8 2 5 9 1"));

            Assert.Contains(FileParser.BAD_ROW, ex.Message);
        }

        [Fact]
        public void ParseRow_Should_Not_Parse_Bad_Row_Non_Numeric()
        {
            var ex = Assert.Throws<Exception>(() => _parser.ParseRow("4 1 a 3 6 . 8 2 5"));

            Assert.Contains(FileParser.BAD_ROW, ex.Message);
        }
    }
}
