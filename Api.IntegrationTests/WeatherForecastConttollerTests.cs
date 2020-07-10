using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Api;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace API.IntegrationTests
{
    public class WeatherForecastConttollerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public WeatherForecastConttollerTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
            _factory = factory;
        }

        [Fact]
        public async Task Get_WeatherForecast_ReturnsListOfData()
        {
            var response = await _client.GetAsync("/WeatherForecast");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var datalist = await response.Content.ReadAsAsync<JObject[]>();
            Console.WriteLine(JsonConvert.SerializeObject(datalist, Formatting.Indented));
            Assert.NotNull(datalist);
            Assert.NotEmpty(datalist);

            foreach (var data in datalist)
            {
                var txtDate = data["date"].ToString();
                Assert.NotNull(txtDate);
                Assert.NotEmpty(txtDate);
                Assert.True(DateTime.TryParse(txtDate, out DateTime tempDate));

                var txtTemperatureC = data["temperatureC"].ToString();
                Assert.NotNull(txtTemperatureC);
                Assert.NotEmpty(txtTemperatureC);
                Assert.True(int.TryParse(txtTemperatureC, out int tempInt));

                var txtTemperatureF = data["temperatureF"].ToString();
                Assert.NotNull(txtTemperatureF);
                Assert.NotEmpty(txtTemperatureF);
                Assert.True(int.TryParse(txtTemperatureF, out int tempInt2));

                var txtSummary = data["summary"].ToString();
                Assert.NotNull(txtSummary);
                Assert.NotEmpty(txtSummary);
            }
        }
    }
}
