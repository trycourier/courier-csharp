using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Tenants;
using Courier.Services.Tenants;

namespace Courier.Services;

/// <inheritdoc/>
public sealed class TenantService : ITenantService
{
    readonly Lazy<ITenantServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITenantServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public ITenantService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TenantService(this._client.WithOptions(modifier));
    }

    public TenantService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() => new TenantServiceWithRawResponse(client.WithRawResponse));
        _preferences = new(() => new PreferenceService(client));
        _templates = new(() => new TemplateService(client));
    }

    readonly Lazy<IPreferenceService> _preferences;
    public IPreferenceService Preferences
    {
        get { return _preferences.Value; }
    }

    readonly Lazy<ITemplateService> _templates;
    public ITemplateService Templates
    {
        get { return _templates.Value; }
    }

    /// <inheritdoc/>
    public async Task<Tenant> Retrieve(
        TenantRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Tenant> Retrieve(
        string tenantID,
        TenantRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { TenantID = tenantID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Tenant> Update(
        TenantUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Tenant> Update(
        string tenantID,
        TenantUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { TenantID = tenantID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TenantListResponse> List(
        TenantListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Delete(
        TenantDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string tenantID,
        TenantDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { TenantID = tenantID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TenantListUsersResponse> ListUsers(
        TenantListUsersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListUsers(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TenantListUsersResponse> ListUsers(
        string tenantID,
        TenantListUsersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListUsers(parameters with { TenantID = tenantID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class TenantServiceWithRawResponse : ITenantServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITenantServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TenantServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TenantServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;

        _preferences = new(() => new PreferenceServiceWithRawResponse(client));
        _templates = new(() => new TemplateServiceWithRawResponse(client));
    }

    readonly Lazy<IPreferenceServiceWithRawResponse> _preferences;
    public IPreferenceServiceWithRawResponse Preferences
    {
        get { return _preferences.Value; }
    }

    readonly Lazy<ITemplateServiceWithRawResponse> _templates;
    public ITemplateServiceWithRawResponse Templates
    {
        get { return _templates.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Tenant>> Retrieve(
        TenantRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TenantID == null)
        {
            throw new CourierInvalidDataException("'parameters.TenantID' cannot be null");
        }

        HttpRequest<TenantRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var tenant = await response.Deserialize<Tenant>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    tenant.Validate();
                }
                return tenant;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Tenant>> Retrieve(
        string tenantID,
        TenantRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { TenantID = tenantID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Tenant>> Update(
        TenantUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TenantID == null)
        {
            throw new CourierInvalidDataException("'parameters.TenantID' cannot be null");
        }

        HttpRequest<TenantUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var tenant = await response.Deserialize<Tenant>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    tenant.Validate();
                }
                return tenant;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Tenant>> Update(
        string tenantID,
        TenantUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { TenantID = tenantID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TenantListResponse>> List(
        TenantListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

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
    public Task<HttpResponse> Delete(
        TenantDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TenantID == null)
        {
            throw new CourierInvalidDataException("'parameters.TenantID' cannot be null");
        }

        HttpRequest<TenantDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string tenantID,
        TenantDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { TenantID = tenantID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TenantListUsersResponse>> ListUsers(
        TenantListUsersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TenantID == null)
        {
            throw new CourierInvalidDataException("'parameters.TenantID' cannot be null");
        }

        HttpRequest<TenantListUsersParams> request = new()
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
                    .Deserialize<TenantListUsersResponse>(token)
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
    public Task<HttpResponse<TenantListUsersResponse>> ListUsers(
        string tenantID,
        TenantListUsersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListUsers(parameters with { TenantID = tenantID }, cancellationToken);
    }
}
