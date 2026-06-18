using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.RoutingStrategies;

namespace TryCourier.Services;

/// <inheritdoc/>
public sealed class RoutingStrategyService : IRoutingStrategyService
{
    readonly Lazy<IRoutingStrategyServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRoutingStrategyServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public IRoutingStrategyService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RoutingStrategyService(this._client.WithOptions(modifier));
    }

    public RoutingStrategyService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new RoutingStrategyServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<RoutingStrategyGetResponse> Create(
        RoutingStrategyCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<RoutingStrategyGetResponse> Retrieve(
        RoutingStrategyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<RoutingStrategyGetResponse> Retrieve(
        string id,
        RoutingStrategyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RoutingStrategyListResponse> List(
        RoutingStrategyListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Archive(
        RoutingStrategyArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Archive(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Archive(
        string id,
        RoutingStrategyArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Archive(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AssociatedNotificationListResponse> ListNotifications(
        RoutingStrategyListNotificationsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListNotifications(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AssociatedNotificationListResponse> ListNotifications(
        string id,
        RoutingStrategyListNotificationsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListNotifications(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RoutingStrategyGetResponse> Replace(
        RoutingStrategyReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Replace(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<RoutingStrategyGetResponse> Replace(
        string id,
        RoutingStrategyReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Replace(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class RoutingStrategyServiceWithRawResponse : IRoutingStrategyServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRoutingStrategyServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new RoutingStrategyServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RoutingStrategyServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RoutingStrategyGetResponse>> Create(
        RoutingStrategyCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<RoutingStrategyCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var routingStrategyGetResponse = await response
                    .Deserialize<RoutingStrategyGetResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    routingStrategyGetResponse.Validate();
                }
                return routingStrategyGetResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RoutingStrategyGetResponse>> Retrieve(
        RoutingStrategyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CourierInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<RoutingStrategyRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var routingStrategyGetResponse = await response
                    .Deserialize<RoutingStrategyGetResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    routingStrategyGetResponse.Validate();
                }
                return routingStrategyGetResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<RoutingStrategyGetResponse>> Retrieve(
        string id,
        RoutingStrategyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RoutingStrategyListResponse>> List(
        RoutingStrategyListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RoutingStrategyListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var routingStrategyListResponse = await response
                    .Deserialize<RoutingStrategyListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    routingStrategyListResponse.Validate();
                }
                return routingStrategyListResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Archive(
        RoutingStrategyArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CourierInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<RoutingStrategyArchiveParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Archive(
        string id,
        RoutingStrategyArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AssociatedNotificationListResponse>> ListNotifications(
        RoutingStrategyListNotificationsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CourierInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<RoutingStrategyListNotificationsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var associatedNotificationListResponse = await response
                    .Deserialize<AssociatedNotificationListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    associatedNotificationListResponse.Validate();
                }
                return associatedNotificationListResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AssociatedNotificationListResponse>> ListNotifications(
        string id,
        RoutingStrategyListNotificationsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListNotifications(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RoutingStrategyGetResponse>> Replace(
        RoutingStrategyReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CourierInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<RoutingStrategyReplaceParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var routingStrategyGetResponse = await response
                    .Deserialize<RoutingStrategyGetResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    routingStrategyGetResponse.Validate();
                }
                return routingStrategyGetResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<RoutingStrategyGetResponse>> Replace(
        string id,
        RoutingStrategyReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Replace(parameters with { ID = id }, cancellationToken);
    }
}
