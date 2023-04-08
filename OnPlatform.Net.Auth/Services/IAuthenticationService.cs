namespace OnPlatform.Net.Auth.Services;

public interface IAuthenticationService
{
    Task<AuthenticationResult> AuthenticateAsync(AuthenticationRequest request);
}