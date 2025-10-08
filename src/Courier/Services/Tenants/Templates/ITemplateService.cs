using System.Threading.Tasks;
using Courier.Models;
using Courier.Models.Tenants.Templates;

namespace Courier.Services.Tenants.Templates;

public interface ITemplateService
{
    /// <summary>
    /// Get a Template in Tenant
    /// </summary>
    Task<BaseTemplateTenantAssociation> Retrieve(TemplateRetrieveParams parameters);

    /// <summary>
    /// List Templates in Tenant
    /// </summary>
    Task<TemplateListResponse> List(TemplateListParams parameters);
}
