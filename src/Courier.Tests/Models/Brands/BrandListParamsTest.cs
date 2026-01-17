using System;
using Courier.Models.Brands;

namespace Courier.Tests.Models.Brands;

public class BrandListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BrandListParams { Cursor = "cursor" };

        string expectedCursor = "cursor";

        Assert.Equal(expectedCursor, parameters.Cursor);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BrandListParams { };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new BrandListParams { Cursor = null };

        Assert.Null(parameters.Cursor);
        Assert.True(parameters.RawQueryData.ContainsKey("cursor"));
    }

    [Fact]
    public void Url_Works()
    {
        BrandListParams parameters = new() { Cursor = "cursor" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/brands?cursor=cursor"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BrandListParams { Cursor = "cursor" };

        BrandListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
