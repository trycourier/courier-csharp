using Courier.Models.Tenants;

namespace Courier.Tests.Models.Tenants;

public class TenantRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TenantRetrieveParams { TenantID = "tenant_id" };

        string expectedTenantID = "tenant_id";

        Assert.Equal(expectedTenantID, parameters.TenantID);
    }
}
