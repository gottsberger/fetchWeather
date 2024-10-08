﻿using FluentAssertions;
using geoloc_util.GeoCodingAPI;
using geoloc_util.GeoCodingAPI.GeoCodingAPIModels;
using geoloc_util.Utilities;

namespace geoloc_util_tests
{
    internal class LocationTests
    {
        GeoCodingAPIHelper geoCodingAPIHelper;
        string authToken;
        LocationResponse huntington;
        LocationResponse madison;
        LocationResponse newYork;
        LocationResponse notFound;

        //test2
        [SetUp]
        public void Setup()
        {
            geoCodingAPIHelper = new GeoCodingAPIHelper();
            authToken = EnvironmentManager.AuthKey;

            huntington = new LocationResponse
            {
                name = "Huntington",
                lat = 31.2837,
                lon = -94.5662,
                country = "US",
                zip = "75949"
            };
            madison = new LocationResponse
            {
                name = "Madison",
                lat = 43.074761,
                lon = -89.3837613,
                country = "US",
                state = "Wisconsin",
                local_names = new Local_Names { en = "Madison" }
            };
            newYork = new LocationResponse
            {
                name = "New York County",
                lat = 40.7127281,
                lon = -74.0060152,
                country = "US",
                state = "New York",
                local_names = new Local_Names { en = "New York" }
            };
            notFound = new LocationResponse
            {
                cod = "404",
                message = "not found"
            };
        }

        [Test]
        public async Task BasicCityStateShouldReturnResults()
        {
            var response = await geoCodingAPIHelper.GetLocationByCityState(EnvironmentManager.AuthKey, "Madison", "WI");
            madison.Should().BeEquivalentTo(response);
        }

        [Test]
        public async Task USTerritoriesShouldReturnResults()
        {
            var response = await geoCodingAPIHelper.GetLocationByCityState(EnvironmentManager.AuthKey, "Washington", "DC");
            Assert.AreEqual("District of Columbia", response.state);
        }

        [Test]
        [TestCase("New York", "NY", TestName = "City name with space should return results")]
        [TestCase("new york", "ny", TestName = "Lower case city / state should return results")]
        [TestCase("NEW YORK", "NY", TestName = "Upper case city/ state should return results")]
        [TestCase(" new york ", " ny ", TestName = "Leading / trailing spaces should be trimmed")]
        public async Task CityStateSearchReturnsCorrectLocation(string city, string state)
        {
            var response = await geoCodingAPIHelper.GetLocationByCityState(EnvironmentManager.AuthKey, city, state);
            newYork.Should().BeEquivalentTo(response);
        }

        [Test]
        [TestCase("75949", TestName = "Standard ZIP code returns results")]
        [TestCase(" 75949 ", TestName = "ZIP code with leading / trailing whitespace returns results")]
        public async Task ZipCodeSeachReturnsCorrectLocation(string zipCode)
        {
            var response = await geoCodingAPIHelper.GetLocationByZipAsync(authToken, zipCode);
            huntington.Should().BeEquivalentTo(response);
        }

        [Test]
        [TestCase("123", TestName = "Short ZIP code returns not found")]
        [TestCase("123456789", TestName = "Long ZIP code returns not found")]
        [TestCase("ABC123", TestName = "Invalid ZIP code returns not found")]
        public async Task ZipCodeInvalidInputReturnsMessage(string zipCode)
        {
            var response = await geoCodingAPIHelper.GetLocationByZipAsync(authToken, zipCode);
            notFound.Should().BeEquivalentTo(response);
        }

        [Ignore("Bug in API here")]
        [Test]
        [TestCase("XXX", "NY", TestName = "Invalid city name returns not found")]
        [TestCase("New York", "XX", TestName = "Invalid state name returns not found")]
        public async Task CityStateInvalidInputReturnsMessage(string city, string state)
        {
            // NOTE: Seems like a bug here. The state code "XX" returns results and I wouldn't expect it to.
            // Invalid city name returns a blank result set, I'd argue it should return not found like the 
            // Zip code search for consistency.
            var response = await geoCodingAPIHelper.GetLocationByCityState(EnvironmentManager.AuthKey, city, state);
            notFound.Should().BeEquivalentTo(response);
        }
    }
}
