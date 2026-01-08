using System;
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

    [Fact]
    public void Url_Works()
    {
        TenantDeleteParams parameters = new() { TenantID = "tenant_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/tenants/tenant_id"), url);
    }
}
