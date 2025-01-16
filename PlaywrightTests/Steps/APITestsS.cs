using TechTalk.SpecFlow;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Threading.Tasks;

[Binding]
public class APITestS
{
    private readonly APITestsPage _reusableMethods;
    private HttpResponseMessage _response;
    private JToken _responseContent;

    public APITestS()
    {
        _reusableMethods = new APITestsPage();
    }

    [Given(@"The API endpoint has baseURI ""(.*)"" and basePath '(.*)' and ID '(.*)'")]
    public void GivenTheAPIEndpointHasBaseURIAndBasePathAndID(string baseURL, string basePath, string ID)
    {
        // Use ScenarioContext directly without .Current
        ScenarioContext.Current["BaseUri"] = baseURL;
        ScenarioContext.Current["BasePath"] = basePath+ID;
    }

    [Given(@"The API endpoint has baseURI ""(.*)"" and basePath ""(.*)""")]
    public void GivenTheAPIEndpointHavingBaseURIAndBasePath(string baseUri, string basePath)
    {
        // Use ScenarioContext directly without .Current
        ScenarioContext.Current["BaseUri"] = baseUri;
        ScenarioContext.Current["BasePath"] = basePath;
    }

    [Given(@"The API endpoint has baseURL ""(.*)"" and basePath ""(.*)"" and ID ""(.*)"" and endpoint ""(.*)""")]
    public void GivenTheAPIEndpointHasBaseURLAndBasePathAndIDAndEndpoint(string baseURL, string basePath, string ID, string endPoint)
    {
        // Use ScenarioContext directly without .Current
        ScenarioContext.Current["BaseUri"] = baseURL;
        ScenarioContext.Current["BasePath"] = basePath + ID + endPoint;
    }

    [When(@"I send a GET request to the endpoint")]
    public async Task WhenISendAGetRequestToTheEndpoint()
    {
        string baseUri = ScenarioContext.Current["BaseUri"].ToString();
        string basePath = ScenarioContext.Current["BasePath"].ToString();
        _response = await _reusableMethods.SendGetRequestAsync(baseUri, basePath);
        _responseContent = await _reusableMethods.GetResponseContentAsync(_response);
    }

    [When(@"I send a POST request with access token in the header and ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" to the endpoint")]
    public async Task WhenISendAPostRequestWithAccessTokenInTheHeaderAndToTheEndpoint(string name, string email, string gender, string status)
    {
        string baseUri = ScenarioContext.Current["BaseUri"].ToString();
        string basePath = ScenarioContext.Current["BasePath"].ToString();

        var payload = $@"{{
            ""name"": ""{name}"",
            ""email"": ""{email}"",
            ""gender"": ""{gender}"",
            ""status"": ""{status}""
        }}";

        _response = await _reusableMethods.SendPostRequestAsync(baseUri, basePath, payload);
        _responseContent = await _reusableMethods.GetResponseContentAsync(_response);
    }

    [When(@"I send a PUT request with access token in the header and ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" to the endpoint")]
    public async Task WhenISendAPutRequestWithAccessTokenInTheHeaderAndToTheEndpoint(string name, string email, string gender, string status)
    {
        string baseUri = ScenarioContext.Current["BaseUri"].ToString();
        string basePath = ScenarioContext.Current["BasePath"].ToString();

        var payload = $@"{{
            ""name"": ""{name}"",
            ""email"": ""{email}"",
            ""gender"": ""{gender}"",
            ""status"": ""{status}""
        }}";

        _response = await _reusableMethods.SendPutRequestAsync(baseUri, basePath, payload);
        _responseContent = await _reusableMethods.GetResponseContentAsync(_response);
    }

    [When(@"I send a PATCH request with access token in the header and ""(.*)"" ""(.*)"" to the endpoint")]
    public async Task WhenISendAPatchRequestWithAccessTokenInTheHeaderAndToTheEndpoint(string name, string gender)
    {
        string baseUri = ScenarioContext.Current["BaseUri"].ToString();
        string basePath = ScenarioContext.Current["BasePath"].ToString();

        var payload = $@"{{
            ""name"": ""{name}"",
            ""gender"": ""{gender}""
        }}";

        _response = await _reusableMethods.SendPatchRequestAsync(baseUri, basePath, payload);
        _responseContent = await _reusableMethods.GetResponseContentAsync(_response);
    }

    [When(@"I send a DELETE request with access token in the header and ""(.*)"" to the endpoint")]
    public async Task WhenISendADeleteRequestWithAccessTokenInTheHeaderAndToTheEndpoint(string ID)
    {
        string baseUri = ScenarioContext.Current["BaseUri"].ToString();
        string basePath = ScenarioContext.Current["BasePath"].ToString();

        _response = await _reusableMethods.SendDeleteRequestAsync(baseUri, basePath);
    }

    [When(@"I send a CREATE POST request with access token in the header and ""(.*)"" ""(.*)"" to the endpoint")]
    public async Task WhenISendACreatePostRequestWithAccessTokenInTheHeaderAndToTheEndpoint(string title, string body)
    {
        string baseUri = ScenarioContext.Current["BaseUri"].ToString();
        string basePath = ScenarioContext.Current["BasePath"].ToString();

        var payload = $@"{{
            ""title"": ""{title}"",
            ""body"": ""{body}""
        }}";

        _response = await _reusableMethods.SendPostRequestAsync(baseUri, basePath, payload);
        _responseContent = await _reusableMethods.GetResponseContentAsync(_response);
    }

    [When(@"I send a CREATE TODO request with access token in the header and ""(.*)"" ""(.*)"" to the endpoint")]
    public async Task WhenISendACreateTodoRequestWithAccessTokenInTheHeaderAndToTheEndpoint(string title, string status)
    {
        string baseUri = ScenarioContext.Current["BaseUri"].ToString();
        string basePath = ScenarioContext.Current["BasePath"].ToString();

        var payload = $@"{{
            ""title"": ""{title}"",
            ""status"": ""{status}""
        }}";

        _response = await _reusableMethods.SendPostRequestAsync(baseUri, basePath, payload);
        _responseContent = await _reusableMethods.GetResponseContentAsync(_response);
    }

    [Then(@"I should receive a response with status code (\d+)")]
    public void ThenIShouldReceiveAResponseWithStatusCode(int statusCode)
    {
        Assert.AreEqual(statusCode, (int)_response.StatusCode, $"Expected status code {statusCode}, but got {(int)_response.StatusCode}");
    }

    [Then(@"the JSON path ""(.*)"" should have value ""(.*)""")]
    public void ThenTheJsonPathShouldHaveValue(string jsonPath, string expectedValue)
    {
        var actualValue = _responseContent.SelectToken(jsonPath)?.ToString();
        Assert.AreEqual(expectedValue, actualValue, $"Expected value for JSON path '{jsonPath}' was '{expectedValue}', but got '{actualValue}'");
    }
}
