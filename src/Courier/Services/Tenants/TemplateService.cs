using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Tenants;
using Courier.Models.Tenants.Templates;

namespace Courier.Services.Tenants;

/// <inheritdoc/>
public sealed class TemplateService : ITemplateService
{
    /// <inheritdoc/>
    public ITemplateService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TemplateService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public TemplateService(ICourierClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<BaseTemplateTenantAssociation> Retrieve(
        TemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TemplateID == null)
        {
            throw new CourierInvalidDataException("'parameters.TemplateID' cannot be null");
        }

        HttpRequest<TemplateRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var baseTemplateTenantAssociation = await response
            .Deserialize<BaseTemplateTenantAssociation>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            baseTemplateTenantAssociation.Validate();
        }
        return baseTemplateTenantAssociation;
    }

    /// <inheritdoc/>
    public async Task<BaseTemplateTenantAssociation> Retrieve(
        string templateID,
        TemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.Retrieve(parameters with { TemplateID = templateID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TemplateListResponse> List(
        TemplateListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TenantID == null)
        {
            throw new CourierInvalidDataException("'parameters.TenantID' cannot be null");
        }

        HttpRequest<TemplateListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var templates = await response
            .Deserialize<TemplateListResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            templates.Validate();
        }
        return templates;
    }

    /// <inheritdoc/>
    public async Task<TemplateListResponse> List(
        string tenantID,
        TemplateListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.List(parameters with { TenantID = tenantID }, cancellationToken);
    }
}
