using System.Threading.Tasks;

namespace Courier.Tests.Services.Tenants;

public class TemplateServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var baseTemplateTenantAssociation = await this.client.Tenants.Templates.Retrieve(
            "template_id",
            new() { TenantID = "tenant_id" },
            TestContext.Current.CancellationToken
        );
        baseTemplateTenantAssociation.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var templates = await this.client.Tenants.Templates.List(
            "tenant_id",
            new(),
            TestContext.Current.CancellationToken
        );
        templates.Validate();
    }
}
