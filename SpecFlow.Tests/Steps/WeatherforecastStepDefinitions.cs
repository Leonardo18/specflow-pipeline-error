using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Weatherforecast.API;
using Xunit;

namespace SpecFlow.Tests.Steps
{
    [Binding]
    public sealed class WeatherforecastStepDefinitions : IClassFixture<WebApplicationFactory<Startup>>
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private HttpClient _client { get; }
        private HttpResponseMessage _httpResponse { get; set; }

        public WeatherforecastStepDefinitions(ScenarioContext scenarioContext, WebApplicationFactory<Startup> fixture)
        {
            _scenarioContext = scenarioContext;
            _client = fixture.CreateClient(new WebApplicationFactoryClientOptions());
        }

        [Given("a request to a api")]
        public void GivenTheFirstNumberIs()
        {
        }

        [When("the get request is executed")]
        public async Task WhenTheTwoNumbersAreAdded()
        {
            _httpResponse = await _client.GetAsync("/weatherforecast");
        }

        [Then("the response code should be (.*)")]
        public void ThenTheResultShouldBe(int statusCode)
        {
            var expectedStatusCode = (HttpStatusCode)statusCode;
            Assert.Equal(expectedStatusCode, _httpResponse.StatusCode);
        }
    }
}
