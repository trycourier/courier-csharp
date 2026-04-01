using System;
using Courier.Models.Providers.Catalog;

namespace Courier.Tests.Models.Providers.Catalog;

public class CatalogListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CatalogListParams
        {
            Channel = "channel",
            Keys = "keys",
            Name = "name",
        };

        string expectedChannel = "channel";
        string expectedKeys = "keys";
        string expectedName = "name";

        Assert.Equal(expectedChannel, parameters.Channel);
        Assert.Equal(expectedKeys, parameters.Keys);
        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CatalogListParams { };

        Assert.Null(parameters.Channel);
        Assert.False(parameters.RawQueryData.ContainsKey("channel"));
        Assert.Null(parameters.Keys);
        Assert.False(parameters.RawQueryData.ContainsKey("keys"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawQueryData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CatalogListParams
        {
            // Null should be interpreted as omitted for these properties
            Channel = null,
            Keys = null,
            Name = null,
        };

        Assert.Null(parameters.Channel);
        Assert.False(parameters.RawQueryData.ContainsKey("channel"));
        Assert.Null(parameters.Keys);
        Assert.False(parameters.RawQueryData.ContainsKey("keys"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawQueryData.ContainsKey("name"));
    }

    [Fact]
    public void Url_Works()
    {
        CatalogListParams parameters = new()
        {
            Channel = "channel",
            Keys = "keys",
            Name = "name",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.courier.com/providers/catalog?channel=channel&keys=keys&name=name"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CatalogListParams
        {
            Channel = "channel",
            Keys = "keys",
            Name = "name",
        };

        CatalogListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
