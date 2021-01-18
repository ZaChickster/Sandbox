using Microsoft.Extensions.DependencyInjection;
using System;

namespace Sudoku
{
    class Program
    {
        public static void Main(string[] args)
        {
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddTransient<IFileParser, FileParser>()
                .AddTransient<IFileReader, FileReader>()
                .BuildServiceProvider();

            IFileParser parser = serviceProvider.GetService<IFileParser>();

            try
            {
                SudokuFile file = parser.ParseFile(args).Validate();
                Console.WriteLine($"File '{parser.FileName}' passes Suduko validation.");
            }
            catch(Exception e)
            {
                Console.WriteLine($"File '{parser.FileName}' is NOT valid: {e.Message}");
            }            
        }
    }
}
