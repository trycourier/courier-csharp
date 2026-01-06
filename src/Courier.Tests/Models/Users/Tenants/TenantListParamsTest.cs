using System;
using Courier.Models.Users.Tenants;

namespace Courier.Tests.Models.Users.Tenants;

public class TenantListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TenantListParams
        {
            UserID = "user_id",
            Cursor = "cursor",
            Limit = 0,
        };

        string expectedUserID = "user_id";
        string expectedCursor = "cursor";
        long expectedLimit = 0;

        Assert.Equal(expectedUserID, parameters.UserID);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TenantListParams { UserID = "user_id" };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new TenantListParams
        {
            UserID = "user_id",

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
        TenantListParams parameters = new()
        {
            UserID = "user_id",
            Cursor = "cursor",
            Limit = 0,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.courier.com/users/user_id/tenants?cursor=cursor&limit=0"),
            url
        );
    }
}
