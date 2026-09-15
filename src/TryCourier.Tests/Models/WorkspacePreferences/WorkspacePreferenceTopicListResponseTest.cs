using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models;
using TryCourier.Models.WorkspacePreferences;
using Digests = TryCourier.Models.Digests;

namespace TryCourier.Tests.Models.WorkspacePreferences;

public class WorkspacePreferenceTopicListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorkspacePreferenceTopicListResponse
        {
            Results =
            [
                new()
                {
                    ID = "id",
                    AllowedPreferences =
                    [
                        WorkspacePreferenceTopicGetResponseAllowedPreference.Snooze,
                    ],
                    Created = "created",
                    DefaultStatus = WorkspacePreferenceTopicGetResponseDefaultStatus.OptedOut,
                    IncludeUnsubscribeHeader = true,
                    Name = "name",
                    RoutingOptions = [ChannelClassification.DirectMessage],
                    TopicData = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Updated = "updated",
                    Creator = "creator",
                    Description = "description",
                    Digest = new()
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
                    },
                    Updater = "updater",
                },
            ],
        };

        List<WorkspacePreferenceTopicGetResponse> expectedResults =
        [
            new()
            {
                ID = "id",
                AllowedPreferences = [WorkspacePreferenceTopicGetResponseAllowedPreference.Snooze],
                Created = "created",
                DefaultStatus = WorkspacePreferenceTopicGetResponseDefaultStatus.OptedOut,
                IncludeUnsubscribeHeader = true,
                Name = "name",
                RoutingOptions = [ChannelClassification.DirectMessage],
                TopicData = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Updated = "updated",
                Creator = "creator",
                Description = "description",
                Digest = new()
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
                },
                Updater = "updater",
            },
        ];

        Assert.Equal(expectedResults.Count, model.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], model.Results[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WorkspacePreferenceTopicListResponse
        {
            Results =
            [
                new()
                {
                    ID = "id",
                    AllowedPreferences =
                    [
                        WorkspacePreferenceTopicGetResponseAllowedPreference.Snooze,
                    ],
                    Created = "created",
                    DefaultStatus = WorkspacePreferenceTopicGetResponseDefaultStatus.OptedOut,
                    IncludeUnsubscribeHeader = true,
                    Name = "name",
                    RoutingOptions = [ChannelClassification.DirectMessage],
                    TopicData = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Updated = "updated",
                    Creator = "creator",
                    Description = "description",
                    Digest = new()
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
                    },
                    Updater = "updater",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkspacePreferenceTopicListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WorkspacePreferenceTopicListResponse
        {
            Results =
            [
                new()
                {
                    ID = "id",
                    AllowedPreferences =
                    [
                        WorkspacePreferenceTopicGetResponseAllowedPreference.Snooze,
                    ],
                    Created = "created",
                    DefaultStatus = WorkspacePreferenceTopicGetResponseDefaultStatus.OptedOut,
                    IncludeUnsubscribeHeader = true,
                    Name = "name",
                    RoutingOptions = [ChannelClassification.DirectMessage],
                    TopicData = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Updated = "updated",
                    Creator = "creator",
                    Description = "description",
                    Digest = new()
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
                    },
                    Updater = "updater",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkspacePreferenceTopicListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<WorkspacePreferenceTopicGetResponse> expectedResults =
        [
            new()
            {
                ID = "id",
                AllowedPreferences = [WorkspacePreferenceTopicGetResponseAllowedPreference.Snooze],
                Created = "created",
                DefaultStatus = WorkspacePreferenceTopicGetResponseDefaultStatus.OptedOut,
                IncludeUnsubscribeHeader = true,
                Name = "name",
                RoutingOptions = [ChannelClassification.DirectMessage],
                TopicData = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Updated = "updated",
                Creator = "creator",
                Description = "description",
                Digest = new()
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
                },
                Updater = "updater",
            },
        ];

        Assert.Equal(expectedResults.Count, deserialized.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], deserialized.Results[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WorkspacePreferenceTopicListResponse
        {
            Results =
            [
                new()
                {
                    ID = "id",
                    AllowedPreferences =
                    [
                        WorkspacePreferenceTopicGetResponseAllowedPreference.Snooze,
                    ],
                    Created = "created",
                    DefaultStatus = WorkspacePreferenceTopicGetResponseDefaultStatus.OptedOut,
                    IncludeUnsubscribeHeader = true,
                    Name = "name",
                    RoutingOptions = [ChannelClassification.DirectMessage],
                    TopicData = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Updated = "updated",
                    Creator = "creator",
                    Description = "description",
                    Digest = new()
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
                    },
                    Updater = "updater",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WorkspacePreferenceTopicListResponse
        {
            Results =
            [
                new()
                {
                    ID = "id",
                    AllowedPreferences =
                    [
                        WorkspacePreferenceTopicGetResponseAllowedPreference.Snooze,
                    ],
                    Created = "created",
                    DefaultStatus = WorkspacePreferenceTopicGetResponseDefaultStatus.OptedOut,
                    IncludeUnsubscribeHeader = true,
                    Name = "name",
                    RoutingOptions = [ChannelClassification.DirectMessage],
                    TopicData = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Updated = "updated",
                    Creator = "creator",
                    Description = "description",
                    Digest = new()
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
                    },
                    Updater = "updater",
                },
            ],
        };

        WorkspacePreferenceTopicListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
