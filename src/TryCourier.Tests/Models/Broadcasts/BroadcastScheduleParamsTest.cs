using System;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Broadcasts;

namespace TryCourier.Tests.Models.Broadcasts;

public class BroadcastScheduleParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BroadcastScheduleParams
        {
            BroadcastID = "broadcastId",
            RecipientID = "aud_01kx4h2jdafq8bk9amzvy6hbv0",
            RecipientType = RecipientType.Audience,
            ScheduledTo = "2026-08-01T15:00:00",
            Timezone = "America/New_York",
        };

        string expectedBroadcastID = "broadcastId";
        string expectedRecipientID = "aud_01kx4h2jdafq8bk9amzvy6hbv0";
        ApiEnum<string, RecipientType> expectedRecipientType = RecipientType.Audience;
        string expectedScheduledTo = "2026-08-01T15:00:00";
        string expectedTimezone = "America/New_York";

        Assert.Equal(expectedBroadcastID, parameters.BroadcastID);
        Assert.Equal(expectedRecipientID, parameters.RecipientID);
        Assert.Equal(expectedRecipientType, parameters.RecipientType);
        Assert.Equal(expectedScheduledTo, parameters.ScheduledTo);
        Assert.Equal(expectedTimezone, parameters.Timezone);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BroadcastScheduleParams
        {
            BroadcastID = "broadcastId",
            RecipientID = "aud_01kx4h2jdafq8bk9amzvy6hbv0",
            RecipientType = RecipientType.Audience,
            ScheduledTo = "2026-08-01T15:00:00",
        };

        Assert.Null(parameters.Timezone);
        Assert.False(parameters.RawBodyData.ContainsKey("timezone"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BroadcastScheduleParams
        {
            BroadcastID = "broadcastId",
            RecipientID = "aud_01kx4h2jdafq8bk9amzvy6hbv0",
            RecipientType = RecipientType.Audience,
            ScheduledTo = "2026-08-01T15:00:00",

            // Null should be interpreted as omitted for these properties
            Timezone = null,
        };

        Assert.Null(parameters.Timezone);
        Assert.False(parameters.RawBodyData.ContainsKey("timezone"));
    }

    [Fact]
    public void Url_Works()
    {
        BroadcastScheduleParams parameters = new()
        {
            BroadcastID = "broadcastId",
            RecipientID = "aud_01kx4h2jdafq8bk9amzvy6hbv0",
            RecipientType = RecipientType.Audience,
            ScheduledTo = "2026-08-01T15:00:00",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.courier.com/broadcasts/broadcastId/schedule"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BroadcastScheduleParams
        {
            BroadcastID = "broadcastId",
            RecipientID = "aud_01kx4h2jdafq8bk9amzvy6hbv0",
            RecipientType = RecipientType.Audience,
            ScheduledTo = "2026-08-01T15:00:00",
            Timezone = "America/New_York",
        };

        BroadcastScheduleParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class RecipientTypeTest : TestBase
{
    [Theory]
    [InlineData(RecipientType.List)]
    [InlineData(RecipientType.Audience)]
    public void Validation_Works(RecipientType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RecipientType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RecipientType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RecipientType.List)]
    [InlineData(RecipientType.Audience)]
    public void SerializationRoundtrip_Works(RecipientType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RecipientType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RecipientType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RecipientType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RecipientType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
