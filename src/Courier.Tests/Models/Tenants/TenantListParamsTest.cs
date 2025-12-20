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
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.ParentTenantID);
        Assert.False(parameters.RawQueryData.ContainsKey("parent_tenant_id"));
    }
}
