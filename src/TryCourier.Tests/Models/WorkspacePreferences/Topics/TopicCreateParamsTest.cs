using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models;
using TryCourier.Models.Digests;
using TryCourier.Models.WorkspacePreferences.Topics;
using WorkspacePreferences = TryCourier.Models.WorkspacePreferences;

namespace TryCourier.Tests.Models.WorkspacePreferences.Topics;

public class TopicCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TopicCreateParams
        {
            SectionID = "section_id",
            DefaultStatus = DefaultStatus.OptedOut,
            Name = "Marketing",
            AllowedPreferences = [AllowedPreference.Snooze],
            Description = "description",
            Digest = new()
            {
                Schedules =
                [
                    new()
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
                        Retain = WorkspacePreferences::Retain.First,
                        SortKey = "sort_key",
                    },
                ],
                TriggerEmpty = true,
            },
            IncludeUnsubscribeHeader = true,
            RoutingOptions = [ChannelClassification.DirectMessage],
            TopicData = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            IdempotencyKey = "order-ORD-456-user-123",
            XIdempotencyExpiration = "1785312000",
        };

        string expectedSectionID = "section_id";
        ApiEnum<string, DefaultStatus> expectedDefaultStatus = DefaultStatus.OptedOut;
        string expectedName = "Marketing";
        List<ApiEnum<string, AllowedPreference>> expectedAllowedPreferences =
        [
            AllowedPreference.Snooze,
        ];
        string expectedDescription = "description";
        Digest expectedDigest = new()
        {
            Schedules =
            [
                new()
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
                    Retain = WorkspacePreferences::Retain.First,
                    SortKey = "sort_key",
                },
            ],
            TriggerEmpty = true,
        };
        bool expectedIncludeUnsubscribeHeader = true;
        List<ApiEnum<string, ChannelClassification>> expectedRoutingOptions =
        [
            ChannelClassification.DirectMessage,
        ];
        Dictionary<string, JsonElement> expectedTopicData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedIdempotencyKey = "order-ORD-456-user-123";
        string expectedXIdempotencyExpiration = "1785312000";

        Assert.Equal(expectedSectionID, parameters.SectionID);
        Assert.Equal(expectedDefaultStatus, parameters.DefaultStatus);
        Assert.Equal(expectedName, parameters.Name);
        Assert.NotNull(parameters.AllowedPreferences);
        Assert.Equal(expectedAllowedPreferences.Count, parameters.AllowedPreferences.Count);
        for (int i = 0; i < expectedAllowedPreferences.Count; i++)
        {
            Assert.Equal(expectedAllowedPreferences[i], parameters.AllowedPreferences[i]);
        }
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedDigest, parameters.Digest);
        Assert.Equal(expectedIncludeUnsubscribeHeader, parameters.IncludeUnsubscribeHeader);
        Assert.NotNull(parameters.RoutingOptions);
        Assert.Equal(expectedRoutingOptions.Count, parameters.RoutingOptions.Count);
        for (int i = 0; i < expectedRoutingOptions.Count; i++)
        {
            Assert.Equal(expectedRoutingOptions[i], parameters.RoutingOptions[i]);
        }
        Assert.NotNull(parameters.TopicData);
        Assert.Equal(expectedTopicData.Count, parameters.TopicData.Count);
        foreach (var item in expectedTopicData)
        {
            Assert.True(parameters.TopicData.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.TopicData[item.Key]));
        }
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedXIdempotencyExpiration, parameters.XIdempotencyExpiration);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TopicCreateParams
        {
            SectionID = "section_id",
            DefaultStatus = DefaultStatus.OptedOut,
            Name = "Marketing",
            AllowedPreferences = [AllowedPreference.Snooze],
            Description = "description",
            Digest = new()
            {
                Schedules =
                [
                    new()
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
                        Retain = WorkspacePreferences::Retain.First,
                        SortKey = "sort_key",
                    },
                ],
                TriggerEmpty = true,
            },
            IncludeUnsubscribeHeader = true,
            RoutingOptions = [ChannelClassification.DirectMessage],
            TopicData = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XIdempotencyExpiration);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-idempotency-expiration"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TopicCreateParams
        {
            SectionID = "section_id",
            DefaultStatus = DefaultStatus.OptedOut,
            Name = "Marketing",
            AllowedPreferences = [AllowedPreference.Snooze],
            Description = "description",
            Digest = new()
            {
                Schedules =
                [
                    new()
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
                        Retain = WorkspacePreferences::Retain.First,
                        SortKey = "sort_key",
                    },
                ],
                TriggerEmpty = true,
            },
            IncludeUnsubscribeHeader = true,
            RoutingOptions = [ChannelClassification.DirectMessage],
            TopicData = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },

            // Null should be interpreted as omitted for these properties
            IdempotencyKey = null,
            XIdempotencyExpiration = null,
        };

        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XIdempotencyExpiration);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-idempotency-expiration"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TopicCreateParams
        {
            SectionID = "section_id",
            DefaultStatus = DefaultStatus.OptedOut,
            Name = "Marketing",
            IdempotencyKey = "order-ORD-456-user-123",
            XIdempotencyExpiration = "1785312000",
        };

        Assert.Null(parameters.AllowedPreferences);
        Assert.False(parameters.RawBodyData.ContainsKey("allowed_preferences"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Digest);
        Assert.False(parameters.RawBodyData.ContainsKey("digest"));
        Assert.Null(parameters.IncludeUnsubscribeHeader);
        Assert.False(parameters.RawBodyData.ContainsKey("include_unsubscribe_header"));
        Assert.Null(parameters.RoutingOptions);
        Assert.False(parameters.RawBodyData.ContainsKey("routing_options"));
        Assert.Null(parameters.TopicData);
        Assert.False(parameters.RawBodyData.ContainsKey("topic_data"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new TopicCreateParams
        {
            SectionID = "section_id",
            DefaultStatus = DefaultStatus.OptedOut,
            Name = "Marketing",
            IdempotencyKey = "order-ORD-456-user-123",
            XIdempotencyExpiration = "1785312000",

            AllowedPreferences = null,
            Description = null,
            Digest = null,
            IncludeUnsubscribeHeader = null,
            RoutingOptions = null,
            TopicData = null,
        };

        Assert.Null(parameters.AllowedPreferences);
        Assert.True(parameters.RawBodyData.ContainsKey("allowed_preferences"));
        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Digest);
        Assert.True(parameters.RawBodyData.ContainsKey("digest"));
        Assert.Null(parameters.IncludeUnsubscribeHeader);
        Assert.True(parameters.RawBodyData.ContainsKey("include_unsubscribe_header"));
        Assert.Null(parameters.RoutingOptions);
        Assert.True(parameters.RawBodyData.ContainsKey("routing_options"));
        Assert.Null(parameters.TopicData);
        Assert.True(parameters.RawBodyData.ContainsKey("topic_data"));
    }

    [Fact]
    public void Url_Works()
    {
        TopicCreateParams parameters = new()
        {
            SectionID = "section_id",
            DefaultStatus = DefaultStatus.OptedOut,
            Name = "Marketing",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.courier.com/preferences/sections/section_id/topics"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        TopicCreateParams parameters = new()
        {
            SectionID = "section_id",
            DefaultStatus = DefaultStatus.OptedOut,
            Name = "Marketing",
            IdempotencyKey = "order-ORD-456-user-123",
            XIdempotencyExpiration = "1785312000",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(
            ["order-ORD-456-user-123"],
            requestMessage.Headers.GetValues("Idempotency-Key")
        );
        Assert.Equal(["1785312000"], requestMessage.Headers.GetValues("x-idempotency-expiration"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TopicCreateParams
        {
            SectionID = "section_id",
            DefaultStatus = DefaultStatus.OptedOut,
            Name = "Marketing",
            AllowedPreferences = [AllowedPreference.Snooze],
            Description = "description",
            Digest = new()
            {
                Schedules =
                [
                    new()
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
                        Retain = WorkspacePreferences::Retain.First,
                        SortKey = "sort_key",
                    },
                ],
                TriggerEmpty = true,
            },
            IncludeUnsubscribeHeader = true,
            RoutingOptions = [ChannelClassification.DirectMessage],
            TopicData = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            IdempotencyKey = "order-ORD-456-user-123",
            XIdempotencyExpiration = "1785312000",
        };

        TopicCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class DefaultStatusTest : TestBase
{
    [Theory]
    [InlineData(DefaultStatus.OptedOut)]
    [InlineData(DefaultStatus.OptedIn)]
    [InlineData(DefaultStatus.Required)]
    public void Validation_Works(DefaultStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DefaultStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DefaultStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DefaultStatus.OptedOut)]
    [InlineData(DefaultStatus.OptedIn)]
    [InlineData(DefaultStatus.Required)]
    public void SerializationRoundtrip_Works(DefaultStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DefaultStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DefaultStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DefaultStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DefaultStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AllowedPreferenceTest : TestBase
{
    [Theory]
    [InlineData(AllowedPreference.Snooze)]
    [InlineData(AllowedPreference.ChannelPreferences)]
    public void Validation_Works(AllowedPreference rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AllowedPreference> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AllowedPreference>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AllowedPreference.Snooze)]
    [InlineData(AllowedPreference.ChannelPreferences)]
    public void SerializationRoundtrip_Works(AllowedPreference rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AllowedPreference> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AllowedPreference>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AllowedPreference>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AllowedPreference>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DigestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Digest
        {
            Schedules =
            [
                new()
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
                    Retain = WorkspacePreferences::Retain.First,
                    SortKey = "sort_key",
                },
            ],
            TriggerEmpty = true,
        };

        List<WorkspacePreferences::TopicDigestScheduleRequest> expectedSchedules =
        [
            new()
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
            },
        ];
        string expectedTemplateID = "template_id";
        string expectedAudienceID = "audience_id";
        List<WorkspacePreferences::TopicDigestCategory> expectedCategories =
        [
            new()
            {
                CategoryKey = "category_key",
                Limit = 1,
                Retain = WorkspacePreferences::Retain.First,
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
        var model = new Digest
        {
            Schedules =
            [
                new()
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
                    Retain = WorkspacePreferences::Retain.First,
                    SortKey = "sort_key",
                },
            ],
            TriggerEmpty = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Digest>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Digest
        {
            Schedules =
            [
                new()
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
                    Retain = WorkspacePreferences::Retain.First,
                    SortKey = "sort_key",
                },
            ],
            TriggerEmpty = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Digest>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<WorkspacePreferences::TopicDigestScheduleRequest> expectedSchedules =
        [
            new()
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
            },
        ];
        string expectedTemplateID = "template_id";
        string expectedAudienceID = "audience_id";
        List<WorkspacePreferences::TopicDigestCategory> expectedCategories =
        [
            new()
            {
                CategoryKey = "category_key",
                Limit = 1,
                Retain = WorkspacePreferences::Retain.First,
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
        var model = new Digest
        {
            Schedules =
            [
                new()
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
                    Retain = WorkspacePreferences::Retain.First,
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
        var model = new Digest
        {
            Schedules =
            [
                new()
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
        var model = new Digest
        {
            Schedules =
            [
                new()
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
                },
            ],
            TemplateID = "template_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Digest
        {
            Schedules =
            [
                new()
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
        var model = new Digest
        {
            Schedules =
            [
                new()
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
        var model = new Digest
        {
            Schedules =
            [
                new()
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
                    Retain = WorkspacePreferences::Retain.First,
                    SortKey = "sort_key",
                },
            ],
            TriggerEmpty = true,
        };

        Digest copied = new(model);

        Assert.Equal(model, copied);
    }
}
