using Flurl.Http.Configuration;

namespace CarsManager.Application.HttpClient;

public class PollyClientFactory : DefaultHttpClientFactory
{
    public override HttpMessageHandler CreateMessageHandler() => new PolicyHandler
    {
        InnerHandler = CreateCustomMessageHandler()
    };

    public virtual HttpMessageHandler CreateCustomMessageHandler() => base.CreateMessageHandler();
}