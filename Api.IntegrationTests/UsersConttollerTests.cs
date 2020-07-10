using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Api;
using Api.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;
using FluentValidation;


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
        public async Task Get_ListUsers_ReturnsListOfUsers()
        {
            var response = await _client.GetAsync("/users");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var users = await response.Content.ReadAsAsync<User[]>();
            Assert.NotNull(users);
            Assert.NotEmpty(users);

            Console.WriteLine(JsonConvert.SerializeObject(users, Formatting.Indented));

            foreach (var user in users)
            {
                var validator = new UserValidator();
                var result = validator.Validate(user);
                Assert.True(result.IsValid);
            }
        }
    }
}
