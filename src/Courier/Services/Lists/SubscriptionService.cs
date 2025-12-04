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
    /// <inheritdoc/>
    public ISubscriptionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SubscriptionService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public SubscriptionService(ICourierClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<SubscriptionListResponse> List(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var subscriptions = await response
            .Deserialize<SubscriptionListResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            subscriptions.Validate();
        }
        return subscriptions;
    }

    /// <inheritdoc/>
    public async Task<SubscriptionListResponse> List(
        string listID,
        SubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.List(parameters with { ListID = listID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Add(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Add(
        string listID,
        SubscriptionAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Add(parameters with { ListID = listID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Subscribe(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Subscribe(
        string listID,
        SubscriptionSubscribeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Subscribe(parameters with { ListID = listID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task SubscribeUser(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task SubscribeUser(
        string userID,
        SubscriptionSubscribeUserParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.SubscribeUser(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task UnsubscribeUser(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task UnsubscribeUser(
        string userID,
        SubscriptionUnsubscribeUserParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.UnsubscribeUser(parameters with { UserID = userID }, cancellationToken);
    }
}
