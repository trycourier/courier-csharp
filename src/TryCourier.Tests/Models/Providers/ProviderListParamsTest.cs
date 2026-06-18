using System;
using TryCourier.Models.Providers;

namespace TryCourier.Tests.Models.Providers;

public class ProviderListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProviderListParams { Cursor = "cursor" };

        string expectedCursor = "cursor";

        Assert.Equal(expectedCursor, parameters.Cursor);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProviderListParams { };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ProviderListParams
        {
            // Null should be interpreted as omitted for these properties
            Cursor = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
    }

    [Fact]
    public void Url_Works()
    {
        ProviderListParams parameters = new() { Cursor = "cursor" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.courier.com/providers?cursor=cursor"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProviderListParams { Cursor = "cursor" };

        ProviderListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
