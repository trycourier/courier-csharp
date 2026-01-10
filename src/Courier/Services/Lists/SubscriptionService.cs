using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Lists.Subscriptions;

namespace Courier.Services.Lists;

/// <inheritdoc/>
public sealed class SubscriptionService : ISubscriptionService
{
    readonly Lazy<ISubscriptionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISubscriptionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public ISubscriptionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SubscriptionService(this._client.WithOptions(modifier));
    }

    public SubscriptionService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new SubscriptionServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<SubscriptionListResponse> List(
        SubscriptionListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SubscriptionListResponse> List(
        string listID,
        SubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ListID = listID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Add(
        SubscriptionAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Add(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Add(
        string listID,
        SubscriptionAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Add(parameters with { ListID = listID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Subscribe(
        SubscriptionSubscribeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Subscribe(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Subscribe(
        string listID,
        SubscriptionSubscribeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Subscribe(parameters with { ListID = listID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task SubscribeUser(
        SubscriptionSubscribeUserParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.SubscribeUser(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task SubscribeUser(
        string userID,
        SubscriptionSubscribeUserParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.SubscribeUser(parameters with { UserID = userID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task UnsubscribeUser(
        SubscriptionUnsubscribeUserParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UnsubscribeUser(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task UnsubscribeUser(
        string userID,
        SubscriptionUnsubscribeUserParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.UnsubscribeUser(parameters with { UserID = userID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class SubscriptionServiceWithRawResponse : ISubscriptionServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISubscriptionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SubscriptionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SubscriptionServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubscriptionListResponse>> List(
        SubscriptionListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ListID == null)
        {
            throw new CourierInvalidDataException("'parameters.ListID' cannot be null");
        }

        HttpRequest<SubscriptionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var subscriptions = await response
                    .Deserialize<SubscriptionListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    subscriptions.Validate();
                }
                return subscriptions;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<SubscriptionListResponse>> List(
        string listID,
        SubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ListID = listID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Add(
        SubscriptionAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ListID == null)
        {
            throw new CourierInvalidDataException("'parameters.ListID' cannot be null");
        }

        HttpRequest<SubscriptionAddParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Add(
        string listID,
        SubscriptionAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Add(parameters with { ListID = listID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Subscribe(
        SubscriptionSubscribeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ListID == null)
        {
            throw new CourierInvalidDataException("'parameters.ListID' cannot be null");
        }

        HttpRequest<SubscriptionSubscribeParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Subscribe(
        string listID,
        SubscriptionSubscribeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Subscribe(parameters with { ListID = listID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> SubscribeUser(
        SubscriptionSubscribeUserParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserID == null)
        {
            throw new CourierInvalidDataException("'parameters.UserID' cannot be null");
        }

        HttpRequest<SubscriptionSubscribeUserParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> SubscribeUser(
        string userID,
        SubscriptionSubscribeUserParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SubscribeUser(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> UnsubscribeUser(
        SubscriptionUnsubscribeUserParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserID == null)
        {
            throw new CourierInvalidDataException("'parameters.UserID' cannot be null");
        }

        HttpRequest<SubscriptionUnsubscribeUserParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> UnsubscribeUser(
        string userID,
        SubscriptionUnsubscribeUserParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UnsubscribeUser(parameters with { UserID = userID }, cancellationToken);
    }
}
