using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models;
using TryCourier.Models.PreferenceSections;

namespace TryCourier.Tests.Models.PreferenceSections;

public class PreferenceSectionGetResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PreferenceSectionGetResponse
        {
            ID = "id",
            Created = "created",
            HasCustomRouting = true,
            Name = "name",
            RoutingOptions = [ChannelClassification.DirectMessage],
            Topics =
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
            Creator = "creator",
            Updated = "updated",
            Updater = "updater",
        };

        string expectedID = "id";
        string expectedCreated = "created";
        bool expectedHasCustomRouting = true;
        string expectedName = "name";
        List<ApiEnum<string, ChannelClassification>> expectedRoutingOptions =
        [
            ChannelClassification.DirectMessage,
        ];
        List<PreferenceTopicGetResponse> expectedTopics =
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
        string expectedCreator = "creator";
        string expectedUpdated = "updated";
        string expectedUpdater = "updater";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreated, model.Created);
        Assert.Equal(expectedHasCustomRouting, model.HasCustomRouting);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedRoutingOptions.Count, model.RoutingOptions.Count);
        for (int i = 0; i < expectedRoutingOptions.Count; i++)
        {
            Assert.Equal(expectedRoutingOptions[i], model.RoutingOptions[i]);
        }
        Assert.Equal(expectedTopics.Count, model.Topics.Count);
        for (int i = 0; i < expectedTopics.Count; i++)
        {
            Assert.Equal(expectedTopics[i], model.Topics[i]);
        }
        Assert.Equal(expectedCreator, model.Creator);
        Assert.Equal(expectedUpdated, model.Updated);
        Assert.Equal(expectedUpdater, model.Updater);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PreferenceSectionGetResponse
        {
            ID = "id",
            Created = "created",
            HasCustomRouting = true,
            Name = "name",
            RoutingOptions = [ChannelClassification.DirectMessage],
            Topics =
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
            Creator = "creator",
            Updated = "updated",
            Updater = "updater",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreferenceSectionGetResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PreferenceSectionGetResponse
        {
            ID = "id",
            Created = "created",
            HasCustomRouting = true,
            Name = "name",
            RoutingOptions = [ChannelClassification.DirectMessage],
            Topics =
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
            Creator = "creator",
            Updated = "updated",
            Updater = "updater",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreferenceSectionGetResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedCreated = "created";
        bool expectedHasCustomRouting = true;
        string expectedName = "name";
        List<ApiEnum<string, ChannelClassification>> expectedRoutingOptions =
        [
            ChannelClassification.DirectMessage,
        ];
        List<PreferenceTopicGetResponse> expectedTopics =
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
        string expectedCreator = "creator";
        string expectedUpdated = "updated";
        string expectedUpdater = "updater";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreated, deserialized.Created);
        Assert.Equal(expectedHasCustomRouting, deserialized.HasCustomRouting);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedRoutingOptions.Count, deserialized.RoutingOptions.Count);
        for (int i = 0; i < expectedRoutingOptions.Count; i++)
        {
            Assert.Equal(expectedRoutingOptions[i], deserialized.RoutingOptions[i]);
        }
        Assert.Equal(expectedTopics.Count, deserialized.Topics.Count);
        for (int i = 0; i < expectedTopics.Count; i++)
        {
            Assert.Equal(expectedTopics[i], deserialized.Topics[i]);
        }
        Assert.Equal(expectedCreator, deserialized.Creator);
        Assert.Equal(expectedUpdated, deserialized.Updated);
        Assert.Equal(expectedUpdater, deserialized.Updater);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PreferenceSectionGetResponse
        {
            ID = "id",
            Created = "created",
            HasCustomRouting = true,
            Name = "name",
            RoutingOptions = [ChannelClassification.DirectMessage],
            Topics =
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
            Creator = "creator",
            Updated = "updated",
            Updater = "updater",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PreferenceSectionGetResponse
        {
            ID = "id",
            Created = "created",
            HasCustomRouting = true,
            Name = "name",
            RoutingOptions = [ChannelClassification.DirectMessage],
            Topics =
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

        Assert.Null(model.Creator);
        Assert.False(model.RawData.ContainsKey("creator"));
        Assert.Null(model.Updated);
        Assert.False(model.RawData.ContainsKey("updated"));
        Assert.Null(model.Updater);
        Assert.False(model.RawData.ContainsKey("updater"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PreferenceSectionGetResponse
        {
            ID = "id",
            Created = "created",
            HasCustomRouting = true,
            Name = "name",
            RoutingOptions = [ChannelClassification.DirectMessage],
            Topics =
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
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PreferenceSectionGetResponse
        {
            ID = "id",
            Created = "created",
            HasCustomRouting = true,
            Name = "name",
            RoutingOptions = [ChannelClassification.DirectMessage],
            Topics =
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

            Creator = null,
            Updated = null,
            Updater = null,
        };

        Assert.Null(model.Creator);
        Assert.True(model.RawData.ContainsKey("creator"));
        Assert.Null(model.Updated);
        Assert.True(model.RawData.ContainsKey("updated"));
        Assert.Null(model.Updater);
        Assert.True(model.RawData.ContainsKey("updater"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PreferenceSectionGetResponse
        {
            ID = "id",
            Created = "created",
            HasCustomRouting = true,
            Name = "name",
            RoutingOptions = [ChannelClassification.DirectMessage],
            Topics =
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

            Creator = null,
            Updated = null,
            Updater = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PreferenceSectionGetResponse
        {
            ID = "id",
            Created = "created",
            HasCustomRouting = true,
            Name = "name",
            RoutingOptions = [ChannelClassification.DirectMessage],
            Topics =
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
            Creator = "creator",
            Updated = "updated",
            Updater = "updater",
        };

        PreferenceSectionGetResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
