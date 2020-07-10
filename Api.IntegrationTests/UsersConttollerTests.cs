using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Api;
using Api.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace API.IntegrationTests
{
    public class UsersConttollerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public UsersConttollerTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
            _factory = factory;
        }

        [Fact]
        public async Task Post_ListUsers_ReturnsListOfUsers()
        {
            // var response = await _client.GetAsync("/values");

            // Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // var data = await response.Content.ReadAsAsync<User[]>();
            // Assert.NotNull(data);
            // Assert.Empty(data);
        }
    }
}
