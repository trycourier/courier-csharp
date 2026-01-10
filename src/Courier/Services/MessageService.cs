using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Messages;

namespace Courier.Services;

/// <inheritdoc/>
public sealed class MessageService : IMessageService
{
    readonly Lazy<IMessageServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMessageServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public IMessageService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MessageService(this._client.WithOptions(modifier));
    }

    public MessageService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() => new MessageServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<MessageRetrieveResponse> Retrieve(
        MessageRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<MessageRetrieveResponse> Retrieve(
        string messageID,
        MessageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { MessageID = messageID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MessageListResponse> List(
        MessageListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MessageDetails> Cancel(
        MessageCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Cancel(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<MessageDetails> Cancel(
        string messageID,
        MessageCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { MessageID = messageID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MessageContentResponse> Content(
        MessageContentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Content(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<MessageContentResponse> Content(
        string messageID,
        MessageContentParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Content(parameters with { MessageID = messageID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MessageHistoryResponse> History(
        MessageHistoryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.History(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<MessageHistoryResponse> History(
        string messageID,
        MessageHistoryParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.History(parameters with { MessageID = messageID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class MessageServiceWithRawResponse : IMessageServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMessageServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MessageServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MessageServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessageRetrieveResponse>> Retrieve(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var message = await response
                    .Deserialize<MessageRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    message.Validate();
                }
                return message;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<MessageRetrieveResponse>> Retrieve(
        string messageID,
        MessageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { MessageID = messageID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessageListResponse>> List(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var messages = await response
                    .Deserialize<MessageListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    messages.Validate();
                }
                return messages;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessageDetails>> Cancel(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var messageDetails = await response
                    .Deserialize<MessageDetails>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    messageDetails.Validate();
                }
                return messageDetails;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<MessageDetails>> Cancel(
        string messageID,
        MessageCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { MessageID = messageID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessageContentResponse>> Content(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<MessageContentResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<MessageContentResponse>> Content(
        string messageID,
        MessageContentParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Content(parameters with { MessageID = messageID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MessageHistoryResponse>> History(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<MessageHistoryResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<MessageHistoryResponse>> History(
        string messageID,
        MessageHistoryParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.History(parameters with { MessageID = messageID }, cancellationToken);
    }
}
