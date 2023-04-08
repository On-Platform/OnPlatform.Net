namespace OnPlatform.Net.Auth;

public class Config
{
    public const string ClientName = "IdentityServer";

    private static Config _instance;
    public static Config Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Config();
            }
            return _instance;
        }
    }
}