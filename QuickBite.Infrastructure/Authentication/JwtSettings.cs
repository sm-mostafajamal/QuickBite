namespace QuickBite.Infrastructure.Authentication;

public class JwtSettings
{
    public string SecretKey {get; init;} = null!;
    public string Issuer {get; init;} = null!;
    public string Audience {get; init;} = null!;
    public int Expire {get; init;}
}