using Courier.Models.Users.Tenants;

namespace Courier.Tests.Models.Users.Tenants;

public class TenantRemoveSingleParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TenantRemoveSingleParams
        {
            UserID = "user_id",
            TenantID = "tenant_id",
        };

        string expectedUserID = "user_id";
        string expectedTenantID = "tenant_id";

        Assert.Equal(expectedUserID, parameters.UserID);
        Assert.Equal(expectedTenantID, parameters.TenantID);
    }
}
