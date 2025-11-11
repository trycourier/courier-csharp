using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Tenants;
using Courier.Models.Tenants.Templates;

namespace Courier.Services.Tenants.Templates;

public interface ITemplateService
{
    ITemplateService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get a Template in Tenant
    /// </summary>
    Task<BaseTemplateTenantAssociation> Retrieve(
        TemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Templates in Tenant
    /// </summary>
    Task<TemplateListResponse> List(
        TemplateListParams parameters,
        CancellationToken cancellationToken = default
    );
}
