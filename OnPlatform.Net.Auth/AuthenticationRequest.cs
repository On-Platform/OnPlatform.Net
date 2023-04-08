namespace OnPlatform.Net.Auth;

public class AuthenticationRequest
{
    public string GrantType { get; set; }
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string Scope { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string RefreshToken { get; set; }
    public string SubjectToken { get; set; }
    public string SubjectTokenType { get; set; }
}