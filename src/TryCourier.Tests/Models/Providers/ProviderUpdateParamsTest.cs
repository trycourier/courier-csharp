using System;
using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Models.Providers;

namespace TryCourier.Tests.Models.Providers;

public class ProviderUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProviderUpdateParams
        {
            ID = "id",
            Provider = "sendgrid",
            Alias = "alias",
            Settings = new Dictionary<string, JsonElement>()
            {
                { "api_key", JsonSerializer.SerializeToElement("bar") },
            },
            Title = "Production SendGrid",
        };

        string expectedID = "id";
        string expectedProvider = "sendgrid";
        string expectedAlias = "alias";
        Dictionary<string, JsonElement> expectedSettings = new()
        {
            { "api_key", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedTitle = "Production SendGrid";

        Assert.Equal(expectedID, parameters.ID);
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
        var parameters = new ProviderUpdateParams { ID = "id", Provider = "sendgrid" };

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
        var parameters = new ProviderUpdateParams
        {
            ID = "id",
            Provider = "sendgrid",

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
        ProviderUpdateParams parameters = new() { ID = "id", Provider = "sendgrid" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.courier.com/providers/id"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProviderUpdateParams
        {
            ID = "id",
            Provider = "sendgrid",
            Alias = "alias",
            Settings = new Dictionary<string, JsonElement>()
            {
                { "api_key", JsonSerializer.SerializeToElement("bar") },
            },
            Title = "Production SendGrid",
        };

        ProviderUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
