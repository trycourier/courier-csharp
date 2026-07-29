using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Broadcasts;

namespace TryCourier.Tests.Models.Broadcasts;

public class ScheduleBroadcastRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ScheduleBroadcastRequest
        {
            RecipientID = "recipient_id",
            RecipientType = ScheduleBroadcastRequestRecipientType.List,
            ScheduledTo = "scheduled_to",
            Timezone = "timezone",
        };

        string expectedRecipientID = "recipient_id";
        ApiEnum<string, ScheduleBroadcastRequestRecipientType> expectedRecipientType =
            ScheduleBroadcastRequestRecipientType.List;
        string expectedScheduledTo = "scheduled_to";
        string expectedTimezone = "timezone";

        Assert.Equal(expectedRecipientID, model.RecipientID);
        Assert.Equal(expectedRecipientType, model.RecipientType);
        Assert.Equal(expectedScheduledTo, model.ScheduledTo);
        Assert.Equal(expectedTimezone, model.Timezone);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ScheduleBroadcastRequest
        {
            RecipientID = "recipient_id",
            RecipientType = ScheduleBroadcastRequestRecipientType.List,
            ScheduledTo = "scheduled_to",
            Timezone = "timezone",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ScheduleBroadcastRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ScheduleBroadcastRequest
        {
            RecipientID = "recipient_id",
            RecipientType = ScheduleBroadcastRequestRecipientType.List,
            ScheduledTo = "scheduled_to",
            Timezone = "timezone",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ScheduleBroadcastRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedRecipientID = "recipient_id";
        ApiEnum<string, ScheduleBroadcastRequestRecipientType> expectedRecipientType =
            ScheduleBroadcastRequestRecipientType.List;
        string expectedScheduledTo = "scheduled_to";
        string expectedTimezone = "timezone";

        Assert.Equal(expectedRecipientID, deserialized.RecipientID);
        Assert.Equal(expectedRecipientType, deserialized.RecipientType);
        Assert.Equal(expectedScheduledTo, deserialized.ScheduledTo);
        Assert.Equal(expectedTimezone, deserialized.Timezone);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ScheduleBroadcastRequest
        {
            RecipientID = "recipient_id",
            RecipientType = ScheduleBroadcastRequestRecipientType.List,
            ScheduledTo = "scheduled_to",
            Timezone = "timezone",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ScheduleBroadcastRequest
        {
            RecipientID = "recipient_id",
            RecipientType = ScheduleBroadcastRequestRecipientType.List,
            ScheduledTo = "scheduled_to",
        };

        Assert.Null(model.Timezone);
        Assert.False(model.RawData.ContainsKey("timezone"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ScheduleBroadcastRequest
        {
            RecipientID = "recipient_id",
            RecipientType = ScheduleBroadcastRequestRecipientType.List,
            ScheduledTo = "scheduled_to",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ScheduleBroadcastRequest
        {
            RecipientID = "recipient_id",
            RecipientType = ScheduleBroadcastRequestRecipientType.List,
            ScheduledTo = "scheduled_to",

            // Null should be interpreted as omitted for these properties
            Timezone = null,
        };

        Assert.Null(model.Timezone);
        Assert.False(model.RawData.ContainsKey("timezone"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ScheduleBroadcastRequest
        {
            RecipientID = "recipient_id",
            RecipientType = ScheduleBroadcastRequestRecipientType.List,
            ScheduledTo = "scheduled_to",

            // Null should be interpreted as omitted for these properties
            Timezone = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ScheduleBroadcastRequest
        {
            RecipientID = "recipient_id",
            RecipientType = ScheduleBroadcastRequestRecipientType.List,
            ScheduledTo = "scheduled_to",
            Timezone = "timezone",
        };

        ScheduleBroadcastRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ScheduleBroadcastRequestRecipientTypeTest : TestBase
{
    [Theory]
    [InlineData(ScheduleBroadcastRequestRecipientType.List)]
    [InlineData(ScheduleBroadcastRequestRecipientType.Audience)]
    public void Validation_Works(ScheduleBroadcastRequestRecipientType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ScheduleBroadcastRequestRecipientType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ScheduleBroadcastRequestRecipientType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ScheduleBroadcastRequestRecipientType.List)]
    [InlineData(ScheduleBroadcastRequestRecipientType.Audience)]
    public void SerializationRoundtrip_Works(ScheduleBroadcastRequestRecipientType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ScheduleBroadcastRequestRecipientType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ScheduleBroadcastRequestRecipientType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ScheduleBroadcastRequestRecipientType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ScheduleBroadcastRequestRecipientType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
