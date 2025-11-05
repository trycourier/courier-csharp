using System;
using System.Net.Http;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Send;

namespace Courier.Services.Send;

public sealed class SendService : ISendService
{
    public ISendService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SendService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public SendService(ICourierClient client)
    {
        _client = client;
    }

    public async Task<SendMessageResponse> Message(SendMessageParams parameters)
    {
        HttpRequest<SendMessageParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<SendMessageResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
