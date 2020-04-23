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
        public void Should_Parse_Good_Row()
        {
            List<int> read = _reader.ParseRow("4 1 7 3 6 9 8 2 5");

            Assert.Equal(9, read.Count);
            Assert.Equal(4, read[0]);
            Assert.Equal(5, read[8]);
            Assert.Equal(6, read[4]);
        }
    }
}
