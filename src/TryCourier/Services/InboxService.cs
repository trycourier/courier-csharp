using System;
using TryCourier.Core;
using Inbox = TryCourier.Services.Inbox;

namespace TryCourier.Services;

/// <inheritdoc/>
public sealed class InboxService : IInboxService
{
    readonly Lazy<IInboxServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInboxServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public IInboxService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InboxService(this._client.WithOptions(modifier));
    }

    public InboxService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() => new InboxServiceWithRawResponse(client.WithRawResponse));
        _messages = new(() => new Inbox::MessageService(client));
    }

    readonly Lazy<Inbox::IMessageService> _messages;
    public Inbox::IMessageService Messages
    {
        get { return _messages.Value; }
    }
}

/// <inheritdoc/>
public sealed class InboxServiceWithRawResponse : IInboxServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInboxServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InboxServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InboxServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;

        _messages = new(() => new Inbox::MessageServiceWithRawResponse(client));
    }

    readonly Lazy<Inbox::IMessageServiceWithRawResponse> _messages;
    public Inbox::IMessageServiceWithRawResponse Messages
    {
        get { return _messages.Value; }
    }
}
