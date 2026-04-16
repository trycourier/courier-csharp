using System;
using System.Collections.Generic;
using System.Text.Json;
using Courier.Models.Journeys;

namespace Courier.Tests.Models.Journeys;

public class JourneyInvokeParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new JourneyInvokeParams
        {
            TemplateID = "templateId",
            Data = new Dictionary<string, JsonElement>()
            {
                { "order_id", JsonSerializer.SerializeToElement("bar") },
                { "amount", JsonSerializer.SerializeToElement("bar") },
            },
            Profile = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            UserID = "user-123",
        };

        string expectedTemplateID = "templateId";
        Dictionary<string, JsonElement> expectedData = new()
        {
            { "order_id", JsonSerializer.SerializeToElement("bar") },
            { "amount", JsonSerializer.SerializeToElement("bar") },
        };
        Dictionary<string, JsonElement> expectedProfile = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedUserID = "user-123";

        Assert.Equal(expectedTemplateID, parameters.TemplateID);
        Assert.NotNull(parameters.Data);
        Assert.Equal(expectedData.Count, parameters.Data.Count);
        foreach (var item in expectedData)
        {
            Assert.True(parameters.Data.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.Data[item.Key]));
        }
        Assert.NotNull(parameters.Profile);
        Assert.Equal(expectedProfile.Count, parameters.Profile.Count);
        foreach (var item in expectedProfile)
        {
            Assert.True(parameters.Profile.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.Profile[item.Key]));
        }
        Assert.Equal(expectedUserID, parameters.UserID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new JourneyInvokeParams { TemplateID = "templateId" };

        Assert.Null(parameters.Data);
        Assert.False(parameters.RawBodyData.ContainsKey("data"));
        Assert.Null(parameters.Profile);
        Assert.False(parameters.RawBodyData.ContainsKey("profile"));
        Assert.Null(parameters.UserID);
        Assert.False(parameters.RawBodyData.ContainsKey("user_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new JourneyInvokeParams
        {
            TemplateID = "templateId",

            // Null should be interpreted as omitted for these properties
            Data = null,
            Profile = null,
            UserID = null,
        };

        Assert.Null(parameters.Data);
        Assert.False(parameters.RawBodyData.ContainsKey("data"));
        Assert.Null(parameters.Profile);
        Assert.False(parameters.RawBodyData.ContainsKey("profile"));
        Assert.Null(parameters.UserID);
        Assert.False(parameters.RawBodyData.ContainsKey("user_id"));
    }

    [Fact]
    public void Url_Works()
    {
        JourneyInvokeParams parameters = new() { TemplateID = "templateId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.courier.com/journeys/templateId/invoke"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new JourneyInvokeParams
        {
            TemplateID = "templateId",
            Data = new Dictionary<string, JsonElement>()
            {
                { "order_id", JsonSerializer.SerializeToElement("bar") },
                { "amount", JsonSerializer.SerializeToElement("bar") },
            },
            Profile = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            UserID = "user-123",
        };

        JourneyInvokeParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
