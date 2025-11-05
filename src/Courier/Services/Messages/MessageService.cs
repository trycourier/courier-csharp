using System;
using System.Net.Http;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Messages;

namespace Courier.Services.Messages;

public sealed class MessageService : IMessageService
{
    public IMessageService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MessageService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public MessageService(ICourierClient client)
    {
        _client = client;
    }

    public async Task<MessageRetrieveResponse> Retrieve(MessageRetrieveParams parameters)
    {
        HttpRequest<MessageRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var message = await response.Deserialize<MessageRetrieveResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            message.Validate();
        }
        return message;
    }

    public async Task<MessageListResponse> List(MessageListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<MessageListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var messages = await response.Deserialize<MessageListResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            messages.Validate();
        }
        return messages;
    }

    public async Task<MessageDetails> Cancel(MessageCancelParams parameters)
    {
        HttpRequest<MessageCancelParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var messageDetails = await response.Deserialize<MessageDetails>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            messageDetails.Validate();
        }
        return messageDetails;
    }

    public async Task<MessageContentResponse> Content(MessageContentParams parameters)
    {
        HttpRequest<MessageContentParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<MessageContentResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    public async Task<MessageHistoryResponse> History(MessageHistoryParams parameters)
    {
        HttpRequest<MessageHistoryParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<MessageHistoryResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
