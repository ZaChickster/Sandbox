using Microsoft.Extensions.DependencyInjection;
using System;

namespace Sudoku
{
    class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<IFileParser, FileParser>()
                .AddTransient<IFileReader, FileReader>()
                .BuildServiceProvider();

            try
            {
                // build parser from Dependency Injection pipeline.
                var parser = serviceProvider.GetService<IFileParser>();
                var file = parser.ParseFile(args?[0]).Validate();
                Console.WriteLine($"File {args?[0]} passes Suduko validation.");
            }
            catch(Exception e)
            {
                Console.WriteLine($"File {args?[0]} is NOT valid: {e.Message}");
            }            
        }
    }
}
