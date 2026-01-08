using System;
using Courier.Models.AuditEvents;

namespace Courier.Tests.Models.AuditEvents;

public class AuditEventListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AuditEventListParams { Cursor = "cursor" };

        string expectedCursor = "cursor";

        Assert.Equal(expectedCursor, parameters.Cursor);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AuditEventListParams { };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new AuditEventListParams { Cursor = null };

        Assert.Null(parameters.Cursor);
        Assert.True(parameters.RawQueryData.ContainsKey("cursor"));
    }

    [Fact]
    public void Url_Works()
    {
        AuditEventListParams parameters = new() { Cursor = "cursor" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/audit-events?cursor=cursor"), url);
    }
}
