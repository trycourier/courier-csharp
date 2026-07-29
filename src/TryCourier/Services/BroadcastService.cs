using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Broadcasts;
using TryCourier.Models.Notifications;

namespace TryCourier.Services;

/// <inheritdoc/>
public sealed class BroadcastService : IBroadcastService
{
    readonly Lazy<IBroadcastServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBroadcastServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public IBroadcastService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BroadcastService(this._client.WithOptions(modifier));
    }

    public BroadcastService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() => new BroadcastServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Broadcast> Create(
        BroadcastCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Broadcast> Retrieve(
        BroadcastRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Broadcast> Retrieve(
        string broadcastID,
        BroadcastRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { BroadcastID = broadcastID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Broadcast> Update(
        BroadcastUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Broadcast> Update(
        string broadcastID,
        BroadcastUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { BroadcastID = broadcastID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BroadcastListResponse> List(
        BroadcastListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Broadcast> Archive(
        BroadcastArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Archive(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Broadcast> Archive(
        string broadcastID,
        BroadcastArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { BroadcastID = broadcastID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Broadcast> Cancel(
        BroadcastCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Cancel(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Broadcast> Cancel(
        string broadcastID,
        BroadcastCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { BroadcastID = broadcastID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Broadcast> Duplicate(
        BroadcastDuplicateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Duplicate(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Broadcast> Duplicate(
        string broadcastID,
        BroadcastDuplicateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Duplicate(parameters with { BroadcastID = broadcastID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<NotificationContentMutationResponse> PutContent(
        BroadcastPutContentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.PutContent(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<NotificationContentMutationResponse> PutContent(
        string broadcastID,
        BroadcastPutContentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.PutContent(parameters with { BroadcastID = broadcastID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<NotificationContentGetResponse> RetrieveContent(
        BroadcastRetrieveContentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveContent(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<NotificationContentGetResponse> RetrieveContent(
        string broadcastID,
        BroadcastRetrieveContentParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveContent(
            parameters with
            {
                BroadcastID = broadcastID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<Broadcast> Schedule(
        BroadcastScheduleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Schedule(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Broadcast> Schedule(
        string broadcastID,
        BroadcastScheduleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Schedule(parameters with { BroadcastID = broadcastID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Broadcast> Send(
        BroadcastSendParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Send(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Broadcast> Send(
        string broadcastID,
        BroadcastSendParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Send(parameters with { BroadcastID = broadcastID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class BroadcastServiceWithRawResponse : IBroadcastServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBroadcastServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BroadcastServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BroadcastServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Broadcast>> Create(
        BroadcastCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BroadcastCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var broadcast = await response.Deserialize<Broadcast>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    broadcast.Validate();
                }
                return broadcast;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Broadcast>> Retrieve(
        BroadcastRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BroadcastID == null)
        {
            throw new CourierInvalidDataException("'parameters.BroadcastID' cannot be null");
        }

        HttpRequest<BroadcastRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var broadcast = await response.Deserialize<Broadcast>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    broadcast.Validate();
                }
                return broadcast;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Broadcast>> Retrieve(
        string broadcastID,
        BroadcastRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { BroadcastID = broadcastID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Broadcast>> Update(
        BroadcastUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BroadcastID == null)
        {
            throw new CourierInvalidDataException("'parameters.BroadcastID' cannot be null");
        }

        HttpRequest<BroadcastUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var broadcast = await response.Deserialize<Broadcast>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    broadcast.Validate();
                }
                return broadcast;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Broadcast>> Update(
        string broadcastID,
        BroadcastUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { BroadcastID = broadcastID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BroadcastListResponse>> List(
        BroadcastListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<BroadcastListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var broadcastListResponse = await response
                    .Deserialize<BroadcastListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    broadcastListResponse.Validate();
                }
                return broadcastListResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Broadcast>> Archive(
        BroadcastArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BroadcastID == null)
        {
            throw new CourierInvalidDataException("'parameters.BroadcastID' cannot be null");
        }

        HttpRequest<BroadcastArchiveParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var broadcast = await response.Deserialize<Broadcast>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    broadcast.Validate();
                }
                return broadcast;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Broadcast>> Archive(
        string broadcastID,
        BroadcastArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { BroadcastID = broadcastID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Broadcast>> Cancel(
        BroadcastCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BroadcastID == null)
        {
            throw new CourierInvalidDataException("'parameters.BroadcastID' cannot be null");
        }

        HttpRequest<BroadcastCancelParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var broadcast = await response.Deserialize<Broadcast>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    broadcast.Validate();
                }
                return broadcast;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Broadcast>> Cancel(
        string broadcastID,
        BroadcastCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { BroadcastID = broadcastID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Broadcast>> Duplicate(
        BroadcastDuplicateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BroadcastID == null)
        {
            throw new CourierInvalidDataException("'parameters.BroadcastID' cannot be null");
        }

        HttpRequest<BroadcastDuplicateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var broadcast = await response.Deserialize<Broadcast>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    broadcast.Validate();
                }
                return broadcast;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Broadcast>> Duplicate(
        string broadcastID,
        BroadcastDuplicateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Duplicate(parameters with { BroadcastID = broadcastID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NotificationContentMutationResponse>> PutContent(
        BroadcastPutContentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BroadcastID == null)
        {
            throw new CourierInvalidDataException("'parameters.BroadcastID' cannot be null");
        }

        HttpRequest<BroadcastPutContentParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var notificationContentMutationResponse = await response
                    .Deserialize<NotificationContentMutationResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    notificationContentMutationResponse.Validate();
                }
                return notificationContentMutationResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<NotificationContentMutationResponse>> PutContent(
        string broadcastID,
        BroadcastPutContentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.PutContent(parameters with { BroadcastID = broadcastID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NotificationContentGetResponse>> RetrieveContent(
        BroadcastRetrieveContentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BroadcastID == null)
        {
            throw new CourierInvalidDataException("'parameters.BroadcastID' cannot be null");
        }

        HttpRequest<BroadcastRetrieveContentParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var notificationContentGetResponse = await response
                    .Deserialize<NotificationContentGetResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    notificationContentGetResponse.Validate();
                }
                return notificationContentGetResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<NotificationContentGetResponse>> RetrieveContent(
        string broadcastID,
        BroadcastRetrieveContentParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveContent(
            parameters with
            {
                BroadcastID = broadcastID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Broadcast>> Schedule(
        BroadcastScheduleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BroadcastID == null)
        {
            throw new CourierInvalidDataException("'parameters.BroadcastID' cannot be null");
        }

        HttpRequest<BroadcastScheduleParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var broadcast = await response.Deserialize<Broadcast>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    broadcast.Validate();
                }
                return broadcast;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Broadcast>> Schedule(
        string broadcastID,
        BroadcastScheduleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Schedule(parameters with { BroadcastID = broadcastID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Broadcast>> Send(
        BroadcastSendParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BroadcastID == null)
        {
            throw new CourierInvalidDataException("'parameters.BroadcastID' cannot be null");
        }

        HttpRequest<BroadcastSendParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var broadcast = await response.Deserialize<Broadcast>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    broadcast.Validate();
                }
                return broadcast;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Broadcast>> Send(
        string broadcastID,
        BroadcastSendParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Send(parameters with { BroadcastID = broadcastID }, cancellationToken);
    }
}
