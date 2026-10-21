using System;
using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Models.Providers;

namespace TryCourier.Tests.Models.Providers;

public class ProviderPatchParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProviderPatchParams
        {
            ID = "id",
            Alias = "alias",
            Provider = "provider",
            Settings = new Dictionary<string, JsonElement>()
            {
                { "api_key", JsonSerializer.SerializeToElement("bar") },
            },
            Title = "Production SendGrid",
        };

        string expectedID = "id";
        string expectedAlias = "alias";
        string expectedProvider = "provider";
        Dictionary<string, JsonElement> expectedSettings = new()
        {
            { "api_key", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedTitle = "Production SendGrid";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedAlias, parameters.Alias);
        Assert.Equal(expectedProvider, parameters.Provider);
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
        var parameters = new ProviderPatchParams { ID = "id", Alias = "alias" };

        Assert.Null(parameters.Provider);
        Assert.False(parameters.RawBodyData.ContainsKey("provider"));
        Assert.Null(parameters.Settings);
        Assert.False(parameters.RawBodyData.ContainsKey("settings"));
        Assert.Null(parameters.Title);
        Assert.False(parameters.RawBodyData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ProviderPatchParams
        {
            ID = "id",
            Alias = "alias",

            // Null should be interpreted as omitted for these properties
            Provider = null,
            Settings = null,
            Title = null,
        };

        Assert.Null(parameters.Provider);
        Assert.False(parameters.RawBodyData.ContainsKey("provider"));
        Assert.Null(parameters.Settings);
        Assert.False(parameters.RawBodyData.ContainsKey("settings"));
        Assert.Null(parameters.Title);
        Assert.False(parameters.RawBodyData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProviderPatchParams
        {
            ID = "id",
            Provider = "provider",
            Settings = new Dictionary<string, JsonElement>()
            {
                { "api_key", JsonSerializer.SerializeToElement("bar") },
            },
            Title = "Production SendGrid",
        };

        Assert.Null(parameters.Alias);
        Assert.False(parameters.RawBodyData.ContainsKey("alias"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ProviderPatchParams
        {
            ID = "id",
            Provider = "provider",
            Settings = new Dictionary<string, JsonElement>()
            {
                { "api_key", JsonSerializer.SerializeToElement("bar") },
            },
            Title = "Production SendGrid",

            Alias = null,
        };

        Assert.Null(parameters.Alias);
        Assert.True(parameters.RawBodyData.ContainsKey("alias"));
    }

    [Fact]
    public void Url_Works()
    {
        ProviderPatchParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.courier.com/providers/id"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProviderPatchParams
        {
            ID = "id",
            Alias = "alias",
            Provider = "provider",
            Settings = new Dictionary<string, JsonElement>()
            {
                { "api_key", JsonSerializer.SerializeToElement("bar") },
            },
            Title = "Production SendGrid",
        };

        ProviderPatchParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
