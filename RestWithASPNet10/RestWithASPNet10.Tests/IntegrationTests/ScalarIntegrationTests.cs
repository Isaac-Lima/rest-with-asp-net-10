using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using RestWithASPNet10.Tests.IntegrationTests.Tools;

namespace RestWithASPNet10.Tests.IntegrationTests
{
    public class ScalarIntegrationTests : IClassFixture<SqlServerFixture>
    {
        private readonly HttpClient _httpClient;

        public ScalarIntegrationTests(SqlServerFixture sqlFixture)
        {
            var factory = new CustomWebApplicationFactory<Program>(
                sqlFixture.ConnectionString);
            _httpClient = factory.CreateClient(
                new WebApplicationFactoryClientOptions
                {
                    BaseAddress = new Uri("http://localhost")
                }
            );
        }

        [Fact]
        public async Task ScalarUI_ShouldReturnScalarUI()
        {
            // Arrange & Act
            var response = await _httpClient.GetAsync("/scalar/");

            // Assert
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            content.Should().NotBeNull();
            content.Should().Contain("<div id=\"app\">");
        }
    }
}
