using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.WorkspacePreferences;
using Digests = TryCourier.Models.Digests;

namespace TryCourier.Tests.Models.WorkspacePreferences;

public class TopicDigestRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopicDigestRequest
        {
            Schedules =
            [
                new()
                {
                    Frequency = Digests::DigestFrequency.Instant,
                    DayOfMonth = 1,
                    DayOfWeek = Digests::DigestDayOfWeek.Sunday,
                    DaysOfWeek = [Digests::DigestDayOfWeek.Sunday],
                    Disabled = true,
                    IsDefault = true,
                    ScheduleID = "schedule_id",
                    Time = "time",
                    Timezone = "timezone",
                },
            ],
            TemplateID = "template_id",
            AudienceID = "audience_id",
            Categories =
            [
                new()
                {
                    CategoryKey = "category_key",
                    Limit = 1,
                    Retain = Retain.First,
                    SortKey = "sort_key",
                },
            ],
            TriggerEmpty = true,
        };

        List<TopicDigestScheduleRequest> expectedSchedules =
        [
            new()
            {
                Frequency = Digests::DigestFrequency.Instant,
                DayOfMonth = 1,
                DayOfWeek = Digests::DigestDayOfWeek.Sunday,
                DaysOfWeek = [Digests::DigestDayOfWeek.Sunday],
                Disabled = true,
                IsDefault = true,
                ScheduleID = "schedule_id",
                Time = "time",
                Timezone = "timezone",
            },
        ];
        string expectedTemplateID = "template_id";
        string expectedAudienceID = "audience_id";
        List<TopicDigestCategory> expectedCategories =
        [
            new()
            {
                CategoryKey = "category_key",
                Limit = 1,
                Retain = Retain.First,
                SortKey = "sort_key",
            },
        ];
        bool expectedTriggerEmpty = true;

        Assert.Equal(expectedSchedules.Count, model.Schedules.Count);
        for (int i = 0; i < expectedSchedules.Count; i++)
        {
            Assert.Equal(expectedSchedules[i], model.Schedules[i]);
        }
        Assert.Equal(expectedTemplateID, model.TemplateID);
        Assert.Equal(expectedAudienceID, model.AudienceID);
        Assert.NotNull(model.Categories);
        Assert.Equal(expectedCategories.Count, model.Categories.Count);
        for (int i = 0; i < expectedCategories.Count; i++)
        {
            Assert.Equal(expectedCategories[i], model.Categories[i]);
        }
        Assert.Equal(expectedTriggerEmpty, model.TriggerEmpty);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopicDigestRequest
        {
            Schedules =
            [
                new()
                {
                    Frequency = Digests::DigestFrequency.Instant,
                    DayOfMonth = 1,
                    DayOfWeek = Digests::DigestDayOfWeek.Sunday,
                    DaysOfWeek = [Digests::DigestDayOfWeek.Sunday],
                    Disabled = true,
                    IsDefault = true,
                    ScheduleID = "schedule_id",
                    Time = "time",
                    Timezone = "timezone",
                },
            ],
            TemplateID = "template_id",
            AudienceID = "audience_id",
            Categories =
            [
                new()
                {
                    CategoryKey = "category_key",
                    Limit = 1,
                    Retain = Retain.First,
                    SortKey = "sort_key",
                },
            ],
            TriggerEmpty = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopicDigestRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopicDigestRequest
        {
            Schedules =
            [
                new()
                {
                    Frequency = Digests::DigestFrequency.Instant,
                    DayOfMonth = 1,
                    DayOfWeek = Digests::DigestDayOfWeek.Sunday,
                    DaysOfWeek = [Digests::DigestDayOfWeek.Sunday],
                    Disabled = true,
                    IsDefault = true,
                    ScheduleID = "schedule_id",
                    Time = "time",
                    Timezone = "timezone",
                },
            ],
            TemplateID = "template_id",
            AudienceID = "audience_id",
            Categories =
            [
                new()
                {
                    CategoryKey = "category_key",
                    Limit = 1,
                    Retain = Retain.First,
                    SortKey = "sort_key",
                },
            ],
            TriggerEmpty = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopicDigestRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<TopicDigestScheduleRequest> expectedSchedules =
        [
            new()
            {
                Frequency = Digests::DigestFrequency.Instant,
                DayOfMonth = 1,
                DayOfWeek = Digests::DigestDayOfWeek.Sunday,
                DaysOfWeek = [Digests::DigestDayOfWeek.Sunday],
                Disabled = true,
                IsDefault = true,
                ScheduleID = "schedule_id",
                Time = "time",
                Timezone = "timezone",
            },
        ];
        string expectedTemplateID = "template_id";
        string expectedAudienceID = "audience_id";
        List<TopicDigestCategory> expectedCategories =
        [
            new()
            {
                CategoryKey = "category_key",
                Limit = 1,
                Retain = Retain.First,
                SortKey = "sort_key",
            },
        ];
        bool expectedTriggerEmpty = true;

        Assert.Equal(expectedSchedules.Count, deserialized.Schedules.Count);
        for (int i = 0; i < expectedSchedules.Count; i++)
        {
            Assert.Equal(expectedSchedules[i], deserialized.Schedules[i]);
        }
        Assert.Equal(expectedTemplateID, deserialized.TemplateID);
        Assert.Equal(expectedAudienceID, deserialized.AudienceID);
        Assert.NotNull(deserialized.Categories);
        Assert.Equal(expectedCategories.Count, deserialized.Categories.Count);
        for (int i = 0; i < expectedCategories.Count; i++)
        {
            Assert.Equal(expectedCategories[i], deserialized.Categories[i]);
        }
        Assert.Equal(expectedTriggerEmpty, deserialized.TriggerEmpty);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopicDigestRequest
        {
            Schedules =
            [
                new()
                {
                    Frequency = Digests::DigestFrequency.Instant,
                    DayOfMonth = 1,
                    DayOfWeek = Digests::DigestDayOfWeek.Sunday,
                    DaysOfWeek = [Digests::DigestDayOfWeek.Sunday],
                    Disabled = true,
                    IsDefault = true,
                    ScheduleID = "schedule_id",
                    Time = "time",
                    Timezone = "timezone",
                },
            ],
            TemplateID = "template_id",
            AudienceID = "audience_id",
            Categories =
            [
                new()
                {
                    CategoryKey = "category_key",
                    Limit = 1,
                    Retain = Retain.First,
                    SortKey = "sort_key",
                },
            ],
            TriggerEmpty = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TopicDigestRequest
        {
            Schedules =
            [
                new()
                {
                    Frequency = Digests::DigestFrequency.Instant,
                    DayOfMonth = 1,
                    DayOfWeek = Digests::DigestDayOfWeek.Sunday,
                    DaysOfWeek = [Digests::DigestDayOfWeek.Sunday],
                    Disabled = true,
                    IsDefault = true,
                    ScheduleID = "schedule_id",
                    Time = "time",
                    Timezone = "timezone",
                },
            ],
            TemplateID = "template_id",
        };

        Assert.Null(model.AudienceID);
        Assert.False(model.RawData.ContainsKey("audience_id"));
        Assert.Null(model.Categories);
        Assert.False(model.RawData.ContainsKey("categories"));
        Assert.Null(model.TriggerEmpty);
        Assert.False(model.RawData.ContainsKey("trigger_empty"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TopicDigestRequest
        {
            Schedules =
            [
                new()
                {
                    Frequency = Digests::DigestFrequency.Instant,
                    DayOfMonth = 1,
                    DayOfWeek = Digests::DigestDayOfWeek.Sunday,
                    DaysOfWeek = [Digests::DigestDayOfWeek.Sunday],
                    Disabled = true,
                    IsDefault = true,
                    ScheduleID = "schedule_id",
                    Time = "time",
                    Timezone = "timezone",
                },
            ],
            TemplateID = "template_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TopicDigestRequest
        {
            Schedules =
            [
                new()
                {
                    Frequency = Digests::DigestFrequency.Instant,
                    DayOfMonth = 1,
                    DayOfWeek = Digests::DigestDayOfWeek.Sunday,
                    DaysOfWeek = [Digests::DigestDayOfWeek.Sunday],
                    Disabled = true,
                    IsDefault = true,
                    ScheduleID = "schedule_id",
                    Time = "time",
                    Timezone = "timezone",
                },
            ],
            TemplateID = "template_id",

            // Null should be interpreted as omitted for these properties
            AudienceID = null,
            Categories = null,
            TriggerEmpty = null,
        };

        Assert.Null(model.AudienceID);
        Assert.False(model.RawData.ContainsKey("audience_id"));
        Assert.Null(model.Categories);
        Assert.False(model.RawData.ContainsKey("categories"));
        Assert.Null(model.TriggerEmpty);
        Assert.False(model.RawData.ContainsKey("trigger_empty"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TopicDigestRequest
        {
            Schedules =
            [
                new()
                {
                    Frequency = Digests::DigestFrequency.Instant,
                    DayOfMonth = 1,
                    DayOfWeek = Digests::DigestDayOfWeek.Sunday,
                    DaysOfWeek = [Digests::DigestDayOfWeek.Sunday],
                    Disabled = true,
                    IsDefault = true,
                    ScheduleID = "schedule_id",
                    Time = "time",
                    Timezone = "timezone",
                },
            ],
            TemplateID = "template_id",

            // Null should be interpreted as omitted for these properties
            AudienceID = null,
            Categories = null,
            TriggerEmpty = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopicDigestRequest
        {
            Schedules =
            [
                new()
                {
                    Frequency = Digests::DigestFrequency.Instant,
                    DayOfMonth = 1,
                    DayOfWeek = Digests::DigestDayOfWeek.Sunday,
                    DaysOfWeek = [Digests::DigestDayOfWeek.Sunday],
                    Disabled = true,
                    IsDefault = true,
                    ScheduleID = "schedule_id",
                    Time = "time",
                    Timezone = "timezone",
                },
            ],
            TemplateID = "template_id",
            AudienceID = "audience_id",
            Categories =
            [
                new()
                {
                    CategoryKey = "category_key",
                    Limit = 1,
                    Retain = Retain.First,
                    SortKey = "sort_key",
                },
            ],
            TriggerEmpty = true,
        };

        TopicDigestRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}
