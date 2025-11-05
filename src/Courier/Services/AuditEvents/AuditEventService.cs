using System;
using System.Net.Http;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.AuditEvents;

namespace Courier.Services.AuditEvents;

public sealed class AuditEventService : IAuditEventService
{
    public IAuditEventService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AuditEventService(this._client.WithOptions(modifier));
    }

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
        var auditEvent = await response.Deserialize<AuditEvent>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            auditEvent.Validate();
        }
        return auditEvent;
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
        var auditEvents = await response
            .Deserialize<AuditEventListResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            auditEvents.Validate();
        }
        return auditEvents;
    }
}
