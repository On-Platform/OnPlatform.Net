using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace OnPlatform.Net.Auth.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AuthenticationService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<AuthenticationResult> AuthenticateAsync(AuthenticationRequest authenticationRequest)
    {
        var httpClient = _httpClientFactory.CreateClient(Config.ClientName);
        var request = new HttpRequestMessage(HttpMethod.Post, $"/connect/token");
        request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            {"grant_type", GrantTypes.Password},
            {"client_id", authenticationRequest.ClientId},
            {"client_secret", authenticationRequest.ClientSecret},
            {"scope", authenticationRequest.Scope},
            {"username", authenticationRequest.UserName},
            {"password", authenticationRequest.Password}
        });

        var response = await httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        var result = JsonConvert.DeserializeObject<AuthenticationResult>(content);
        return result;
    }
}