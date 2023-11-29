using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;

namespace HealthCheckTest.EndPoint
{
    public class TempHC : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            //DB check
            //Message Broker check
            //Service x check
            return Task.FromResult(HealthCheckResult.Healthy("Healthy"));
        }
    }
}
