// See https://aka.ms/new-console-template for more information
using geoloc_util;
using geoloc_util.Utilities;

string[] userInput;
string[] input;

if (args.Length == 0)
{
    Console.WriteLine("Please enter the ZIP code(s) you would like to return location information on:");
    string manualInput = Console.ReadLine().Trim('"');
    userInput = StringUtilities.ReplaceSubstring(manualInput, "\" \"", ";").Split(';');
}
else { userInput = args; }
Console.WriteLine("--------------------------------");

var result = await InputProcessor.ProcessInput(userInput);
InputProcessor.ProcessOutput(result);