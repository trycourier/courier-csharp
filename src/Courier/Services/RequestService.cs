using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Requests;

namespace Courier.Services;

/// <inheritdoc/>
public sealed class RequestService : IRequestService
{
    readonly Lazy<IRequestServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRequestServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public IRequestService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RequestService(this._client.WithOptions(modifier));
    }

    public RequestService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() => new RequestServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task Archive(
        RequestArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Archive(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Archive(
        string requestID,
        RequestArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Archive(parameters with { RequestID = requestID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class RequestServiceWithRawResponse : IRequestServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRequestServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RequestServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RequestServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Archive(
        RequestArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RequestID == null)
        {
            throw new CourierInvalidDataException("'parameters.RequestID' cannot be null");
        }

        HttpRequest<RequestArchiveParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Archive(
        string requestID,
        RequestArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { RequestID = requestID }, cancellationToken);
    }
}
