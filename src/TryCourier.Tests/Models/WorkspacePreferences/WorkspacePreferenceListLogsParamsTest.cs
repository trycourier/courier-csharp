using System;
using TryCourier.Models.WorkspacePreferences;

namespace TryCourier.Tests.Models.WorkspacePreferences;

public class WorkspacePreferenceListLogsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WorkspacePreferenceListLogsParams
        {
            Cursor = "cursor",
            Limit = 1,
            Since = "since",
            TenantID = "tenant_id",
            UserID = "user_id",
        };

        string expectedCursor = "cursor";
        long expectedLimit = 1;
        string expectedSince = "since";
        string expectedTenantID = "tenant_id";
        string expectedUserID = "user_id";

        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedSince, parameters.Since);
        Assert.Equal(expectedTenantID, parameters.TenantID);
        Assert.Equal(expectedUserID, parameters.UserID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WorkspacePreferenceListLogsParams { };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Since);
        Assert.False(parameters.RawQueryData.ContainsKey("since"));
        Assert.Null(parameters.TenantID);
        Assert.False(parameters.RawQueryData.ContainsKey("tenant_id"));
        Assert.Null(parameters.UserID);
        Assert.False(parameters.RawQueryData.ContainsKey("user_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WorkspacePreferenceListLogsParams
        {
            // Null should be interpreted as omitted for these properties
            Cursor = null,
            Limit = null,
            Since = null,
            TenantID = null,
            UserID = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Since);
        Assert.False(parameters.RawQueryData.ContainsKey("since"));
        Assert.Null(parameters.TenantID);
        Assert.False(parameters.RawQueryData.ContainsKey("tenant_id"));
        Assert.Null(parameters.UserID);
        Assert.False(parameters.RawQueryData.ContainsKey("user_id"));
    }

    [Fact]
    public void Url_Works()
    {
        WorkspacePreferenceListLogsParams parameters = new()
        {
            Cursor = "cursor",
            Limit = 1,
            Since = "since",
            TenantID = "tenant_id",
            UserID = "user_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.courier.com/preferences/logs?cursor=cursor&limit=1&since=since&tenant_id=tenant_id&user_id=user_id"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WorkspacePreferenceListLogsParams
        {
            Cursor = "cursor",
            Limit = 1,
            Since = "since",
            TenantID = "tenant_id",
            UserID = "user_id",
        };

        WorkspacePreferenceListLogsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
