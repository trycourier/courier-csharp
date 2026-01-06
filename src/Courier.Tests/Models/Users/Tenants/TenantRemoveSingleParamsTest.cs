using System;
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

    [Fact]
    public void Url_Works()
    {
        TenantRemoveSingleParams parameters = new() { UserID = "user_id", TenantID = "tenant_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/users/user_id/tenants/tenant_id"), url);
    }
}
