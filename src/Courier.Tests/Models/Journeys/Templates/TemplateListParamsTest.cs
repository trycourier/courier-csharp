using System;
using Courier.Models.Journeys.Templates;

namespace Courier.Tests.Models.Journeys.Templates;

public class TemplateListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TemplateListParams
        {
            TemplateID = "x",
            Cursor = "cursor",
            Limit = 1,
        };

        string expectedTemplateID = "x";
        string expectedCursor = "cursor";
        long expectedLimit = 1;

        Assert.Equal(expectedTemplateID, parameters.TemplateID);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TemplateListParams { TemplateID = "x" };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TemplateListParams
        {
            TemplateID = "x",

            // Null should be interpreted as omitted for these properties
            Cursor = null,
            Limit = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void Url_Works()
    {
        TemplateListParams parameters = new()
        {
            TemplateID = "x",
            Cursor = "cursor",
            Limit = 1,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.courier.com/journeys/x/templates?cursor=cursor&limit=1"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TemplateListParams
        {
            TemplateID = "x",
            Cursor = "cursor",
            Limit = 1,
        };

        TemplateListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
