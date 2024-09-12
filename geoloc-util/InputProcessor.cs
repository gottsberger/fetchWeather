using geoloc_util.GeoCodingAPI;
using geoloc_util.GeoCodingAPI.GeoCodingAPIModels;
using geoloc_util.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geoloc_util
{
    internal class InputProcessor
    {
        public static async Task<List<KeyValuePair<string, LocationResponse>>> ProcessInput(string[] userInput)
        {            
            List<KeyValuePair<string, LocationResponse>> output = new List<KeyValuePair<string, LocationResponse>>();

            GeoCodingAPIHelper geoCodingAPIHelper = new GeoCodingAPIHelper();

            for (int i = 0; i < userInput.Length; i++)
            {
                string auth = EnvironmentManager.AuthKey;
                LocationResponse response;

                if (userInput[i].Contains(","))
                {
                    string[] cityStateCombo = userInput[i].Split(",");
                    response = await geoCodingAPIHelper.GetLocationByCityState(EnvironmentManager.AuthKey, cityStateCombo[0], cityStateCombo[1]);
                }
                else
                {
                    response = await geoCodingAPIHelper.GetLocationByZipAsync(EnvironmentManager.AuthKey, userInput[i]);
                }
                KeyValuePair<string, LocationResponse> result =
                    new KeyValuePair<string, LocationResponse>(userInput[i], response);
                output.Add(result);
            }
            return output;
        }

        public static void ProcessOutput(List<KeyValuePair<string, LocationResponse>> output)
        {
            foreach (var result in output)
            {
                Console.WriteLine("--------------------------------");

                Console.WriteLine("User input was: " + result.Key);
                if (String.IsNullOrEmpty(result.Value.message))
                {
                    Console.WriteLine("Results were: ");

                    Console.WriteLine("Name is: " + result.Value.name);
                    if (!string.IsNullOrEmpty(result.Value.state))
                    {
                        Console.WriteLine("State is: " + result.Value.state);
                    }
                    Console.WriteLine("Country is: " + result.Value.country);
                    Console.WriteLine("Latitude is: " + result.Value.lat);
                    Console.WriteLine("Longitude is: " + result.Value.lon);
                }
                else
                {
                    Console.WriteLine("No results found!");
                    Console.WriteLine("Error message from service: " + result.Value.message);
                }

                Console.WriteLine("--------------------------------");
            }
        }
    }
}
