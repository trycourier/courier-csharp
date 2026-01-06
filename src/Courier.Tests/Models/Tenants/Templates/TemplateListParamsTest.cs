using System;
using Courier.Models.Tenants.Templates;

namespace Courier.Tests.Models.Tenants.Templates;

public class TemplateListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TemplateListParams
        {
            TenantID = "tenant_id",
            Cursor = "cursor",
            Limit = 0,
        };

        string expectedTenantID = "tenant_id";
        string expectedCursor = "cursor";
        long expectedLimit = 0;

        Assert.Equal(expectedTenantID, parameters.TenantID);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TemplateListParams { TenantID = "tenant_id" };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new TemplateListParams
        {
            TenantID = "tenant_id",

            Cursor = null,
            Limit = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.True(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.True(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void Url_Works()
    {
        TemplateListParams parameters = new()
        {
            TenantID = "tenant_id",
            Cursor = "cursor",
            Limit = 0,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.courier.com/tenants/tenant_id/templates?cursor=cursor&limit=0"),
            url
        );
    }
}
