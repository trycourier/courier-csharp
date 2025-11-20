using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.AuditEvents;

namespace Courier.Services;

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

    public async Task<AuditEvent> Retrieve(
        AuditEventRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AuditEventID == null)
        {
            throw new CourierInvalidDataException("'parameters.AuditEventID' cannot be null");
        }

        HttpRequest<AuditEventRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var auditEvent = await response
            .Deserialize<AuditEvent>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            auditEvent.Validate();
        }
        return auditEvent;
    }

    public async Task<AuditEvent> Retrieve(
        string auditEventID,
        AuditEventRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(
            parameters with
            {
                AuditEventID = auditEventID,
            },
            cancellationToken
        );
    }

    public async Task<AuditEventListResponse> List(
        AuditEventListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AuditEventListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var auditEvents = await response
            .Deserialize<AuditEventListResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            auditEvents.Validate();
        }
        return auditEvents;
    }
}
