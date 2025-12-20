using Courier.Models.Tenants;

namespace Courier.Tests.Models.Tenants;

public class TenantDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TenantDeleteParams { TenantID = "tenant_id" };

        string expectedTenantID = "tenant_id";

        Assert.Equal(expectedTenantID, parameters.TenantID);
    }
}
