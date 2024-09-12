// See https://aka.ms/new-console-template for more information
using geoloc_util;

string userInput;
string[] input;

Console.WriteLine("Please enter the ZIP code(s) you would like to return location information on:");
userInput = Console.ReadLine().Trim('"');

Console.WriteLine("--------------------------------");

var result = await InputProcessor.ProcessInput(userInput);
InputProcessor.ProcessOutput(result);