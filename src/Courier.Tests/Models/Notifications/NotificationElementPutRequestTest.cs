using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models.Notifications;

namespace Courier.Tests.Models.Notifications;

public class NotificationElementPutRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NotificationElementPutRequest
        {
            Type = "type",
            Channels = ["string"],
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            If = "if",
            Loop = "loop",
            Ref = "ref",
            State = NotificationTemplateState.Draft,
        };

        string expectedType = "type";
        List<string> expectedChannels = ["string"];
        Dictionary<string, JsonElement> expectedData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedIf = "if";
        string expectedLoop = "loop";
        string expectedRef = "ref";
        ApiEnum<string, NotificationTemplateState> expectedState = NotificationTemplateState.Draft;

        Assert.Equal(expectedType, model.Type);
        Assert.NotNull(model.Channels);
        Assert.Equal(expectedChannels.Count, model.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], model.Channels[i]);
        }
        Assert.NotNull(model.Data);
        Assert.Equal(expectedData.Count, model.Data.Count);
        foreach (var item in expectedData)
        {
            Assert.True(model.Data.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Data[item.Key]));
        }
        Assert.Equal(expectedIf, model.If);
        Assert.Equal(expectedLoop, model.Loop);
        Assert.Equal(expectedRef, model.Ref);
        Assert.Equal(expectedState, model.State);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NotificationElementPutRequest
        {
            Type = "type",
            Channels = ["string"],
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            If = "if",
            Loop = "loop",
            Ref = "ref",
            State = NotificationTemplateState.Draft,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotificationElementPutRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NotificationElementPutRequest
        {
            Type = "type",
            Channels = ["string"],
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            If = "if",
            Loop = "loop",
            Ref = "ref",
            State = NotificationTemplateState.Draft,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotificationElementPutRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedType = "type";
        List<string> expectedChannels = ["string"];
        Dictionary<string, JsonElement> expectedData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedIf = "if";
        string expectedLoop = "loop";
        string expectedRef = "ref";
        ApiEnum<string, NotificationTemplateState> expectedState = NotificationTemplateState.Draft;

        Assert.Equal(expectedType, deserialized.Type);
        Assert.NotNull(deserialized.Channels);
        Assert.Equal(expectedChannels.Count, deserialized.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], deserialized.Channels[i]);
        }
        Assert.NotNull(deserialized.Data);
        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        foreach (var item in expectedData)
        {
            Assert.True(deserialized.Data.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Data[item.Key]));
        }
        Assert.Equal(expectedIf, deserialized.If);
        Assert.Equal(expectedLoop, deserialized.Loop);
        Assert.Equal(expectedRef, deserialized.Ref);
        Assert.Equal(expectedState, deserialized.State);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NotificationElementPutRequest
        {
            Type = "type",
            Channels = ["string"],
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            If = "if",
            Loop = "loop",
            Ref = "ref",
            State = NotificationTemplateState.Draft,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NotificationElementPutRequest { Type = "type" };

        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.If);
        Assert.False(model.RawData.ContainsKey("if"));
        Assert.Null(model.Loop);
        Assert.False(model.RawData.ContainsKey("loop"));
        Assert.Null(model.Ref);
        Assert.False(model.RawData.ContainsKey("ref"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new NotificationElementPutRequest { Type = "type" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new NotificationElementPutRequest
        {
            Type = "type",

            // Null should be interpreted as omitted for these properties
            Channels = null,
            Data = null,
            If = null,
            Loop = null,
            Ref = null,
            State = null,
        };

        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.If);
        Assert.False(model.RawData.ContainsKey("if"));
        Assert.Null(model.Loop);
        Assert.False(model.RawData.ContainsKey("loop"));
        Assert.Null(model.Ref);
        Assert.False(model.RawData.ContainsKey("ref"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NotificationElementPutRequest
        {
            Type = "type",

            // Null should be interpreted as omitted for these properties
            Channels = null,
            Data = null,
            If = null,
            Loop = null,
            Ref = null,
            State = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NotificationElementPutRequest
        {
            Type = "type",
            Channels = ["string"],
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            If = "if",
            Loop = "loop",
            Ref = "ref",
            State = NotificationTemplateState.Draft,
        };

        NotificationElementPutRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}
