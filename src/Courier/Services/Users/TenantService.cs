using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Users.Tenants;

namespace Courier.Services.Users;

/// <inheritdoc/>
public sealed class TenantService : global::Courier.Services.Users.ITenantService
{
    readonly Lazy<global::Courier.Services.Users.ITenantServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public global::Courier.Services.Users.ITenantServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public global::Courier.Services.Users.ITenantService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new global::Courier.Services.Users.TenantService(this._client.WithOptions(modifier));
    }

    public TenantService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new global::Courier.Services.Users.TenantServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<TenantListResponse> List(
        TenantListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TenantListResponse> List(
        string userID,
        TenantListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task AddMultiple(
        TenantAddMultipleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.AddMultiple(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task AddMultiple(
        string userID,
        TenantAddMultipleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.AddMultiple(parameters with { UserID = userID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task AddSingle(
        TenantAddSingleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.AddSingle(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task AddSingle(
        string tenantID,
        TenantAddSingleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.AddSingle(parameters with { TenantID = tenantID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task RemoveAll(
        TenantRemoveAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RemoveAll(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task RemoveAll(
        string userID,
        TenantRemoveAllParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.RemoveAll(parameters with { UserID = userID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task RemoveSingle(
        TenantRemoveSingleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RemoveSingle(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task RemoveSingle(
        string tenantID,
        TenantRemoveSingleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.RemoveSingle(parameters with { TenantID = tenantID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class TenantServiceWithRawResponse
    : global::Courier.Services.Users.ITenantServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public global::Courier.Services.Users.ITenantServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new global::Courier.Services.Users.TenantServiceWithRawResponse(
            this._client.WithOptions(modifier)
        );
    }

    public TenantServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TenantListResponse>> List(
        TenantListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserID == null)
        {
            throw new CourierInvalidDataException("'parameters.UserID' cannot be null");
        }

        HttpRequest<TenantListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var tenants = await response
                    .Deserialize<TenantListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    tenants.Validate();
                }
                return tenants;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<TenantListResponse>> List(
        string userID,
        TenantListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> AddMultiple(
        TenantAddMultipleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserID == null)
        {
            throw new CourierInvalidDataException("'parameters.UserID' cannot be null");
        }

        HttpRequest<TenantAddMultipleParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> AddMultiple(
        string userID,
        TenantAddMultipleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.AddMultiple(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> AddSingle(
        TenantAddSingleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TenantID == null)
        {
            throw new CourierInvalidDataException("'parameters.TenantID' cannot be null");
        }

        HttpRequest<TenantAddSingleParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> AddSingle(
        string tenantID,
        TenantAddSingleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.AddSingle(parameters with { TenantID = tenantID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> RemoveAll(
        TenantRemoveAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserID == null)
        {
            throw new CourierInvalidDataException("'parameters.UserID' cannot be null");
        }

        HttpRequest<TenantRemoveAllParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> RemoveAll(
        string userID,
        TenantRemoveAllParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RemoveAll(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> RemoveSingle(
        TenantRemoveSingleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TenantID == null)
        {
            throw new CourierInvalidDataException("'parameters.TenantID' cannot be null");
        }

        HttpRequest<TenantRemoveSingleParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> RemoveSingle(
        string tenantID,
        TenantRemoveSingleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RemoveSingle(parameters with { TenantID = tenantID }, cancellationToken);
    }
}
