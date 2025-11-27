using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Inbound;

namespace Courier.Services;

/// <inheritdoc />
public sealed class InboundService : IInboundService
{
    /// <inheritdoc/>
    public IInboundService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InboundService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public InboundService(ICourierClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<InboundTrackEventResponse> TrackEvent(
        InboundTrackEventParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<InboundTrackEventParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<InboundTrackEventResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
