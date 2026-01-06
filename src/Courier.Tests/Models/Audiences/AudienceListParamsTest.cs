using System;
using Courier.Models.Audiences;

namespace Courier.Tests.Models.Audiences;

public class AudienceListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AudienceListParams { Cursor = "cursor" };

        string expectedCursor = "cursor";

        Assert.Equal(expectedCursor, parameters.Cursor);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AudienceListParams { };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new AudienceListParams { Cursor = null };

        Assert.Null(parameters.Cursor);
        Assert.True(parameters.RawQueryData.ContainsKey("cursor"));
    }

    [Fact]
    public void Url_Works()
    {
        AudienceListParams parameters = new() { Cursor = "cursor" };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/audiences?cursor=cursor"), url);
    }
}
