using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using RestWithASPNet10.Data.DTO.V1;
using RestWithASPNet10.Tests.IntegrationTests.Tools;
using System.Net;
using System.Net.Http.Json;

namespace RestWithASPNet10.Tests.IntegrationTests.CORS
{
    [TestCaseOrderer("RestWithASPNet10.Tests.IntegrationTests.Tools.PriorityOrderer", "RestWithASPNet10.Tests")]
    public class PersonCorsIntegrationTests : IClassFixture<SqlServerFixture>
    {
        private readonly HttpClient _httpClient;
        private static PersonDTO _person;

        public PersonCorsIntegrationTests(SqlServerFixture sqlFixture)
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

        private void AddoCorsOriginHeader(string origin)
        {
            _httpClient.DefaultRequestHeaders.Remove("Origin");
            _httpClient.DefaultRequestHeaders.Add("Origin", origin);
        }

        [Fact(DisplayName = "01 - Create Peson With Allowed Origin")]
        [TestPriority(1)]
        public async Task CreatePerson_WithAllowedOrigin_ShouldReturnCreated()
        {
            // Arrange
            AddoCorsOriginHeader("http://localhost:3000");
            var request = new PersonDTO
            {
                FirstName = "Richard",
                LastName = "Stallman",
                Address = "New York City - New York - USA",
                Gender = "Male"
            };

            // Act
            var response = await _httpClient.PostAsJsonAsync("/api/person/v1", request);

            // Assert
            response.EnsureSuccessStatusCode();

            var created = await response.Content.ReadFromJsonAsync<PersonDTO>();
            created.Should().NotBeNull();
            created.Id.Should().BeGreaterThan(0);

            _person = created;
        }

        [Fact(DisplayName = "02 - Create Peson With Disallowed Origin")]
        [TestPriority(2)]
        public async Task CreatePerson_WithDisallowedOrigin_ShouldReturnForbidden()
        {
            // Arrange
            AddoCorsOriginHeader("www.yotube.com");

            var request = new PersonDTO
            {
                FirstName = "Richard",
                LastName = "Stallman",
                Address = "New York City - New York - USA",
                Gender = "Male"
            };

            // Act
            var response = await _httpClient.PostAsJsonAsync("/api/person/v1", request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);

            var content = await response.Content.ReadAsStringAsync();
            content.Should().Be("CORS origin not allowed.");
             
        }

        [Fact(DisplayName = "03 - Get Peson By ID With Allowed Origin")]
        [TestPriority(3)]
        public async Task GetPerson_WithAllowedOrigin_ShouldReturnOk()
        {
            // Arrange
            AddoCorsOriginHeader("http://localhost:3000");

            // Act
            var response = await _httpClient.GetAsync($"/api/person/v1/{_person.Id}");

            // Assert
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadFromJsonAsync<PersonDTO>();
            content.Should().NotBeNull();
            content.Id.Should().BeGreaterThan(0);
            content.Id.Should().Be(_person.Id);
            content.FirstName.Should().Be("Richard");
            content.LastName.Should().Be("Stallman");
            content.Address.Should().Be("New York City - New York - USA");
            content.Gender.Should().Be("Male");
        }

        [Fact(DisplayName = "04 - Get Peson By ID With Disallowed Origin")]
        [TestPriority(4)]
        public async Task GetPerson_WithDisallowedOrigin_ShouldReturnForbidden()
        {
            // Arrange
            AddoCorsOriginHeader("www.yotube.com");

            // Act
            var response = await _httpClient.GetAsync($"/api/person/v1/{_person.Id}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);

            var content = await response.Content.ReadAsStringAsync();
            content.Should().Be("CORS origin not allowed.");
        }
    }
}
