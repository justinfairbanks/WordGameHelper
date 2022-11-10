// See https://aka.ms/new-console-template for more information

using Serilog;



/* Configure Serilog with C# */

Log.Logger = new LoggerConfiguration() //New Logger config
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day) //Gives file to write errors too
    .CreateLogger();

Log.Information("Serilog has been initialized"); //Info tag message

try
{
    Log.Debug("Here we will try to do a division per zero:"); //Debug Tag Message
    var foo = 0;
    var bar = 3 / foo; //Statement to try

}
catch (Exception ex) //Exception handler if try statement throws an error
{
    Log.Fatal(ex, "Division per zero occured."); //Error logged to console tagged as 'Fatal'
}

Log.Information("Closing Serilog at the end of the application."); //Info tag message
Log.CloseAndFlush();


Console.ReadLine(); //Gets line before closing program
