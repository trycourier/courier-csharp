using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Tenants;
using Courier.Models.Tenants.Templates;

namespace Courier.Services.Tenants;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
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
