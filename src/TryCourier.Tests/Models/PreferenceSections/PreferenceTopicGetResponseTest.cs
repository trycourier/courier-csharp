using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models;
using TryCourier.Models.PreferenceSections;

namespace TryCourier.Tests.Models.PreferenceSections;

public class PreferenceTopicGetResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PreferenceTopicGetResponse
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
        };

        string expectedID = "id";
        List<
            ApiEnum<string, PreferenceTopicGetResponseAllowedPreference>
        > expectedAllowedPreferences = [PreferenceTopicGetResponseAllowedPreference.Snooze];
        string expectedCreated = "created";
        ApiEnum<string, PreferenceTopicGetResponseDefaultStatus> expectedDefaultStatus =
            PreferenceTopicGetResponseDefaultStatus.OptedOut;
        bool expectedIncludeUnsubscribeHeader = true;
        string expectedName = "name";
        List<ApiEnum<string, ChannelClassification>> expectedRoutingOptions =
        [
            ChannelClassification.DirectMessage,
        ];
        Dictionary<string, JsonElement> expectedTopicData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedUpdated = "updated";
        string expectedCreator = "creator";
        string expectedUpdater = "updater";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAllowedPreferences.Count, model.AllowedPreferences.Count);
        for (int i = 0; i < expectedAllowedPreferences.Count; i++)
        {
            Assert.Equal(expectedAllowedPreferences[i], model.AllowedPreferences[i]);
        }
        Assert.Equal(expectedCreated, model.Created);
        Assert.Equal(expectedDefaultStatus, model.DefaultStatus);
        Assert.Equal(expectedIncludeUnsubscribeHeader, model.IncludeUnsubscribeHeader);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedRoutingOptions.Count, model.RoutingOptions.Count);
        for (int i = 0; i < expectedRoutingOptions.Count; i++)
        {
            Assert.Equal(expectedRoutingOptions[i], model.RoutingOptions[i]);
        }
        Assert.Equal(expectedTopicData.Count, model.TopicData.Count);
        foreach (var item in expectedTopicData)
        {
            Assert.True(model.TopicData.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.TopicData[item.Key]));
        }
        Assert.Equal(expectedUpdated, model.Updated);
        Assert.Equal(expectedCreator, model.Creator);
        Assert.Equal(expectedUpdater, model.Updater);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PreferenceTopicGetResponse
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreferenceTopicGetResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PreferenceTopicGetResponse
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreferenceTopicGetResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<
            ApiEnum<string, PreferenceTopicGetResponseAllowedPreference>
        > expectedAllowedPreferences = [PreferenceTopicGetResponseAllowedPreference.Snooze];
        string expectedCreated = "created";
        ApiEnum<string, PreferenceTopicGetResponseDefaultStatus> expectedDefaultStatus =
            PreferenceTopicGetResponseDefaultStatus.OptedOut;
        bool expectedIncludeUnsubscribeHeader = true;
        string expectedName = "name";
        List<ApiEnum<string, ChannelClassification>> expectedRoutingOptions =
        [
            ChannelClassification.DirectMessage,
        ];
        Dictionary<string, JsonElement> expectedTopicData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedUpdated = "updated";
        string expectedCreator = "creator";
        string expectedUpdater = "updater";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAllowedPreferences.Count, deserialized.AllowedPreferences.Count);
        for (int i = 0; i < expectedAllowedPreferences.Count; i++)
        {
            Assert.Equal(expectedAllowedPreferences[i], deserialized.AllowedPreferences[i]);
        }
        Assert.Equal(expectedCreated, deserialized.Created);
        Assert.Equal(expectedDefaultStatus, deserialized.DefaultStatus);
        Assert.Equal(expectedIncludeUnsubscribeHeader, deserialized.IncludeUnsubscribeHeader);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedRoutingOptions.Count, deserialized.RoutingOptions.Count);
        for (int i = 0; i < expectedRoutingOptions.Count; i++)
        {
            Assert.Equal(expectedRoutingOptions[i], deserialized.RoutingOptions[i]);
        }
        Assert.Equal(expectedTopicData.Count, deserialized.TopicData.Count);
        foreach (var item in expectedTopicData)
        {
            Assert.True(deserialized.TopicData.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.TopicData[item.Key]));
        }
        Assert.Equal(expectedUpdated, deserialized.Updated);
        Assert.Equal(expectedCreator, deserialized.Creator);
        Assert.Equal(expectedUpdater, deserialized.Updater);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PreferenceTopicGetResponse
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PreferenceTopicGetResponse
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
        };

        Assert.Null(model.Creator);
        Assert.False(model.RawData.ContainsKey("creator"));
        Assert.Null(model.Updater);
        Assert.False(model.RawData.ContainsKey("updater"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PreferenceTopicGetResponse
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PreferenceTopicGetResponse
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

            Creator = null,
            Updater = null,
        };

        Assert.Null(model.Creator);
        Assert.True(model.RawData.ContainsKey("creator"));
        Assert.Null(model.Updater);
        Assert.True(model.RawData.ContainsKey("updater"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PreferenceTopicGetResponse
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

            Creator = null,
            Updater = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PreferenceTopicGetResponse
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
        };

        PreferenceTopicGetResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PreferenceTopicGetResponseAllowedPreferenceTest : TestBase
{
    [Theory]
    [InlineData(PreferenceTopicGetResponseAllowedPreference.Snooze)]
    [InlineData(PreferenceTopicGetResponseAllowedPreference.ChannelPreferences)]
    public void Validation_Works(PreferenceTopicGetResponseAllowedPreference rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PreferenceTopicGetResponseAllowedPreference> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PreferenceTopicGetResponseAllowedPreference>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PreferenceTopicGetResponseAllowedPreference.Snooze)]
    [InlineData(PreferenceTopicGetResponseAllowedPreference.ChannelPreferences)]
    public void SerializationRoundtrip_Works(PreferenceTopicGetResponseAllowedPreference rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PreferenceTopicGetResponseAllowedPreference> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PreferenceTopicGetResponseAllowedPreference>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PreferenceTopicGetResponseAllowedPreference>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PreferenceTopicGetResponseAllowedPreference>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PreferenceTopicGetResponseDefaultStatusTest : TestBase
{
    [Theory]
    [InlineData(PreferenceTopicGetResponseDefaultStatus.OptedOut)]
    [InlineData(PreferenceTopicGetResponseDefaultStatus.OptedIn)]
    [InlineData(PreferenceTopicGetResponseDefaultStatus.Required)]
    public void Validation_Works(PreferenceTopicGetResponseDefaultStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PreferenceTopicGetResponseDefaultStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PreferenceTopicGetResponseDefaultStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PreferenceTopicGetResponseDefaultStatus.OptedOut)]
    [InlineData(PreferenceTopicGetResponseDefaultStatus.OptedIn)]
    [InlineData(PreferenceTopicGetResponseDefaultStatus.Required)]
    public void SerializationRoundtrip_Works(PreferenceTopicGetResponseDefaultStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PreferenceTopicGetResponseDefaultStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PreferenceTopicGetResponseDefaultStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PreferenceTopicGetResponseDefaultStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PreferenceTopicGetResponseDefaultStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
