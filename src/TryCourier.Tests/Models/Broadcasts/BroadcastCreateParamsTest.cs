using System;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Broadcasts;

namespace TryCourier.Tests.Models.Broadcasts;

public class BroadcastCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BroadcastCreateParams
        {
            Channel = Channel.Email,
            Name = "Spring Sale Announcement",
        };

        ApiEnum<string, Channel> expectedChannel = Channel.Email;
        string expectedName = "Spring Sale Announcement";

        Assert.Equal(expectedChannel, parameters.Channel);
        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void Url_Works()
    {
        BroadcastCreateParams parameters = new()
        {
            Channel = Channel.Email,
            Name = "Spring Sale Announcement",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.courier.com/broadcasts"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BroadcastCreateParams
        {
            Channel = Channel.Email,
            Name = "Spring Sale Announcement",
        };

        BroadcastCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ChannelTest : TestBase
{
    [Theory]
    [InlineData(Channel.Email)]
    [InlineData(Channel.Sms)]
    [InlineData(Channel.Push)]
    [InlineData(Channel.Inbox)]
    [InlineData(Channel.Slack)]
    [InlineData(Channel.Msteams)]
    public void Validation_Works(Channel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Channel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Channel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Channel.Email)]
    [InlineData(Channel.Sms)]
    [InlineData(Channel.Push)]
    [InlineData(Channel.Inbox)]
    [InlineData(Channel.Slack)]
    [InlineData(Channel.Msteams)]
    public void SerializationRoundtrip_Works(Channel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Channel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Channel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Channel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Channel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
