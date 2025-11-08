using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Templates = Courier.Models.Tenants.Templates;
using Tenants = Courier.Models.Tenants;

namespace Courier.Services.Tenants.Templates;

public sealed class TemplateService : ITemplateService
{
    public ITemplateService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TemplateService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public TemplateService(ICourierClient client)
    {
        _client = client;
    }

    public async Task<Tenants::BaseTemplateTenantAssociation> Retrieve(
        Templates::TemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Templates::TemplateRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var baseTemplateTenantAssociation = await response
            .Deserialize<Tenants::BaseTemplateTenantAssociation>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            baseTemplateTenantAssociation.Validate();
        }
        return baseTemplateTenantAssociation;
    }

    public async Task<Templates::TemplateListResponse> List(
        Templates::TemplateListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Templates::TemplateListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var templates = await response
            .Deserialize<Templates::TemplateListResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            templates.Validate();
        }
        return templates;
    }
}
