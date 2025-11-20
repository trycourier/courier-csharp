using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Tenants;
using Courier.Services.Tenants;

namespace Courier.Services;

public sealed class TenantService : ITenantService
{
    public ITenantService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TenantService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public TenantService(ICourierClient client)
    {
        _client = client;
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

    public async Task<Tenant> Retrieve(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var tenant = await response.Deserialize<Tenant>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            tenant.Validate();
        }
        return tenant;
    }

    public async Task<Tenant> Retrieve(
        string tenantID,
        TenantRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(parameters with { TenantID = tenantID }, cancellationToken);
    }

    public async Task<Tenant> Update(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var tenant = await response.Deserialize<Tenant>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            tenant.Validate();
        }
        return tenant;
    }

    public async Task<Tenant> Update(
        string tenantID,
        TenantUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.Update(parameters with { TenantID = tenantID }, cancellationToken);
    }

    public async Task<TenantListResponse> List(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var tenants = await response
            .Deserialize<TenantListResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            tenants.Validate();
        }
        return tenants;
    }

    public async Task Delete(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task Delete(
        string tenantID,
        TenantDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { TenantID = tenantID }, cancellationToken);
    }

    public async Task<TenantListUsersResponse> ListUsers(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<TenantListUsersResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    public async Task<TenantListUsersResponse> ListUsers(
        string tenantID,
        TenantListUsersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.ListUsers(parameters with { TenantID = tenantID }, cancellationToken);
    }
}
