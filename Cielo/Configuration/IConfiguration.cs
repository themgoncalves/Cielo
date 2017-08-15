namespace Cielo.Configuration
{
    public interface IConfiguration
    {
        string DefaultEndpoint { get; }
        string QueryEndpoint { get; }
        string MerchantId { get; }
        string MerchantKey { get; }
        string ReturnUrl { get; }
    }
}
