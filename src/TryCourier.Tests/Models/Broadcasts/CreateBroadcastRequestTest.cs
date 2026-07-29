using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Broadcasts;

namespace TryCourier.Tests.Models.Broadcasts;

public class CreateBroadcastRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreateBroadcastRequest
        {
            Channel = CreateBroadcastRequestChannel.Email,
            Name = "name",
        };

        ApiEnum<string, CreateBroadcastRequestChannel> expectedChannel =
            CreateBroadcastRequestChannel.Email;
        string expectedName = "name";

        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreateBroadcastRequest
        {
            Channel = CreateBroadcastRequestChannel.Email,
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateBroadcastRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreateBroadcastRequest
        {
            Channel = CreateBroadcastRequestChannel.Email,
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateBroadcastRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, CreateBroadcastRequestChannel> expectedChannel =
            CreateBroadcastRequestChannel.Email;
        string expectedName = "name";

        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreateBroadcastRequest
        {
            Channel = CreateBroadcastRequestChannel.Email,
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreateBroadcastRequest
        {
            Channel = CreateBroadcastRequestChannel.Email,
            Name = "name",
        };

        CreateBroadcastRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreateBroadcastRequestChannelTest : TestBase
{
    [Theory]
    [InlineData(CreateBroadcastRequestChannel.Email)]
    [InlineData(CreateBroadcastRequestChannel.Sms)]
    [InlineData(CreateBroadcastRequestChannel.Push)]
    [InlineData(CreateBroadcastRequestChannel.Inbox)]
    [InlineData(CreateBroadcastRequestChannel.Slack)]
    [InlineData(CreateBroadcastRequestChannel.Msteams)]
    public void Validation_Works(CreateBroadcastRequestChannel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreateBroadcastRequestChannel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreateBroadcastRequestChannel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CreateBroadcastRequestChannel.Email)]
    [InlineData(CreateBroadcastRequestChannel.Sms)]
    [InlineData(CreateBroadcastRequestChannel.Push)]
    [InlineData(CreateBroadcastRequestChannel.Inbox)]
    [InlineData(CreateBroadcastRequestChannel.Slack)]
    [InlineData(CreateBroadcastRequestChannel.Msteams)]
    public void SerializationRoundtrip_Works(CreateBroadcastRequestChannel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreateBroadcastRequestChannel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreateBroadcastRequestChannel>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreateBroadcastRequestChannel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreateBroadcastRequestChannel>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
