using System;
using System.Collections.Generic;
using Xunit;

namespace Sudoku.Test
{
    public class FileReaderTest
    {
        private readonly FileReader _reader;

        public FileReaderTest()
        {
            _reader = new FileReader();
        }

        [Fact]
        public void Should_Parse_Good_Row_Spaces()
        {
            List<int> read = _reader.ParseRow("4 1 7 3 6 9 8 2 5");

            Assert.Equal(9, read.Count);
            Assert.Equal(4, read[0]);
            Assert.Equal(5, read[8]);
            Assert.Equal(6, read[4]);
        }

        [Fact]
        public void Should_Parse_Good_Row_Tabs()
        {
            List<int> read = _reader.ParseRow("4	1	7	3	6	9	8	2	5");

            Assert.Equal(9, read.Count);
            Assert.Equal(4, read[0]);
            Assert.Equal(5, read[8]);
            Assert.Equal(6, read[4]);
        }

        [Fact]
        public void Should_Parse_Good_Row_Mixed()
        {
            List<int> read = _reader.ParseRow("4	1 7	3	6 9	8	2	5");

            Assert.Equal(9, read.Count);
            Assert.Equal(4, read[0]);
            Assert.Equal(5, read[8]);
            Assert.Equal(6, read[4]);
        }

        [Fact]
        public void Should_Parse_Bad_Row_Too_Long()
        {
            var ex = Assert.Throws<Exception>(() => _reader.ParseRow("4 1 7 3 6 9 8 2 5 0 1"));

            Assert.Equal(FileReader.WRONG_LENGTH, ex.Message);
        }

        [Fact]
        public void Should_Parse_Bad_Row_Non_Numeric()
        {
            var ex = Assert.Throws<Exception>(() => _reader.ParseRow("4 1 a 3 6 . 8 2 5"));

            Assert.Equal(FileReader.NON_NUMERIC, ex.Message);
        }
    }
}
