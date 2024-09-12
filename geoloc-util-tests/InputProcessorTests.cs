using FluentAssertions;
using geoloc_util;
using geoloc_util.GeoCodingAPI.GeoCodingAPIModels;

namespace geoloc_util_tests
{
    public class Tests
    {
        LocationResponse huntington;
        LocationResponse newYork;
        LocationResponse notFound;

        [SetUp]
        public void SetUp()
        {
            huntington = new LocationResponse
            {
                name = "Huntington",
                lat = 31.2837,
                lon = -94.5662,
                country = "US",
                zip = "75949"
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
        public async Task TestLocationInputs()
        {
            var response = await InputProcessor.ProcessInput(
                new string[] { "75949", "New York, NY", "sdfdsf"});
            response[0].Value.Should().BeEquivalentTo(huntington);
            response[1].Value.Should().BeEquivalentTo(newYork);
            response[2].Value.Should().BeEquivalentTo(notFound);
        }
    }
}