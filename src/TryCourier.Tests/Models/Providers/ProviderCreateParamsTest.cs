using System;
using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Models.Providers;

namespace TryCourier.Tests.Models.Providers;

public class ProviderCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProviderCreateParams
        {
            Provider = "provider",
            Alias = "alias",
            Settings = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Title = "title",
        };

        string expectedProvider = "provider";
        string expectedAlias = "alias";
        Dictionary<string, JsonElement> expectedSettings = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedTitle = "title";

        Assert.Equal(expectedProvider, parameters.Provider);
        Assert.Equal(expectedAlias, parameters.Alias);
        Assert.NotNull(parameters.Settings);
        Assert.Equal(expectedSettings.Count, parameters.Settings.Count);
        foreach (var item in expectedSettings)
        {
            Assert.True(parameters.Settings.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.Settings[item.Key]));
        }
        Assert.Equal(expectedTitle, parameters.Title);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProviderCreateParams { Provider = "provider" };

        Assert.Null(parameters.Alias);
        Assert.False(parameters.RawBodyData.ContainsKey("alias"));
        Assert.Null(parameters.Settings);
        Assert.False(parameters.RawBodyData.ContainsKey("settings"));
        Assert.Null(parameters.Title);
        Assert.False(parameters.RawBodyData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ProviderCreateParams
        {
            Provider = "provider",

            // Null should be interpreted as omitted for these properties
            Alias = null,
            Settings = null,
            Title = null,
        };

        Assert.Null(parameters.Alias);
        Assert.False(parameters.RawBodyData.ContainsKey("alias"));
        Assert.Null(parameters.Settings);
        Assert.False(parameters.RawBodyData.ContainsKey("settings"));
        Assert.Null(parameters.Title);
        Assert.False(parameters.RawBodyData.ContainsKey("title"));
    }

    [Fact]
    public void Url_Works()
    {
        ProviderCreateParams parameters = new() { Provider = "provider" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.courier.com/providers"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProviderCreateParams
        {
            Provider = "provider",
            Alias = "alias",
            Settings = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Title = "title",
        };

        ProviderCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
