using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models;
using TryCourier.Models.PreferenceSections;

namespace TryCourier.Tests.Models.PreferenceSections;

public class PreferenceTopicListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PreferenceTopicListResponse
        {
            Results =
            [
                new()
                {
                    ID = "id",
                    AllowedPreferences = [PreferenceTopicGetResponseAllowedPreference.Snooze],
                    Created = "created",
                    DefaultStatus = PreferenceTopicGetResponseDefaultStatus.OptedOut,
                    IncludeUnsubscribeHeader = true,
                    Name = "name",
                    RoutingOptions = [ChannelClassification.DirectMessage],
                    TopicData = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Updated = "updated",
                    Creator = "creator",
                    Updater = "updater",
                },
            ],
        };

        List<PreferenceTopicGetResponse> expectedResults =
        [
            new()
            {
                ID = "id",
                AllowedPreferences = [PreferenceTopicGetResponseAllowedPreference.Snooze],
                Created = "created",
                DefaultStatus = PreferenceTopicGetResponseDefaultStatus.OptedOut,
                IncludeUnsubscribeHeader = true,
                Name = "name",
                RoutingOptions = [ChannelClassification.DirectMessage],
                TopicData = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Updated = "updated",
                Creator = "creator",
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
        var model = new PreferenceTopicListResponse
        {
            Results =
            [
                new()
                {
                    ID = "id",
                    AllowedPreferences = [PreferenceTopicGetResponseAllowedPreference.Snooze],
                    Created = "created",
                    DefaultStatus = PreferenceTopicGetResponseDefaultStatus.OptedOut,
                    IncludeUnsubscribeHeader = true,
                    Name = "name",
                    RoutingOptions = [ChannelClassification.DirectMessage],
                    TopicData = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Updated = "updated",
                    Creator = "creator",
                    Updater = "updater",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreferenceTopicListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PreferenceTopicListResponse
        {
            Results =
            [
                new()
                {
                    ID = "id",
                    AllowedPreferences = [PreferenceTopicGetResponseAllowedPreference.Snooze],
                    Created = "created",
                    DefaultStatus = PreferenceTopicGetResponseDefaultStatus.OptedOut,
                    IncludeUnsubscribeHeader = true,
                    Name = "name",
                    RoutingOptions = [ChannelClassification.DirectMessage],
                    TopicData = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Updated = "updated",
                    Creator = "creator",
                    Updater = "updater",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreferenceTopicListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<PreferenceTopicGetResponse> expectedResults =
        [
            new()
            {
                ID = "id",
                AllowedPreferences = [PreferenceTopicGetResponseAllowedPreference.Snooze],
                Created = "created",
                DefaultStatus = PreferenceTopicGetResponseDefaultStatus.OptedOut,
                IncludeUnsubscribeHeader = true,
                Name = "name",
                RoutingOptions = [ChannelClassification.DirectMessage],
                TopicData = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Updated = "updated",
                Creator = "creator",
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
        var model = new PreferenceTopicListResponse
        {
            Results =
            [
                new()
                {
                    ID = "id",
                    AllowedPreferences = [PreferenceTopicGetResponseAllowedPreference.Snooze],
                    Created = "created",
                    DefaultStatus = PreferenceTopicGetResponseDefaultStatus.OptedOut,
                    IncludeUnsubscribeHeader = true,
                    Name = "name",
                    RoutingOptions = [ChannelClassification.DirectMessage],
                    TopicData = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Updated = "updated",
                    Creator = "creator",
                    Updater = "updater",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PreferenceTopicListResponse
        {
            Results =
            [
                new()
                {
                    ID = "id",
                    AllowedPreferences = [PreferenceTopicGetResponseAllowedPreference.Snooze],
                    Created = "created",
                    DefaultStatus = PreferenceTopicGetResponseDefaultStatus.OptedOut,
                    IncludeUnsubscribeHeader = true,
                    Name = "name",
                    RoutingOptions = [ChannelClassification.DirectMessage],
                    TopicData = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Updated = "updated",
                    Creator = "creator",
                    Updater = "updater",
                },
            ],
        };

        PreferenceTopicListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
