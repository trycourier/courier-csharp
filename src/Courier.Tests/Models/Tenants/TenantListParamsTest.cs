using System;
using Courier.Models.Tenants;

namespace Courier.Tests.Models.Tenants;

public class TenantListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TenantListParams
        {
            Cursor = "cursor",
            Limit = 0,
            ParentTenantID = "parent_tenant_id",
        };

        string expectedCursor = "cursor";
        long expectedLimit = 0;
        string expectedParentTenantID = "parent_tenant_id";

        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedParentTenantID, parameters.ParentTenantID);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TenantListParams { };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.ParentTenantID);
        Assert.False(parameters.RawQueryData.ContainsKey("parent_tenant_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new TenantListParams
        {
            Cursor = null,
            Limit = null,
            ParentTenantID = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.True(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.True(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.ParentTenantID);
        Assert.True(parameters.RawQueryData.ContainsKey("parent_tenant_id"));
    }

    [Fact]
    public void Url_Works()
    {
        TenantListParams parameters = new()
        {
            Cursor = "cursor",
            Limit = 0,
            ParentTenantID = "parent_tenant_id",
        };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.courier.com/tenants?cursor=cursor&limit=0&parent_tenant_id=parent_tenant_id"
            ),
            url
        );
    }
}
