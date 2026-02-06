using System.Threading.Tasks;

namespace Courier.Tests.Services.Tenants.Templates;

public class VersionServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var baseTemplateTenantAssociation = await this.client.Tenants.Templates.Versions.Retrieve(
            "version",
            new() { TenantID = "tenant_id", TemplateID = "template_id" },
            TestContext.Current.CancellationToken
        );
        baseTemplateTenantAssociation.Validate();
    }
}
