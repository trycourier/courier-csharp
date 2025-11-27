using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Messages;

namespace Courier.Services;

/// <inheritdoc />
public sealed class MessageService : IMessageService
{
    /// <inheritdoc/>
    public IMessageService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MessageService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public MessageService(ICourierClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<MessageRetrieveResponse> Retrieve(
        MessageRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MessageID == null)
        {
            throw new CourierInvalidDataException("'parameters.MessageID' cannot be null");
        }

        HttpRequest<MessageRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var message = await response
            .Deserialize<MessageRetrieveResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            message.Validate();
        }
        return message;
    }

    /// <inheritdoc/>
    public async Task<MessageRetrieveResponse> Retrieve(
        string messageID,
        MessageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(parameters with { MessageID = messageID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MessageListResponse> List(
        MessageListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MessageListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var messages = await response
            .Deserialize<MessageListResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            messages.Validate();
        }
        return messages;
    }

    /// <inheritdoc/>
    public async Task<MessageDetails> Cancel(
        MessageCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MessageID == null)
        {
            throw new CourierInvalidDataException("'parameters.MessageID' cannot be null");
        }

        HttpRequest<MessageCancelParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var messageDetails = await response
            .Deserialize<MessageDetails>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            messageDetails.Validate();
        }
        return messageDetails;
    }

    /// <inheritdoc/>
    public async Task<MessageDetails> Cancel(
        string messageID,
        MessageCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Cancel(parameters with { MessageID = messageID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MessageContentResponse> Content(
        MessageContentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MessageID == null)
        {
            throw new CourierInvalidDataException("'parameters.MessageID' cannot be null");
        }

        HttpRequest<MessageContentParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<MessageContentResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<MessageContentResponse> Content(
        string messageID,
        MessageContentParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Content(parameters with { MessageID = messageID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MessageHistoryResponse> History(
        MessageHistoryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MessageID == null)
        {
            throw new CourierInvalidDataException("'parameters.MessageID' cannot be null");
        }

        HttpRequest<MessageHistoryParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<MessageHistoryResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<MessageHistoryResponse> History(
        string messageID,
        MessageHistoryParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.History(parameters with { MessageID = messageID }, cancellationToken);
    }
}
