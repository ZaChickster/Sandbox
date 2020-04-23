## Upload CSV and Return Table
Uses package CsvHelper for parsing the file and Lamar for dependency injection.  Angular 8 is used on the frontend, .NET Core 2.2 WebApi used for the basic REST API, and Sqlite via EF Core for data persistence.  Much more separation could be added for enterprise app purposes (WebApi deployable separate from UX, some kind of messaging for handling uploaded file ingestion), but for the sake of simplicity, the three “tiers” are encased in one deployable project.  

Copy the ./Backend/sample.db file to your machine into the c:\data directory for database stuff to work.  Not a fan of how I had to hard code the path the Sqlite file but I didn't want to muck around with the .NET Core config stuff for this demo and didn’t want to tie the DB configuration and usage in the WebApi library.  For a production app that would be a requirement.

To run website, change directory to ./AngularUX and run dotnet watch run from the command line.

## Access Giphy API
The javascript portion of the exercise can be executed by opening the ./giphy.htm file in your local browser.  Like the Angular exercise, this is bare bones "enter text; click button; see image" type of implementation.

## Sudoku
Simple .NET Core 3.1 executable that takes in a single command line arg and verifies if the file contains a valid Sudoku solution.  

For example, after building, execute ".\Sudoku.exe C:\file\sudoku.txt".  Simply outputs "File 'C:\file\sudoku.txt' passes Suduko validation." or "File 'C:\file\sudoku.txt' is NOT valid: {reason}".  
