using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models;

namespace Courier.Tests.Models;

public class ChannelClassificationTest : TestBase
{
    [Theory]
    [InlineData(ChannelClassification.DirectMessage)]
    [InlineData(ChannelClassification.Email)]
    [InlineData(ChannelClassification.Push)]
    [InlineData(ChannelClassification.SMS)]
    [InlineData(ChannelClassification.Webhook)]
    [InlineData(ChannelClassification.Inbox)]
    public void Validation_Works(ChannelClassification rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChannelClassification> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChannelClassification>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChannelClassification.DirectMessage)]
    [InlineData(ChannelClassification.Email)]
    [InlineData(ChannelClassification.Push)]
    [InlineData(ChannelClassification.SMS)]
    [InlineData(ChannelClassification.Webhook)]
    [InlineData(ChannelClassification.Inbox)]
    public void SerializationRoundtrip_Works(ChannelClassification rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChannelClassification> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ChannelClassification>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChannelClassification>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ChannelClassification>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
