using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Send = Courier.Models.Send;

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

    public async Task<Send::SendMessageResponse> Message(
        Send::SendMessageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Send::SendMessageParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<Send::SendMessageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
