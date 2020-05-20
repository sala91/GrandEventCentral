using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FacebookCore.Tests
{
    [TestClass]
    public class FacebookCoreTest
    {
        private readonly FacebookClient _client;

        public FacebookCoreTest()
        {
            var basePath = Directory.GetCurrentDirectory();

            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);

            var configurationRoot = builder.Build();

            var clientId = configurationRoot["client_id"];
            var clientSecret = configurationRoot["client_secret"];

            _client = new FacebookClient(clientId, clientSecret);
        }

        [TestMethod]
        public async Task ShouldGetApplicationId()
        {
            var appId = await _client.App.GetAppIdAsync();
            appId.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public async Task ShouldBeAbleToGetAccessToken()
        {
            var token = await _client.App.GetAccessTokenAsync();
            token.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public async Task ShouldBeAbleToGetTestUsersList()
        {
            var users = await _client.App.GetTestUsersAsync();
            users.Should().NotBeNull();
            users.Count.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public async Task ShouldBeAbleToGetPlaces()
        {
            var token = await _client.App.GetAccessTokenAsync();
            var placesApi = _client.GetPlacesApi(token);
            var places = await placesApi.PlacesSearchAsync("-73.9921", "40.7304");

            places.Should().NotBeNull();
            places.Count.Should().Be(50,
                "Default limitation is 50 and we're querying a popular place so we should get such result.");

            //PlacesCollection placesBefore = places.After();
            //placesApi.PlacesSearch("-73.9921", "40.7304", 1000, null, null, null, 0);
        }

        [TestMethod]
        public async Task ShouldBeAbleToLoadMorePlaces()
        {
            var token = await _client.App.GetAccessTokenAsync();
            var placesApi = _client.GetPlacesApi(token);
            var places = await placesApi.PlacesSearchAsync("-73.9921", "40.7304");
            var loadMoreResult = await places.Load();

            places.Should().NotBeNull();
            loadMoreResult.Should().Be(true, "The load more operation should be successful");
            places.Count.Should().Be(100, "It loaded more results");
        }

        [TestMethod]
        public async Task ShouldBeAbleToGetPlacesAfterAndBefore()
        {
            var token = await _client.App.GetAccessTokenAsync();
            var placesApi = _client.GetPlacesApi(token);
            var places = await placesApi.PlacesSearchAsync("-73.9921", "40.7304");

            var after = await places.AfterAsync();
            var before = await after.BeforeAsync();

            places.Should().NotBeNull();
            after.Should().NotBeNull();
            before.Should().NotBeNull();

            places.Count.Should().Be(50);
            after.Count.Should().Be(50);
            before.Count.Should().Be(50);

            before[10].Id.Should().Be(places[10].Id, "Before is taken from after and therefor should match the original `places` requester");
        }
    }
}
