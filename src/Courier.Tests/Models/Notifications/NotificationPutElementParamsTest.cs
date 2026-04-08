using System;
using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models.Notifications;

namespace Courier.Tests.Models.Notifications;

public class NotificationPutElementParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NotificationPutElementParams
        {
            ID = "id",
            ElementID = "elementId",
            Type = "text",
            Channels = ["string"],
            Data = new Dictionary<string, JsonElement>()
            {
                { "content", JsonSerializer.SerializeToElement("bar") },
            },
            If = "if",
            Loop = "loop",
            Ref = "ref",
            State = NotificationTemplateState.Draft,
        };

        string expectedID = "id";
        string expectedElementID = "elementId";
        string expectedType = "text";
        List<string> expectedChannels = ["string"];
        Dictionary<string, JsonElement> expectedData = new()
        {
            { "content", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedIf = "if";
        string expectedLoop = "loop";
        string expectedRef = "ref";
        ApiEnum<string, NotificationTemplateState> expectedState = NotificationTemplateState.Draft;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedElementID, parameters.ElementID);
        Assert.Equal(expectedType, parameters.Type);
        Assert.NotNull(parameters.Channels);
        Assert.Equal(expectedChannels.Count, parameters.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], parameters.Channels[i]);
        }
        Assert.NotNull(parameters.Data);
        Assert.Equal(expectedData.Count, parameters.Data.Count);
        foreach (var item in expectedData)
        {
            Assert.True(parameters.Data.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.Data[item.Key]));
        }
        Assert.Equal(expectedIf, parameters.If);
        Assert.Equal(expectedLoop, parameters.Loop);
        Assert.Equal(expectedRef, parameters.Ref);
        Assert.Equal(expectedState, parameters.State);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new NotificationPutElementParams
        {
            ID = "id",
            ElementID = "elementId",
            Type = "text",
        };

        Assert.Null(parameters.Channels);
        Assert.False(parameters.RawBodyData.ContainsKey("channels"));
        Assert.Null(parameters.Data);
        Assert.False(parameters.RawBodyData.ContainsKey("data"));
        Assert.Null(parameters.If);
        Assert.False(parameters.RawBodyData.ContainsKey("if"));
        Assert.Null(parameters.Loop);
        Assert.False(parameters.RawBodyData.ContainsKey("loop"));
        Assert.Null(parameters.Ref);
        Assert.False(parameters.RawBodyData.ContainsKey("ref"));
        Assert.Null(parameters.State);
        Assert.False(parameters.RawBodyData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new NotificationPutElementParams
        {
            ID = "id",
            ElementID = "elementId",
            Type = "text",

            // Null should be interpreted as omitted for these properties
            Channels = null,
            Data = null,
            If = null,
            Loop = null,
            Ref = null,
            State = null,
        };

        Assert.Null(parameters.Channels);
        Assert.False(parameters.RawBodyData.ContainsKey("channels"));
        Assert.Null(parameters.Data);
        Assert.False(parameters.RawBodyData.ContainsKey("data"));
        Assert.Null(parameters.If);
        Assert.False(parameters.RawBodyData.ContainsKey("if"));
        Assert.Null(parameters.Loop);
        Assert.False(parameters.RawBodyData.ContainsKey("loop"));
        Assert.Null(parameters.Ref);
        Assert.False(parameters.RawBodyData.ContainsKey("ref"));
        Assert.Null(parameters.State);
        Assert.False(parameters.RawBodyData.ContainsKey("state"));
    }

    [Fact]
    public void Url_Works()
    {
        NotificationPutElementParams parameters = new()
        {
            ID = "id",
            ElementID = "elementId",
            Type = "text",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/notifications/id/elements/elementId"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new NotificationPutElementParams
        {
            ID = "id",
            ElementID = "elementId",
            Type = "text",
            Channels = ["string"],
            Data = new Dictionary<string, JsonElement>()
            {
                { "content", JsonSerializer.SerializeToElement("bar") },
            },
            If = "if",
            Loop = "loop",
            Ref = "ref",
            State = NotificationTemplateState.Draft,
        };

        NotificationPutElementParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
