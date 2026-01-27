using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Profiles.Lists;

namespace Courier.Services.Profiles;

/// <inheritdoc/>
public sealed class ListService : IListService
{
    readonly Lazy<IListServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IListServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public IListService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ListService(this._client.WithOptions(modifier));
    }

    public ListService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ListServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ListRetrieveResponse> Retrieve(
        ListRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ListRetrieveResponse> Retrieve(
        string userID,
        ListRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ListDeleteResponse> Delete(
        ListDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ListDeleteResponse> Delete(
        string userID,
        ListDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ListSubscribeResponse> Subscribe(
        ListSubscribeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Subscribe(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ListSubscribeResponse> Subscribe(
        string userID,
        ListSubscribeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Subscribe(parameters with { UserID = userID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ListServiceWithRawResponse : IListServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public IListServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ListServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ListServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ListRetrieveResponse>> Retrieve(
        ListRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserID == null)
        {
            throw new CourierInvalidDataException("'parameters.UserID' cannot be null");
        }

        HttpRequest<ListRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var list = await response
                    .Deserialize<ListRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    list.Validate();
                }
                return list;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ListRetrieveResponse>> Retrieve(
        string userID,
        ListRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ListDeleteResponse>> Delete(
        ListDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserID == null)
        {
            throw new CourierInvalidDataException("'parameters.UserID' cannot be null");
        }

        HttpRequest<ListDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var list = await response
                    .Deserialize<ListDeleteResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    list.Validate();
                }
                return list;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ListDeleteResponse>> Delete(
        string userID,
        ListDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ListSubscribeResponse>> Subscribe(
        ListSubscribeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserID == null)
        {
            throw new CourierInvalidDataException("'parameters.UserID' cannot be null");
        }

        HttpRequest<ListSubscribeParams> request = new()
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
                    .Deserialize<ListSubscribeResponse>(token)
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
    public Task<HttpResponse<ListSubscribeResponse>> Subscribe(
        string userID,
        ListSubscribeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Subscribe(parameters with { UserID = userID }, cancellationToken);
    }
}
