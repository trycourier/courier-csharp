using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Broadcasts;

namespace TryCourier.Tests.Models.Broadcasts;

public class BroadcastScheduleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BroadcastSchedule
        {
            RecipientID = "recipient_id",
            RecipientType = BroadcastScheduleRecipientType.List,
            ScheduledTo = "scheduled_to",
            Timezone = "timezone",
        };

        string expectedRecipientID = "recipient_id";
        ApiEnum<string, BroadcastScheduleRecipientType> expectedRecipientType =
            BroadcastScheduleRecipientType.List;
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
        var model = new BroadcastSchedule
        {
            RecipientID = "recipient_id",
            RecipientType = BroadcastScheduleRecipientType.List,
            ScheduledTo = "scheduled_to",
            Timezone = "timezone",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BroadcastSchedule>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BroadcastSchedule
        {
            RecipientID = "recipient_id",
            RecipientType = BroadcastScheduleRecipientType.List,
            ScheduledTo = "scheduled_to",
            Timezone = "timezone",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BroadcastSchedule>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedRecipientID = "recipient_id";
        ApiEnum<string, BroadcastScheduleRecipientType> expectedRecipientType =
            BroadcastScheduleRecipientType.List;
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
        var model = new BroadcastSchedule
        {
            RecipientID = "recipient_id",
            RecipientType = BroadcastScheduleRecipientType.List,
            ScheduledTo = "scheduled_to",
            Timezone = "timezone",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BroadcastSchedule
        {
            RecipientID = "recipient_id",
            RecipientType = BroadcastScheduleRecipientType.List,
        };

        Assert.Null(model.ScheduledTo);
        Assert.False(model.RawData.ContainsKey("scheduled_to"));
        Assert.Null(model.Timezone);
        Assert.False(model.RawData.ContainsKey("timezone"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BroadcastSchedule
        {
            RecipientID = "recipient_id",
            RecipientType = BroadcastScheduleRecipientType.List,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BroadcastSchedule
        {
            RecipientID = "recipient_id",
            RecipientType = BroadcastScheduleRecipientType.List,

            ScheduledTo = null,
            Timezone = null,
        };

        Assert.Null(model.ScheduledTo);
        Assert.True(model.RawData.ContainsKey("scheduled_to"));
        Assert.Null(model.Timezone);
        Assert.True(model.RawData.ContainsKey("timezone"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BroadcastSchedule
        {
            RecipientID = "recipient_id",
            RecipientType = BroadcastScheduleRecipientType.List,

            ScheduledTo = null,
            Timezone = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BroadcastSchedule
        {
            RecipientID = "recipient_id",
            RecipientType = BroadcastScheduleRecipientType.List,
            ScheduledTo = "scheduled_to",
            Timezone = "timezone",
        };

        BroadcastSchedule copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BroadcastScheduleRecipientTypeTest : TestBase
{
    [Theory]
    [InlineData(BroadcastScheduleRecipientType.List)]
    [InlineData(BroadcastScheduleRecipientType.Audience)]
    public void Validation_Works(BroadcastScheduleRecipientType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BroadcastScheduleRecipientType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BroadcastScheduleRecipientType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BroadcastScheduleRecipientType.List)]
    [InlineData(BroadcastScheduleRecipientType.Audience)]
    public void SerializationRoundtrip_Works(BroadcastScheduleRecipientType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BroadcastScheduleRecipientType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BroadcastScheduleRecipientType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BroadcastScheduleRecipientType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BroadcastScheduleRecipientType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
