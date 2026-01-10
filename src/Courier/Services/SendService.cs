using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Send;

namespace Courier.Services;

/// <inheritdoc/>
public sealed class SendService : ISendService
{
    readonly Lazy<ISendServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISendServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public ISendService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SendService(this._client.WithOptions(modifier));
    }

    public SendService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() => new SendServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<SendMessageResponse> Message(
        SendMessageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Message(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class SendServiceWithRawResponse : ISendServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISendServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SendServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SendServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SendMessageResponse>> Message(
        SendMessageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SendMessageParams> request = new()
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
                    .Deserialize<SendMessageResponse>(token)
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
