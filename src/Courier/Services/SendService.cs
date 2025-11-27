using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Send;

namespace Courier.Services;

/// <inheritdoc />
public sealed class SendService : ISendService
{
    /// <inheritdoc/>
    public ISendService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SendService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public SendService(ICourierClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<SendMessageResponse> Message(
        SendMessageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SendMessageParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<SendMessageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
