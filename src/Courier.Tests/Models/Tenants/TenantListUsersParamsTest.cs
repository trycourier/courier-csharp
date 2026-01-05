using Courier.Models.Tenants;

namespace Courier.Tests.Models.Tenants;

public class TenantListUsersParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TenantListUsersParams
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
        var parameters = new TenantListUsersParams { TenantID = "tenant_id" };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new TenantListUsersParams
        {
            TenantID = "tenant_id",

            Cursor = null,
            Limit = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }
}
