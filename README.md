Uses package CsvHelper for parsing the file and Lamar for dependency injection.

Copy the ./Backend/sample.db file to your c:\data directory for database stuff to work.  Not a fan of how I had to hard code the path the SqlLite file but I didn't want to muck around with the config stuff for this demo.  For a production app that would be a requirement.

To run website, change directory to ./AngularUX and run dotnet watch run