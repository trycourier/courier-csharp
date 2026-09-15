using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.WorkspacePreferences;
using Digests = TryCourier.Models.Digests;

namespace TryCourier.Tests.Models.WorkspacePreferences;

public class TopicDigestResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopicDigestResponse
        {
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
                    ScheduleID = "schedule_id",
                    Created = "created",
                    DayOfMonth = 0,
                    DayOfWeek = Digests::DigestDayOfWeek.Sunday,
                    DaysOfWeek = [Digests::DigestDayOfWeek.Sunday],
                    Disabled = true,
                    Frequency = Digests::DigestFrequency.Instant,
                    IsDefault = true,
                    Time = "time",
                    Timezone = "timezone",
                    Updated = "updated",
                },
            ],
            TemplateID = "template_id",
            AudienceID = "audience_id",
            Created = "created",
            TriggerEmpty = true,
            Updated = "updated",
        };

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
        List<Digests::TopicDigestScheduleResponse> expectedSchedules =
        [
            new()
            {
                ScheduleID = "schedule_id",
                Created = "created",
                DayOfMonth = 0,
                DayOfWeek = Digests::DigestDayOfWeek.Sunday,
                DaysOfWeek = [Digests::DigestDayOfWeek.Sunday],
                Disabled = true,
                Frequency = Digests::DigestFrequency.Instant,
                IsDefault = true,
                Time = "time",
                Timezone = "timezone",
                Updated = "updated",
            },
        ];
        string expectedTemplateID = "template_id";
        string expectedAudienceID = "audience_id";
        string expectedCreated = "created";
        bool expectedTriggerEmpty = true;
        string expectedUpdated = "updated";

        Assert.Equal(expectedCategories.Count, model.Categories.Count);
        for (int i = 0; i < expectedCategories.Count; i++)
        {
            Assert.Equal(expectedCategories[i], model.Categories[i]);
        }
        Assert.Equal(expectedSchedules.Count, model.Schedules.Count);
        for (int i = 0; i < expectedSchedules.Count; i++)
        {
            Assert.Equal(expectedSchedules[i], model.Schedules[i]);
        }
        Assert.Equal(expectedTemplateID, model.TemplateID);
        Assert.Equal(expectedAudienceID, model.AudienceID);
        Assert.Equal(expectedCreated, model.Created);
        Assert.Equal(expectedTriggerEmpty, model.TriggerEmpty);
        Assert.Equal(expectedUpdated, model.Updated);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopicDigestResponse
        {
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
                    ScheduleID = "schedule_id",
                    Created = "created",
                    DayOfMonth = 0,
                    DayOfWeek = Digests::DigestDayOfWeek.Sunday,
                    DaysOfWeek = [Digests::DigestDayOfWeek.Sunday],
                    Disabled = true,
                    Frequency = Digests::DigestFrequency.Instant,
                    IsDefault = true,
                    Time = "time",
                    Timezone = "timezone",
                    Updated = "updated",
                },
            ],
            TemplateID = "template_id",
            AudienceID = "audience_id",
            Created = "created",
            TriggerEmpty = true,
            Updated = "updated",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopicDigestResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopicDigestResponse
        {
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
                    ScheduleID = "schedule_id",
                    Created = "created",
                    DayOfMonth = 0,
                    DayOfWeek = Digests::DigestDayOfWeek.Sunday,
                    DaysOfWeek = [Digests::DigestDayOfWeek.Sunday],
                    Disabled = true,
                    Frequency = Digests::DigestFrequency.Instant,
                    IsDefault = true,
                    Time = "time",
                    Timezone = "timezone",
                    Updated = "updated",
                },
            ],
            TemplateID = "template_id",
            AudienceID = "audience_id",
            Created = "created",
            TriggerEmpty = true,
            Updated = "updated",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopicDigestResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

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
        List<Digests::TopicDigestScheduleResponse> expectedSchedules =
        [
            new()
            {
                ScheduleID = "schedule_id",
                Created = "created",
                DayOfMonth = 0,
                DayOfWeek = Digests::DigestDayOfWeek.Sunday,
                DaysOfWeek = [Digests::DigestDayOfWeek.Sunday],
                Disabled = true,
                Frequency = Digests::DigestFrequency.Instant,
                IsDefault = true,
                Time = "time",
                Timezone = "timezone",
                Updated = "updated",
            },
        ];
        string expectedTemplateID = "template_id";
        string expectedAudienceID = "audience_id";
        string expectedCreated = "created";
        bool expectedTriggerEmpty = true;
        string expectedUpdated = "updated";

        Assert.Equal(expectedCategories.Count, deserialized.Categories.Count);
        for (int i = 0; i < expectedCategories.Count; i++)
        {
            Assert.Equal(expectedCategories[i], deserialized.Categories[i]);
        }
        Assert.Equal(expectedSchedules.Count, deserialized.Schedules.Count);
        for (int i = 0; i < expectedSchedules.Count; i++)
        {
            Assert.Equal(expectedSchedules[i], deserialized.Schedules[i]);
        }
        Assert.Equal(expectedTemplateID, deserialized.TemplateID);
        Assert.Equal(expectedAudienceID, deserialized.AudienceID);
        Assert.Equal(expectedCreated, deserialized.Created);
        Assert.Equal(expectedTriggerEmpty, deserialized.TriggerEmpty);
        Assert.Equal(expectedUpdated, deserialized.Updated);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopicDigestResponse
        {
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
                    ScheduleID = "schedule_id",
                    Created = "created",
                    DayOfMonth = 0,
                    DayOfWeek = Digests::DigestDayOfWeek.Sunday,
                    DaysOfWeek = [Digests::DigestDayOfWeek.Sunday],
                    Disabled = true,
                    Frequency = Digests::DigestFrequency.Instant,
                    IsDefault = true,
                    Time = "time",
                    Timezone = "timezone",
                    Updated = "updated",
                },
            ],
            TemplateID = "template_id",
            AudienceID = "audience_id",
            Created = "created",
            TriggerEmpty = true,
            Updated = "updated",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TopicDigestResponse
        {
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
                    ScheduleID = "schedule_id",
                    Created = "created",
                    DayOfMonth = 0,
                    DayOfWeek = Digests::DigestDayOfWeek.Sunday,
                    DaysOfWeek = [Digests::DigestDayOfWeek.Sunday],
                    Disabled = true,
                    Frequency = Digests::DigestFrequency.Instant,
                    IsDefault = true,
                    Time = "time",
                    Timezone = "timezone",
                    Updated = "updated",
                },
            ],
            TemplateID = "template_id",
        };

        Assert.Null(model.AudienceID);
        Assert.False(model.RawData.ContainsKey("audience_id"));
        Assert.Null(model.Created);
        Assert.False(model.RawData.ContainsKey("created"));
        Assert.Null(model.TriggerEmpty);
        Assert.False(model.RawData.ContainsKey("trigger_empty"));
        Assert.Null(model.Updated);
        Assert.False(model.RawData.ContainsKey("updated"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TopicDigestResponse
        {
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
                    ScheduleID = "schedule_id",
                    Created = "created",
                    DayOfMonth = 0,
                    DayOfWeek = Digests::DigestDayOfWeek.Sunday,
                    DaysOfWeek = [Digests::DigestDayOfWeek.Sunday],
                    Disabled = true,
                    Frequency = Digests::DigestFrequency.Instant,
                    IsDefault = true,
                    Time = "time",
                    Timezone = "timezone",
                    Updated = "updated",
                },
            ],
            TemplateID = "template_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TopicDigestResponse
        {
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
                    ScheduleID = "schedule_id",
                    Created = "created",
                    DayOfMonth = 0,
                    DayOfWeek = Digests::DigestDayOfWeek.Sunday,
                    DaysOfWeek = [Digests::DigestDayOfWeek.Sunday],
                    Disabled = true,
                    Frequency = Digests::DigestFrequency.Instant,
                    IsDefault = true,
                    Time = "time",
                    Timezone = "timezone",
                    Updated = "updated",
                },
            ],
            TemplateID = "template_id",

            // Null should be interpreted as omitted for these properties
            AudienceID = null,
            Created = null,
            TriggerEmpty = null,
            Updated = null,
        };

        Assert.Null(model.AudienceID);
        Assert.False(model.RawData.ContainsKey("audience_id"));
        Assert.Null(model.Created);
        Assert.False(model.RawData.ContainsKey("created"));
        Assert.Null(model.TriggerEmpty);
        Assert.False(model.RawData.ContainsKey("trigger_empty"));
        Assert.Null(model.Updated);
        Assert.False(model.RawData.ContainsKey("updated"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TopicDigestResponse
        {
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
                    ScheduleID = "schedule_id",
                    Created = "created",
                    DayOfMonth = 0,
                    DayOfWeek = Digests::DigestDayOfWeek.Sunday,
                    DaysOfWeek = [Digests::DigestDayOfWeek.Sunday],
                    Disabled = true,
                    Frequency = Digests::DigestFrequency.Instant,
                    IsDefault = true,
                    Time = "time",
                    Timezone = "timezone",
                    Updated = "updated",
                },
            ],
            TemplateID = "template_id",

            // Null should be interpreted as omitted for these properties
            AudienceID = null,
            Created = null,
            TriggerEmpty = null,
            Updated = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopicDigestResponse
        {
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
                    ScheduleID = "schedule_id",
                    Created = "created",
                    DayOfMonth = 0,
                    DayOfWeek = Digests::DigestDayOfWeek.Sunday,
                    DaysOfWeek = [Digests::DigestDayOfWeek.Sunday],
                    Disabled = true,
                    Frequency = Digests::DigestFrequency.Instant,
                    IsDefault = true,
                    Time = "time",
                    Timezone = "timezone",
                    Updated = "updated",
                },
            ],
            TemplateID = "template_id",
            AudienceID = "audience_id",
            Created = "created",
            TriggerEmpty = true,
            Updated = "updated",
        };

        TopicDigestResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
