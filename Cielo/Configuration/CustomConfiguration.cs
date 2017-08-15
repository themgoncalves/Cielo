namespace Cielo.Configuration
{
    public class CustomConfiguration : IConfiguration
    {
        public string DefaultEndpoint { get; set; }
        public string QueryEndpoint { get; set; }
        public string MerchantId { get; set; }
        public string MerchantKey { get; set; }
        public string ReturnUrl { get; set; }
    }
}
