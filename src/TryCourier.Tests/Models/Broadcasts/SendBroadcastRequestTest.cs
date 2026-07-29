using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Broadcasts;

namespace TryCourier.Tests.Models.Broadcasts;

public class SendBroadcastRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SendBroadcastRequest
        {
            RecipientID = "recipient_id",
            RecipientType = SendBroadcastRequestRecipientType.List,
        };

        string expectedRecipientID = "recipient_id";
        ApiEnum<string, SendBroadcastRequestRecipientType> expectedRecipientType =
            SendBroadcastRequestRecipientType.List;

        Assert.Equal(expectedRecipientID, model.RecipientID);
        Assert.Equal(expectedRecipientType, model.RecipientType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SendBroadcastRequest
        {
            RecipientID = "recipient_id",
            RecipientType = SendBroadcastRequestRecipientType.List,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SendBroadcastRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SendBroadcastRequest
        {
            RecipientID = "recipient_id",
            RecipientType = SendBroadcastRequestRecipientType.List,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SendBroadcastRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedRecipientID = "recipient_id";
        ApiEnum<string, SendBroadcastRequestRecipientType> expectedRecipientType =
            SendBroadcastRequestRecipientType.List;

        Assert.Equal(expectedRecipientID, deserialized.RecipientID);
        Assert.Equal(expectedRecipientType, deserialized.RecipientType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SendBroadcastRequest
        {
            RecipientID = "recipient_id",
            RecipientType = SendBroadcastRequestRecipientType.List,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SendBroadcastRequest
        {
            RecipientID = "recipient_id",
            RecipientType = SendBroadcastRequestRecipientType.List,
        };

        SendBroadcastRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SendBroadcastRequestRecipientTypeTest : TestBase
{
    [Theory]
    [InlineData(SendBroadcastRequestRecipientType.List)]
    [InlineData(SendBroadcastRequestRecipientType.Audience)]
    public void Validation_Works(SendBroadcastRequestRecipientType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SendBroadcastRequestRecipientType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SendBroadcastRequestRecipientType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SendBroadcastRequestRecipientType.List)]
    [InlineData(SendBroadcastRequestRecipientType.Audience)]
    public void SerializationRoundtrip_Works(SendBroadcastRequestRecipientType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SendBroadcastRequestRecipientType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SendBroadcastRequestRecipientType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SendBroadcastRequestRecipientType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SendBroadcastRequestRecipientType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
