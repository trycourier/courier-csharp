using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.AuditEvents;

namespace Courier.Services;

/// <inheritdoc/>
public sealed class AuditEventService : IAuditEventService
{
    readonly Lazy<IAuditEventServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAuditEventServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public IAuditEventService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AuditEventService(this._client.WithOptions(modifier));
    }

    public AuditEventService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AuditEventServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<AuditEvent> Retrieve(
        AuditEventRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AuditEvent> Retrieve(
        string auditEventID,
        AuditEventRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { AuditEventID = auditEventID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AuditEventListResponse> List(
        AuditEventListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class AuditEventServiceWithRawResponse : IAuditEventServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAuditEventServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AuditEventServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AuditEventServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AuditEvent>> Retrieve(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var auditEvent = await response
                    .Deserialize<AuditEvent>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    auditEvent.Validate();
                }
                return auditEvent;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AuditEvent>> Retrieve(
        string auditEventID,
        AuditEventRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { AuditEventID = auditEventID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AuditEventListResponse>> List(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var auditEvents = await response
                    .Deserialize<AuditEventListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    auditEvents.Validate();
                }
                return auditEvents;
            }
        );
    }
}
