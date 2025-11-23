using System.Net;
using System.Net.Http.Json;
using InsurancePolicyService.Models;
using Microsoft.AspNetCore.Mvc.Testing;

namespace InsurancePolicyService.IntegrationTests
{
    public class PolicyNotesIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public PolicyNotesIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task PostNotes_ShouldReturn201()
        {
            var response = await _client.PostAsJsonAsync("/notes", new
            {
                PolicyNumber = "P100",
                Note = "Created via test"
            });

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task GetNotes_ShouldReturn200()
        {
            var response = await _client.GetAsync("/notes");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetNoteById_ShouldReturn200_WhenFound()
        {
            var createRes = await _client.PostAsJsonAsync("/notes", new
            {
                PolicyNumber = "P777",
                Note = "TestFind"
            });

            var created = await createRes.Content.ReadFromJsonAsync<PolicyNote>();

            var response = await _client.GetAsync($"/notes/{created.Id}");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetNoteById_ShouldReturn404_WhenNotFound()
        {
            var response = await _client.GetAsync("/notes/999999");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
