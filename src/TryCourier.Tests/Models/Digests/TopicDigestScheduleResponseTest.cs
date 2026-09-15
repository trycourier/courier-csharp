using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Digests;

namespace TryCourier.Tests.Models.Digests;

public class TopicDigestScheduleResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopicDigestScheduleResponse
        {
            ScheduleID = "schedule_id",
            Created = "created",
            DayOfMonth = 0,
            DayOfWeek = DigestDayOfWeek.Sunday,
            DaysOfWeek = [DigestDayOfWeek.Sunday],
            Disabled = true,
            Frequency = DigestFrequency.Instant,
            IsDefault = true,
            Time = "time",
            Timezone = "timezone",
            Updated = "updated",
        };

        string expectedScheduleID = "schedule_id";
        string expectedCreated = "created";
        long expectedDayOfMonth = 0;
        ApiEnum<string, DigestDayOfWeek> expectedDayOfWeek = DigestDayOfWeek.Sunday;
        List<ApiEnum<string, DigestDayOfWeek>> expectedDaysOfWeek = [DigestDayOfWeek.Sunday];
        bool expectedDisabled = true;
        ApiEnum<string, DigestFrequency> expectedFrequency = DigestFrequency.Instant;
        bool expectedIsDefault = true;
        string expectedTime = "time";
        string expectedTimezone = "timezone";
        string expectedUpdated = "updated";

        Assert.Equal(expectedScheduleID, model.ScheduleID);
        Assert.Equal(expectedCreated, model.Created);
        Assert.Equal(expectedDayOfMonth, model.DayOfMonth);
        Assert.Equal(expectedDayOfWeek, model.DayOfWeek);
        Assert.NotNull(model.DaysOfWeek);
        Assert.Equal(expectedDaysOfWeek.Count, model.DaysOfWeek.Count);
        for (int i = 0; i < expectedDaysOfWeek.Count; i++)
        {
            Assert.Equal(expectedDaysOfWeek[i], model.DaysOfWeek[i]);
        }
        Assert.Equal(expectedDisabled, model.Disabled);
        Assert.Equal(expectedFrequency, model.Frequency);
        Assert.Equal(expectedIsDefault, model.IsDefault);
        Assert.Equal(expectedTime, model.Time);
        Assert.Equal(expectedTimezone, model.Timezone);
        Assert.Equal(expectedUpdated, model.Updated);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopicDigestScheduleResponse
        {
            ScheduleID = "schedule_id",
            Created = "created",
            DayOfMonth = 0,
            DayOfWeek = DigestDayOfWeek.Sunday,
            DaysOfWeek = [DigestDayOfWeek.Sunday],
            Disabled = true,
            Frequency = DigestFrequency.Instant,
            IsDefault = true,
            Time = "time",
            Timezone = "timezone",
            Updated = "updated",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopicDigestScheduleResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopicDigestScheduleResponse
        {
            ScheduleID = "schedule_id",
            Created = "created",
            DayOfMonth = 0,
            DayOfWeek = DigestDayOfWeek.Sunday,
            DaysOfWeek = [DigestDayOfWeek.Sunday],
            Disabled = true,
            Frequency = DigestFrequency.Instant,
            IsDefault = true,
            Time = "time",
            Timezone = "timezone",
            Updated = "updated",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopicDigestScheduleResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedScheduleID = "schedule_id";
        string expectedCreated = "created";
        long expectedDayOfMonth = 0;
        ApiEnum<string, DigestDayOfWeek> expectedDayOfWeek = DigestDayOfWeek.Sunday;
        List<ApiEnum<string, DigestDayOfWeek>> expectedDaysOfWeek = [DigestDayOfWeek.Sunday];
        bool expectedDisabled = true;
        ApiEnum<string, DigestFrequency> expectedFrequency = DigestFrequency.Instant;
        bool expectedIsDefault = true;
        string expectedTime = "time";
        string expectedTimezone = "timezone";
        string expectedUpdated = "updated";

        Assert.Equal(expectedScheduleID, deserialized.ScheduleID);
        Assert.Equal(expectedCreated, deserialized.Created);
        Assert.Equal(expectedDayOfMonth, deserialized.DayOfMonth);
        Assert.Equal(expectedDayOfWeek, deserialized.DayOfWeek);
        Assert.NotNull(deserialized.DaysOfWeek);
        Assert.Equal(expectedDaysOfWeek.Count, deserialized.DaysOfWeek.Count);
        for (int i = 0; i < expectedDaysOfWeek.Count; i++)
        {
            Assert.Equal(expectedDaysOfWeek[i], deserialized.DaysOfWeek[i]);
        }
        Assert.Equal(expectedDisabled, deserialized.Disabled);
        Assert.Equal(expectedFrequency, deserialized.Frequency);
        Assert.Equal(expectedIsDefault, deserialized.IsDefault);
        Assert.Equal(expectedTime, deserialized.Time);
        Assert.Equal(expectedTimezone, deserialized.Timezone);
        Assert.Equal(expectedUpdated, deserialized.Updated);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopicDigestScheduleResponse
        {
            ScheduleID = "schedule_id",
            Created = "created",
            DayOfMonth = 0,
            DayOfWeek = DigestDayOfWeek.Sunday,
            DaysOfWeek = [DigestDayOfWeek.Sunday],
            Disabled = true,
            Frequency = DigestFrequency.Instant,
            IsDefault = true,
            Time = "time",
            Timezone = "timezone",
            Updated = "updated",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TopicDigestScheduleResponse { ScheduleID = "schedule_id" };

        Assert.Null(model.Created);
        Assert.False(model.RawData.ContainsKey("created"));
        Assert.Null(model.DayOfMonth);
        Assert.False(model.RawData.ContainsKey("day_of_month"));
        Assert.Null(model.DayOfWeek);
        Assert.False(model.RawData.ContainsKey("day_of_week"));
        Assert.Null(model.DaysOfWeek);
        Assert.False(model.RawData.ContainsKey("days_of_week"));
        Assert.Null(model.Disabled);
        Assert.False(model.RawData.ContainsKey("disabled"));
        Assert.Null(model.Frequency);
        Assert.False(model.RawData.ContainsKey("frequency"));
        Assert.Null(model.IsDefault);
        Assert.False(model.RawData.ContainsKey("is_default"));
        Assert.Null(model.Time);
        Assert.False(model.RawData.ContainsKey("time"));
        Assert.Null(model.Timezone);
        Assert.False(model.RawData.ContainsKey("timezone"));
        Assert.Null(model.Updated);
        Assert.False(model.RawData.ContainsKey("updated"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TopicDigestScheduleResponse { ScheduleID = "schedule_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TopicDigestScheduleResponse
        {
            ScheduleID = "schedule_id",

            // Null should be interpreted as omitted for these properties
            Created = null,
            DayOfMonth = null,
            DayOfWeek = null,
            DaysOfWeek = null,
            Disabled = null,
            Frequency = null,
            IsDefault = null,
            Time = null,
            Timezone = null,
            Updated = null,
        };

        Assert.Null(model.Created);
        Assert.False(model.RawData.ContainsKey("created"));
        Assert.Null(model.DayOfMonth);
        Assert.False(model.RawData.ContainsKey("day_of_month"));
        Assert.Null(model.DayOfWeek);
        Assert.False(model.RawData.ContainsKey("day_of_week"));
        Assert.Null(model.DaysOfWeek);
        Assert.False(model.RawData.ContainsKey("days_of_week"));
        Assert.Null(model.Disabled);
        Assert.False(model.RawData.ContainsKey("disabled"));
        Assert.Null(model.Frequency);
        Assert.False(model.RawData.ContainsKey("frequency"));
        Assert.Null(model.IsDefault);
        Assert.False(model.RawData.ContainsKey("is_default"));
        Assert.Null(model.Time);
        Assert.False(model.RawData.ContainsKey("time"));
        Assert.Null(model.Timezone);
        Assert.False(model.RawData.ContainsKey("timezone"));
        Assert.Null(model.Updated);
        Assert.False(model.RawData.ContainsKey("updated"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TopicDigestScheduleResponse
        {
            ScheduleID = "schedule_id",

            // Null should be interpreted as omitted for these properties
            Created = null,
            DayOfMonth = null,
            DayOfWeek = null,
            DaysOfWeek = null,
            Disabled = null,
            Frequency = null,
            IsDefault = null,
            Time = null,
            Timezone = null,
            Updated = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopicDigestScheduleResponse
        {
            ScheduleID = "schedule_id",
            Created = "created",
            DayOfMonth = 0,
            DayOfWeek = DigestDayOfWeek.Sunday,
            DaysOfWeek = [DigestDayOfWeek.Sunday],
            Disabled = true,
            Frequency = DigestFrequency.Instant,
            IsDefault = true,
            Time = "time",
            Timezone = "timezone",
            Updated = "updated",
        };

        TopicDigestScheduleResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
