using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Inbound;

namespace Courier.Services;

/// <inheritdoc/>
public sealed class InboundService : IInboundService
{
    readonly Lazy<IInboundServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInboundServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public IInboundService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InboundService(this._client.WithOptions(modifier));
    }

    public InboundService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() => new InboundServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<InboundTrackEventResponse> TrackEvent(
        InboundTrackEventParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.TrackEvent(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class InboundServiceWithRawResponse : IInboundServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInboundServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InboundServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InboundServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InboundTrackEventResponse>> TrackEvent(
        InboundTrackEventParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<InboundTrackEventParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<InboundTrackEventResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
