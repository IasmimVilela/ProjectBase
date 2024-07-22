using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace TaskB3.Services.Api.IntegrationTests.IntegrationTests.Controllers
{
    public class WeatherForecastControllerIntegrationTests : IClassFixture<TarefaWebApplicationFactory<IStartup>>
    {
        private readonly HttpClient _client;
        private readonly TarefaWebApplicationFactory<IStartup> _factory;

        public WeatherForecastControllerIntegrationTests(TarefaWebApplicationFactory<IStartup> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
                {
                    AllowAutoRedirect = false
                });
        }

        [Theory]
        [InlineData("/WeatherForecast/HelloWorld", "text/plain; charset=utf-8")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url, string expected)
        {
            // Arrange

            // Act
            var response = await _client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            response.Content.Headers.ContentType.ToString().Should().Be(expected);
        }
    }
}
