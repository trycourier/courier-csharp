using System.Threading.Tasks;

namespace Courier.Tests.Services.Tenants;

public class TemplateServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var baseTemplateTenantAssociation = await this.client.Tenants.Templates.Retrieve(
            new() { TenantID = "tenant_id", TemplateID = "template_id" }
        );
        baseTemplateTenantAssociation.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var templates = await this.client.Tenants.Templates.List(new() { TenantID = "tenant_id" });
        templates.Validate();
    }
}
