Uses package CsvHelper for parsing the file and Lamar for dependency injection.  Angular 8 for the client, .NET Core 2.2 WebApi for the middle, and SqlLite for the back.  Much more separation could be added for enterprise app purposes, but for the sake of simplicity, UX, Server, DB are the three tiers.  

Copy the ./Backend/sample.db file to your c:\data directory for database stuff to work.  Not a fan of how I had to hard code the path the SqlLite file but I didn't want to muck around with the .NET Core config stuff for this demo.  For a production app that would be a requirement.

To run website, change directory to ./AngularUX and run dotnet watch run

The javascript portion of the excercise can be executed by opening the giphy.htm file in your local browser.  Like the Angular excercise, this is bare bones "enter text; click button; see image" type of implementation.