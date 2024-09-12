// See https://aka.ms/new-console-template for more information
using geoloc_util;
using geoloc_util.Utilities;

string[] userInput;

if (args.Length == 0)
{
    Console.WriteLine("Please enter the city name or ZIP code(s) you would like to return location information on:");
    Console.WriteLine("Format should be: \"City, ST\" or \"12345\"");
    Console.WriteLine("Multiple inputs are supported, ex: \"City, ST\" \"12345\"");
    string manualInput = Console.ReadLine().Trim('"');
    userInput = StringUtilities.ReplaceSubstring(manualInput, "\" \"", ";").Split(';');
}
else { userInput = args; }
Console.WriteLine("--------------------------------");

var result = await InputProcessor.ProcessInput(userInput);
InputProcessor.ProcessOutput(result);