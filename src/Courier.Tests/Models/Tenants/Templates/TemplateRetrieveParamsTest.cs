using Courier.Models.Tenants.Templates;

namespace Courier.Tests.Models.Tenants.Templates;

public class TemplateRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TemplateRetrieveParams
        {
            TenantID = "tenant_id",
            TemplateID = "template_id",
        };

        string expectedTenantID = "tenant_id";
        string expectedTemplateID = "template_id";

        Assert.Equal(expectedTenantID, parameters.TenantID);
        Assert.Equal(expectedTemplateID, parameters.TemplateID);
    }
}
