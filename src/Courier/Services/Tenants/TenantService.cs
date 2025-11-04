using System;
using System.Net.Http;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Tenants;
using Courier.Services.Tenants.Templates;
using Courier.Services.Tenants.TenantDefaultPreferences;

namespace Courier.Services.Tenants;

public sealed class TenantService : ITenantService
{
    readonly ICourierClient _client;

    public TenantService(ICourierClient client)
    {
        _client = client;
        _tenantDefaultPreferences = new(() => new TenantDefaultPreferenceService(client));
        _templates = new(() => new TemplateService(client));
    }

    readonly Lazy<ITenantDefaultPreferenceService> _tenantDefaultPreferences;
    public ITenantDefaultPreferenceService TenantDefaultPreferences
    {
        get { return _tenantDefaultPreferences.Value; }
    }

    readonly Lazy<ITemplateService> _templates;
    public ITemplateService Templates
    {
        get { return _templates.Value; }
    }

    public async Task<Tenant> Retrieve(TenantRetrieveParams parameters)
    {
        HttpRequest<TenantRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var tenant = await response.Deserialize<Tenant>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            tenant.Validate();
        }
        return tenant;
    }

    public async Task<Tenant> Update(TenantUpdateParams parameters)
    {
        HttpRequest<TenantUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var tenant = await response.Deserialize<Tenant>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            tenant.Validate();
        }
        return tenant;
    }

    public async Task<TenantListResponse> List(TenantListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<TenantListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var tenants = await response.Deserialize<TenantListResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            tenants.Validate();
        }
        return tenants;
    }

    public async Task Delete(TenantDeleteParams parameters)
    {
        HttpRequest<TenantDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
    }

    public async Task<TenantListUsersResponse> ListUsers(TenantListUsersParams parameters)
    {
        HttpRequest<TenantListUsersParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<TenantListUsersResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
