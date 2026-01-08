using System;
using Courier.Models.Audiences;

namespace Courier.Tests.Models.Audiences;

public class AudienceListMembersParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AudienceListMembersParams
        {
            AudienceID = "audience_id",
            Cursor = "cursor",
        };

        string expectedAudienceID = "audience_id";
        string expectedCursor = "cursor";

        Assert.Equal(expectedAudienceID, parameters.AudienceID);
        Assert.Equal(expectedCursor, parameters.Cursor);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AudienceListMembersParams { AudienceID = "audience_id" };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new AudienceListMembersParams
        {
            AudienceID = "audience_id",

            Cursor = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.True(parameters.RawQueryData.ContainsKey("cursor"));
    }

    [Fact]
    public void Url_Works()
    {
        AudienceListMembersParams parameters = new()
        {
            AudienceID = "audience_id",
            Cursor = "cursor",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.courier.com/audiences/audience_id/members?cursor=cursor"),
            url
        );
    }
}
