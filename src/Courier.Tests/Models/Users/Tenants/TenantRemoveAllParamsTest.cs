using System;
using Courier.Models.Users.Tenants;

namespace Courier.Tests.Models.Users.Tenants;

public class TenantRemoveAllParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TenantRemoveAllParams { UserID = "user_id" };

        string expectedUserID = "user_id";

        Assert.Equal(expectedUserID, parameters.UserID);
    }

    [Fact]
    public void Url_Works()
    {
        TenantRemoveAllParams parameters = new() { UserID = "user_id" };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/users/user_id/tenants"), url);
    }
}
