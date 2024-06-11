namespace CarsManager.Application.Extensions.HttpClient;

public class PolicyHandler : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) =>
        Policies.RetryPolicy.ExecuteAsync(ct => base.SendAsync(request, ct), cancellationToken);
}