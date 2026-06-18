using System;
using TryCourier.Models.Users.Tenants;

namespace TryCourier.Tests.Models.Users.Tenants;

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

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.courier.com/users/user_id/tenants/tenant_id"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TenantRemoveSingleParams
        {
            UserID = "user_id",
            TenantID = "tenant_id",
        };

        TenantRemoveSingleParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
