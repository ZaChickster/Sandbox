using System;
using System.Collections.Generic;
using Xunit;

namespace Sudoku.Test
{
    public class SudokuFileTest
	{
        [Fact]
        public void ValidateRow_Should_Validate_Correct_Row()
        {
            SudokuFile file = new SudokuFile("blah", new List<List<int>>
            {
                new List<int>(),
                new List<int> { 1,2,3,4,5,6,7,8,9 }
            }).ValidateRow(1);
        }

        [Fact]
        public void ValidateRow_Should_Blowup_Bad_Row()
        {
            var ex = Assert.Throws<Exception>(() => new SudokuFile("blah", new List<List<int>>
            {
                new List<int>(),
                new List<int> { 1,2,3,4,5,5,7,8,9 }
            }).ValidateRow(1));
        }

        [Fact]
        public void ValidateColumn_Should_Validate_Correct_Column()
        {
            SudokuFile file = new SudokuFile("blah", new List<List<int>>
            {
                new List<int> { 1,2,3,4,5,6,7,8,9 },
                new List<int> { 1,2,3,4,4,6,7,8,9 },
                new List<int> { 1,2,3,4,3,6,7,8,9 },
                new List<int> { 1,2,3,4,2,6,7,8,9 },
                new List<int> { 1,2,3,4,1,6,7,8,9 },
                new List<int> { 1,2,3,4,6,6,7,8,9 },
                new List<int> { 1,2,3,4,7,6,7,8,9 },
                new List<int> { 1,2,3,4,8,6,7,8,9 },
                new List<int> { 1,2,3,4,9,6,7,8,9 }
            }).ValidateColumn(4);
        }

        [Fact]
        public void ValidateColumn_Should_Blowup_Bad_Column()
        {
            var ex = Assert.Throws<Exception>(() => new SudokuFile("blah", new List<List<int>>
            {
                new List<int> { 1,2,3,4,5,6,7,8,9 },
                new List<int> { 1,2,3,4,4,6,7,8,9 },
                new List<int> { 1,2,3,4,3,6,7,8,9 },
                new List<int> { 1,2,3,4,2,6,7,8,9 },
                new List<int> { 1,2,3,4,1,6,7,8,9 },
                new List<int> { 1,2,3,4,6,6,7,8,9 },
                new List<int> { 1,2,3,4,7,6,7,8,9 },
                new List<int> { 1,2,3,4,8,6,7,8,9 },
                new List<int> { 1,2,3,4,9,6,7,8,9 }
            }).ValidateRow(3));
        }

        [Fact]
        public void ValidateCube_Should_Validate_Correct_Cube()
        {
            SudokuFile file = new SudokuFile("blah", new List<List<int>>
            {
                new List<int> { 1,2,3,4,5,6,7,8,9 },
                new List<int> { 1,2,3,4,4,6,7,8,9 },
                new List<int> { 1,2,3,4,3,6,7,8,9 },
                new List<int> { 1,2,3,4,2,6,7,8,9 },
                new List<int> { 1,2,3,4,1,6,7,8,9 },
                new List<int> { 1,2,3,4,6,6,7,8,9 },
                new List<int> { 1,2,3,4,7,6,1,2,3 },
                new List<int> { 1,2,3,4,8,6,6,5,4 },
                new List<int> { 1,2,3,4,9,6,7,8,9 }
            }).ValidateCube(6, 6);
        }

        [Fact]
        public void ValidateCube_Should_Blowup_Bad_Cube()
        {
            var ex = Assert.Throws<Exception>(() => new SudokuFile("blah", new List<List<int>>
            {
                new List<int> { 1,2,3,4,5,6,7,8,9 },
                new List<int> { 1,2,3,4,4,6,7,8,9 },
                new List<int> { 1,2,3,4,3,6,7,8,9 },
                new List<int> { 1,2,3,4,2,6,7,8,9 },
                new List<int> { 1,2,3,4,1,6,7,8,9 },
                new List<int> { 1,2,3,4,6,6,7,8,9 },
                new List<int> { 1,2,3,4,7,6,1,2,3 },
                new List<int> { 1,2,3,4,8,6,6,5,4 },
                new List<int> { 1,2,3,4,9,6,7,8,9 }
            }).ValidateCube(3, 3));
        }

        [Fact]
        public void Validate_Should_Validate_Correct_Cube()
        {
            SudokuFile file = new SudokuFile("blah", new List<List<int>>
            {
                new List<int> { 4,1,7,3,6,9,8,2,5 },
                new List<int> { 6,3,2,1,5,8,9,4,7 },
                new List<int> { 9,5,8,7,2,4,3,1,6 },
                new List<int> { 8,2,5,4,3,7,1,6,9 },
                new List<int> { 7,9,1,5,8,6,4,3,2 },
                new List<int> { 3,4,6,9,1,2,7,5,8 },
                new List<int> { 2,8,9,6,4,3,5,7,1 },
                new List<int> { 5,7,3,2,9,1,6,8,4 },
                new List<int> { 1,6,4,8,7,5,2,9,3 }
            }).Validate();
        }

        [Fact]
        public void Validate_Should_Blowup_Bad_Cube()
        {
            var ex = Assert.Throws<Exception>(() => new SudokuFile("blah", new List<List<int>>
            {
                new List<int> { 4,1,7,3,6,9,8,2,5 },
                new List<int> { 6,3,2,1,5,8,9,4,7 },
                new List<int> { 9,5,8,7,2,4,3,1,6 },
                new List<int> { 8,2,5,4,3,7,1,6,9 },
                new List<int> { 7,9,1,5,5,6,4,3,2 },
                new List<int> { 3,4,6,9,1,2,7,5,8 },
                new List<int> { 2,8,9,6,4,3,5,7,1 },
                new List<int> { 5,7,3,2,9,1,6,8,4 },
                new List<int> { 1,6,4,8,7,5,2,9,3 }
            }).ValidateCube(3, 3));
        }
    }
}
