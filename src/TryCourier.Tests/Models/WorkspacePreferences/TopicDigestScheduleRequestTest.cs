using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Digests;
using TryCourier.Models.WorkspacePreferences;

namespace TryCourier.Tests.Models.WorkspacePreferences;

public class TopicDigestScheduleRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopicDigestScheduleRequest
        {
            Frequency = DigestFrequency.Instant,
            DayOfMonth = 1,
            DayOfWeek = DigestDayOfWeek.Sunday,
            DaysOfWeek = [DigestDayOfWeek.Sunday],
            Disabled = true,
            IsDefault = true,
            ScheduleID = "schedule_id",
            Time = "time",
            Timezone = "timezone",
        };

        ApiEnum<string, DigestFrequency> expectedFrequency = DigestFrequency.Instant;
        long expectedDayOfMonth = 1;
        ApiEnum<string, DigestDayOfWeek> expectedDayOfWeek = DigestDayOfWeek.Sunday;
        List<ApiEnum<string, DigestDayOfWeek>> expectedDaysOfWeek = [DigestDayOfWeek.Sunday];
        bool expectedDisabled = true;
        bool expectedIsDefault = true;
        string expectedScheduleID = "schedule_id";
        string expectedTime = "time";
        string expectedTimezone = "timezone";

        Assert.Equal(expectedFrequency, model.Frequency);
        Assert.Equal(expectedDayOfMonth, model.DayOfMonth);
        Assert.Equal(expectedDayOfWeek, model.DayOfWeek);
        Assert.NotNull(model.DaysOfWeek);
        Assert.Equal(expectedDaysOfWeek.Count, model.DaysOfWeek.Count);
        for (int i = 0; i < expectedDaysOfWeek.Count; i++)
        {
            Assert.Equal(expectedDaysOfWeek[i], model.DaysOfWeek[i]);
        }
        Assert.Equal(expectedDisabled, model.Disabled);
        Assert.Equal(expectedIsDefault, model.IsDefault);
        Assert.Equal(expectedScheduleID, model.ScheduleID);
        Assert.Equal(expectedTime, model.Time);
        Assert.Equal(expectedTimezone, model.Timezone);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopicDigestScheduleRequest
        {
            Frequency = DigestFrequency.Instant,
            DayOfMonth = 1,
            DayOfWeek = DigestDayOfWeek.Sunday,
            DaysOfWeek = [DigestDayOfWeek.Sunday],
            Disabled = true,
            IsDefault = true,
            ScheduleID = "schedule_id",
            Time = "time",
            Timezone = "timezone",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopicDigestScheduleRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopicDigestScheduleRequest
        {
            Frequency = DigestFrequency.Instant,
            DayOfMonth = 1,
            DayOfWeek = DigestDayOfWeek.Sunday,
            DaysOfWeek = [DigestDayOfWeek.Sunday],
            Disabled = true,
            IsDefault = true,
            ScheduleID = "schedule_id",
            Time = "time",
            Timezone = "timezone",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopicDigestScheduleRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, DigestFrequency> expectedFrequency = DigestFrequency.Instant;
        long expectedDayOfMonth = 1;
        ApiEnum<string, DigestDayOfWeek> expectedDayOfWeek = DigestDayOfWeek.Sunday;
        List<ApiEnum<string, DigestDayOfWeek>> expectedDaysOfWeek = [DigestDayOfWeek.Sunday];
        bool expectedDisabled = true;
        bool expectedIsDefault = true;
        string expectedScheduleID = "schedule_id";
        string expectedTime = "time";
        string expectedTimezone = "timezone";

        Assert.Equal(expectedFrequency, deserialized.Frequency);
        Assert.Equal(expectedDayOfMonth, deserialized.DayOfMonth);
        Assert.Equal(expectedDayOfWeek, deserialized.DayOfWeek);
        Assert.NotNull(deserialized.DaysOfWeek);
        Assert.Equal(expectedDaysOfWeek.Count, deserialized.DaysOfWeek.Count);
        for (int i = 0; i < expectedDaysOfWeek.Count; i++)
        {
            Assert.Equal(expectedDaysOfWeek[i], deserialized.DaysOfWeek[i]);
        }
        Assert.Equal(expectedDisabled, deserialized.Disabled);
        Assert.Equal(expectedIsDefault, deserialized.IsDefault);
        Assert.Equal(expectedScheduleID, deserialized.ScheduleID);
        Assert.Equal(expectedTime, deserialized.Time);
        Assert.Equal(expectedTimezone, deserialized.Timezone);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopicDigestScheduleRequest
        {
            Frequency = DigestFrequency.Instant,
            DayOfMonth = 1,
            DayOfWeek = DigestDayOfWeek.Sunday,
            DaysOfWeek = [DigestDayOfWeek.Sunday],
            Disabled = true,
            IsDefault = true,
            ScheduleID = "schedule_id",
            Time = "time",
            Timezone = "timezone",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TopicDigestScheduleRequest { Frequency = DigestFrequency.Instant };

        Assert.Null(model.DayOfMonth);
        Assert.False(model.RawData.ContainsKey("day_of_month"));
        Assert.Null(model.DayOfWeek);
        Assert.False(model.RawData.ContainsKey("day_of_week"));
        Assert.Null(model.DaysOfWeek);
        Assert.False(model.RawData.ContainsKey("days_of_week"));
        Assert.Null(model.Disabled);
        Assert.False(model.RawData.ContainsKey("disabled"));
        Assert.Null(model.IsDefault);
        Assert.False(model.RawData.ContainsKey("is_default"));
        Assert.Null(model.ScheduleID);
        Assert.False(model.RawData.ContainsKey("schedule_id"));
        Assert.Null(model.Time);
        Assert.False(model.RawData.ContainsKey("time"));
        Assert.Null(model.Timezone);
        Assert.False(model.RawData.ContainsKey("timezone"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TopicDigestScheduleRequest { Frequency = DigestFrequency.Instant };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TopicDigestScheduleRequest
        {
            Frequency = DigestFrequency.Instant,

            // Null should be interpreted as omitted for these properties
            DayOfMonth = null,
            DayOfWeek = null,
            DaysOfWeek = null,
            Disabled = null,
            IsDefault = null,
            ScheduleID = null,
            Time = null,
            Timezone = null,
        };

        Assert.Null(model.DayOfMonth);
        Assert.False(model.RawData.ContainsKey("day_of_month"));
        Assert.Null(model.DayOfWeek);
        Assert.False(model.RawData.ContainsKey("day_of_week"));
        Assert.Null(model.DaysOfWeek);
        Assert.False(model.RawData.ContainsKey("days_of_week"));
        Assert.Null(model.Disabled);
        Assert.False(model.RawData.ContainsKey("disabled"));
        Assert.Null(model.IsDefault);
        Assert.False(model.RawData.ContainsKey("is_default"));
        Assert.Null(model.ScheduleID);
        Assert.False(model.RawData.ContainsKey("schedule_id"));
        Assert.Null(model.Time);
        Assert.False(model.RawData.ContainsKey("time"));
        Assert.Null(model.Timezone);
        Assert.False(model.RawData.ContainsKey("timezone"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TopicDigestScheduleRequest
        {
            Frequency = DigestFrequency.Instant,

            // Null should be interpreted as omitted for these properties
            DayOfMonth = null,
            DayOfWeek = null,
            DaysOfWeek = null,
            Disabled = null,
            IsDefault = null,
            ScheduleID = null,
            Time = null,
            Timezone = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopicDigestScheduleRequest
        {
            Frequency = DigestFrequency.Instant,
            DayOfMonth = 1,
            DayOfWeek = DigestDayOfWeek.Sunday,
            DaysOfWeek = [DigestDayOfWeek.Sunday],
            Disabled = true,
            IsDefault = true,
            ScheduleID = "schedule_id",
            Time = "time",
            Timezone = "timezone",
        };

        TopicDigestScheduleRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}
