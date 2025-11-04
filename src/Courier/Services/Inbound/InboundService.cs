using System.Net.Http;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Inbound;

namespace Courier.Services.Inbound;

public sealed class InboundService : IInboundService
{
    readonly ICourierClient _client;

    public InboundService(ICourierClient client)
    {
        _client = client;
    }

    public async Task<InboundTrackEventResponse> TrackEvent(InboundTrackEventParams parameters)
    {
        HttpRequest<InboundTrackEventParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<InboundTrackEventResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
