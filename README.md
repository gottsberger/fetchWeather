# geolocation project

This project uses C# to automate queries of the Open Weather Geocaching API. It contains:
- All code needed to build and test the project.
- A exe folder containing a compiled version of the project along with tests and a test runner.

It uses RestSharp for API calls and NUnit for testing.

At this time, it queries the below endpoints:
- Coordinates by location name
https://openweathermap.org/api/geocoding-api#direct_name
This API endpoint takes a single location city and state query and returns the possible results
for the location search.
- Coordinates by zip/post code
https://openweathermap.org/api/geocoding-api#direct_zip
This API endpoint takes a single zipcode query and returns the possible results for the location
search. 

Inputs can be given in the following formats:
- City and place combination: “Madison, WI”
- Zip Codes: “12345”
  
Inputs can also be combined for multiple queries, ex:
- geoloc-util “Madison, WI” “12345” “Chicago, IL” “10001”

## Running the program
If using the compiled exe:
- Extract the /exe/geoloc-util.zip file locally.
- Run the exe as so and enter values when prompted:
  
`geoloc-util\exe>geoloc-util`

- Or run with values you wish to query:
  
`geoloc-util\exe>geoloc-util “Madison, WI” “12345” “Chicago, IL” “10001”`

- Run the tests as so:
  
`geoloc-util\testRunner>nunit3-console.exe ..\exe\geoloc-util-tests.dll`

- It will output test results as so:
  ![image](https://github.com/user-attachments/assets/e1c841a7-077e-444e-9bae-e356bf426cfe)
