using Polly;
using Polly.Retry;
using Polly.Timeout;

namespace CarsManager.Application.Extensions.HttpClient;

public static class Policies
{
    public static AsyncRetryPolicy<HttpResponseMessage> RetryPolicy => Policy
        .HandleResult<HttpResponseMessage>(r =>
        new[]
        {
            System.Net.HttpStatusCode.GatewayTimeout,
            System.Net.HttpStatusCode.InternalServerError,
            System.Net.HttpStatusCode.ServiceUnavailable,
        }.Contains(r.StatusCode))
        .Or<TimeoutRejectedException>()
        .WaitAndRetryAsync(
        Enumerable.Repeat(TimeSpan.FromSeconds(3), 2));
}