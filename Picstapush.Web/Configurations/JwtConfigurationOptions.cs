namespace Picstapush.Web.Configurations
{
    public class JwtConfigurationOptions
    {
        public string Signature { get; set; }
        public int ExpiresIn { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
