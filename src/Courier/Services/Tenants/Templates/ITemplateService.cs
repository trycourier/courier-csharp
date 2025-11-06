using System;
using System.Threading.Tasks;
using Courier.Core;
using Templates = Courier.Models.Tenants.Templates;
using Tenants = Courier.Models.Tenants;

namespace Courier.Services.Tenants.Templates;

public interface ITemplateService
{
    ITemplateService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get a Template in Tenant
    /// </summary>
    Task<Tenants::BaseTemplateTenantAssociation> Retrieve(
        Templates::TemplateRetrieveParams parameters
    );

    /// <summary>
    /// List Templates in Tenant
    /// </summary>
    Task<Templates::TemplateListResponse> List(Templates::TemplateListParams parameters);
}
