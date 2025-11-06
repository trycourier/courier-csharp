using System;
using System.Net.Http;
using System.Threading.Tasks;
using Courier.Core;
using Inbound = Courier.Models.Inbound;

namespace Courier.Services.Inbound;

public sealed class InboundService : IInboundService
{
    public IInboundService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InboundService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public InboundService(ICourierClient client)
    {
        _client = client;
    }

    public async Task<Inbound::InboundTrackEventResponse> TrackEvent(
        Inbound::InboundTrackEventParams parameters
    )
    {
        HttpRequest<Inbound::InboundTrackEventParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<Inbound::InboundTrackEventResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
