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
            TriggerEmpty = true,
        };

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
        bool expectedTriggerEmpty = true;

        Assert.Equal(expectedTemplateID, model.TemplateID);
        Assert.Equal(expectedAudienceID, model.AudienceID);
        Assert.NotNull(model.Categories);
        Assert.Equal(expectedCategories.Count, model.Categories.Count);
        for (int i = 0; i < expectedCategories.Count; i++)
        {
            Assert.Equal(expectedCategories[i], model.Categories[i]);
        }
        Assert.NotNull(model.Schedules);
        Assert.Equal(expectedSchedules.Count, model.Schedules.Count);
        for (int i = 0; i < expectedSchedules.Count; i++)
        {
            Assert.Equal(expectedSchedules[i], model.Schedules[i]);
        }
        Assert.Equal(expectedTriggerEmpty, model.TriggerEmpty);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopicDigestRequest
        {
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
            TriggerEmpty = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopicDigestRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

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
        bool expectedTriggerEmpty = true;

        Assert.Equal(expectedTemplateID, deserialized.TemplateID);
        Assert.Equal(expectedAudienceID, deserialized.AudienceID);
        Assert.NotNull(deserialized.Categories);
        Assert.Equal(expectedCategories.Count, deserialized.Categories.Count);
        for (int i = 0; i < expectedCategories.Count; i++)
        {
            Assert.Equal(expectedCategories[i], deserialized.Categories[i]);
        }
        Assert.NotNull(deserialized.Schedules);
        Assert.Equal(expectedSchedules.Count, deserialized.Schedules.Count);
        for (int i = 0; i < expectedSchedules.Count; i++)
        {
            Assert.Equal(expectedSchedules[i], deserialized.Schedules[i]);
        }
        Assert.Equal(expectedTriggerEmpty, deserialized.TriggerEmpty);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopicDigestRequest
        {
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
            TriggerEmpty = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TopicDigestRequest { TemplateID = "template_id" };

        Assert.Null(model.AudienceID);
        Assert.False(model.RawData.ContainsKey("audience_id"));
        Assert.Null(model.Categories);
        Assert.False(model.RawData.ContainsKey("categories"));
        Assert.Null(model.Schedules);
        Assert.False(model.RawData.ContainsKey("schedules"));
        Assert.Null(model.TriggerEmpty);
        Assert.False(model.RawData.ContainsKey("trigger_empty"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TopicDigestRequest { TemplateID = "template_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TopicDigestRequest
        {
            TemplateID = "template_id",

            // Null should be interpreted as omitted for these properties
            AudienceID = null,
            Categories = null,
            Schedules = null,
            TriggerEmpty = null,
        };

        Assert.Null(model.AudienceID);
        Assert.False(model.RawData.ContainsKey("audience_id"));
        Assert.Null(model.Categories);
        Assert.False(model.RawData.ContainsKey("categories"));
        Assert.Null(model.Schedules);
        Assert.False(model.RawData.ContainsKey("schedules"));
        Assert.Null(model.TriggerEmpty);
        Assert.False(model.RawData.ContainsKey("trigger_empty"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TopicDigestRequest
        {
            TemplateID = "template_id",

            // Null should be interpreted as omitted for these properties
            AudienceID = null,
            Categories = null,
            Schedules = null,
            TriggerEmpty = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopicDigestRequest
        {
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
            TriggerEmpty = true,
        };

        TopicDigestRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}
