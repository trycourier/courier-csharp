using System;
using System.Net.Http;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Services.Tenants.Templates;
using Courier.Services.Tenants.TenantDefaultPreferences;
using Tenants = Courier.Models.Tenants;

namespace Courier.Services.Tenants;

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

    public async Task<Tenants::Tenant> Retrieve(Tenants::TenantRetrieveParams parameters)
    {
        HttpRequest<Tenants::TenantRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var tenant = await response.Deserialize<Tenants::Tenant>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            tenant.Validate();
        }
        return tenant;
    }

    public async Task<Tenants::Tenant> Update(Tenants::TenantUpdateParams parameters)
    {
        HttpRequest<Tenants::TenantUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var tenant = await response.Deserialize<Tenants::Tenant>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            tenant.Validate();
        }
        return tenant;
    }

    public async Task<Tenants::TenantListResponse> List(
        Tenants::TenantListParams? parameters = null
    )
    {
        parameters ??= new();

        HttpRequest<Tenants::TenantListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var tenants = await response
            .Deserialize<Tenants::TenantListResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            tenants.Validate();
        }
        return tenants;
    }

    public async Task Delete(Tenants::TenantDeleteParams parameters)
    {
        HttpRequest<Tenants::TenantDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
    }

    public async Task<Tenants::TenantListUsersResponse> ListUsers(
        Tenants::TenantListUsersParams parameters
    )
    {
        HttpRequest<Tenants::TenantListUsersParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<Tenants::TenantListUsersResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
