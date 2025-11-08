using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Services.Tenants.Preferences;
using Courier.Services.Tenants.Templates;
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

    public async Task<Tenants::Tenant> Retrieve(
        Tenants::TenantRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Tenants::TenantRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var tenant = await response
            .Deserialize<Tenants::Tenant>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            tenant.Validate();
        }
        return tenant;
    }

    public async Task<Tenants::Tenant> Update(
        Tenants::TenantUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Tenants::TenantUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var tenant = await response
            .Deserialize<Tenants::Tenant>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            tenant.Validate();
        }
        return tenant;
    }

    public async Task<Tenants::TenantListResponse> List(
        Tenants::TenantListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<Tenants::TenantListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var tenants = await response
            .Deserialize<Tenants::TenantListResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            tenants.Validate();
        }
        return tenants;
    }

    public async Task Delete(
        Tenants::TenantDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Tenants::TenantDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task<Tenants::TenantListUsersResponse> ListUsers(
        Tenants::TenantListUsersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Tenants::TenantListUsersParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<Tenants::TenantListUsersResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
