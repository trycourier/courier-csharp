using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models;
using TryCourier.Models.WorkspacePreferences;

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
                    Updater = "updater",
                },
            ],
        };

        WorkspacePreferenceTopicListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
