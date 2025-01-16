using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System;

public class APITestsPage
{
    private readonly HttpClient _client;

    public APITestsPage()
    {
        _client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30) // Optional: Set a timeout for the requests
        };
    }

    public async Task<HttpResponseMessage> SendGetRequestAsync(string baseUri, string basePath)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUri}{basePath}");
        request.Headers.Add("Authorization", $"Bearer {Config.ApiAccessToken}");
        return await SendRequestAsync(request);
    }

    public async Task<HttpResponseMessage> SendPostRequestAsync(string baseUri, string basePath, string payload)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"{baseUri}{basePath}")
        {
            Content = new StringContent(payload, Encoding.UTF8, "application/json")
        };
        request.Headers.Add("Authorization", $"Bearer {Config.ApiAccessToken}");
        return await SendRequestAsync(request);
    }

    public async Task<HttpResponseMessage> SendPutRequestAsync(string baseUri, string basePath, string payload)
    {
        var request = new HttpRequestMessage(HttpMethod.Put, $"{baseUri}{basePath}")
        {
            Content = new StringContent(payload, Encoding.UTF8, "application/json")
        };
        request.Headers.Add("Authorization", $"Bearer {Config.ApiAccessToken}");
        return await SendRequestAsync(request);
    }
    public async Task<HttpResponseMessage> SendPatchRequestAsync(string baseUri, string basePath, string payload)
    {
        var request = new HttpRequestMessage(HttpMethod.Patch, $"{baseUri}{basePath}")
        {
            Content = new StringContent(payload, Encoding.UTF8, "application/json")
        };
        request.Headers.Add("Authorization", $"Bearer {Config.ApiAccessToken}");
        return await SendRequestAsync(request);
    }

    public async Task<HttpResponseMessage> SendDeleteRequestAsync(string baseUri, string basePath)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, $"{baseUri}{basePath}");
        request.Headers.Add("Authorization", $"Bearer {Config.ApiAccessToken}");
        return await SendRequestAsync(request);
    }

    private async Task<HttpResponseMessage> SendRequestAsync(HttpRequestMessage request)
    {
        try
        {
            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();  // Throws if status code is not 2xx
            return response;
        }
        catch (HttpRequestException ex)
        {
            // Handle request exceptions (e.g., network issues, invalid URLs)
            throw new Exception("Error making the API request", ex);
        }
        catch (TaskCanceledException ex)
        {
            // Handle timeout exceptions
            throw new Exception("Request timed out", ex);
        }
    }

    public async Task<JToken> GetResponseContentAsync(HttpResponseMessage response)
    {
        string content = await response.Content.ReadAsStringAsync();
        return JToken.Parse(content);
    }
}
