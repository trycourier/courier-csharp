using System.Net.Http;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.AuditEvents;

namespace Courier.Services.AuditEvents;

public sealed class AuditEventService : IAuditEventService
{
    readonly ICourierClient _client;

    public AuditEventService(ICourierClient client)
    {
        _client = client;
    }

    public async Task<AuditEvent> Retrieve(AuditEventRetrieveParams parameters)
    {
        HttpRequest<AuditEventRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<AuditEvent>().ConfigureAwait(false);
    }

    public async Task<AuditEventListResponse> List(AuditEventListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<AuditEventListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<AuditEventListResponse>().ConfigureAwait(false);
    }
}
