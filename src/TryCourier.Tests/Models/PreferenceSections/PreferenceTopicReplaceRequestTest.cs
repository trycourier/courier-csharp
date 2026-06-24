using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models;
using TryCourier.Models.PreferenceSections;

namespace TryCourier.Tests.Models.PreferenceSections;

public class PreferenceTopicReplaceRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PreferenceTopicReplaceRequest
        {
            DefaultStatus = PreferenceTopicReplaceRequestDefaultStatus.OptedOut,
            Name = "name",
            AllowedPreferences = [PreferenceTopicReplaceRequestAllowedPreference.Snooze],
            IncludeUnsubscribeHeader = true,
            RoutingOptions = [ChannelClassification.DirectMessage],
            TopicData = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        ApiEnum<string, PreferenceTopicReplaceRequestDefaultStatus> expectedDefaultStatus =
            PreferenceTopicReplaceRequestDefaultStatus.OptedOut;
        string expectedName = "name";
        List<
            ApiEnum<string, PreferenceTopicReplaceRequestAllowedPreference>
        > expectedAllowedPreferences = [PreferenceTopicReplaceRequestAllowedPreference.Snooze];
        bool expectedIncludeUnsubscribeHeader = true;
        List<ApiEnum<string, ChannelClassification>> expectedRoutingOptions =
        [
            ChannelClassification.DirectMessage,
        ];
        Dictionary<string, JsonElement> expectedTopicData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedDefaultStatus, model.DefaultStatus);
        Assert.Equal(expectedName, model.Name);
        Assert.NotNull(model.AllowedPreferences);
        Assert.Equal(expectedAllowedPreferences.Count, model.AllowedPreferences.Count);
        for (int i = 0; i < expectedAllowedPreferences.Count; i++)
        {
            Assert.Equal(expectedAllowedPreferences[i], model.AllowedPreferences[i]);
        }
        Assert.Equal(expectedIncludeUnsubscribeHeader, model.IncludeUnsubscribeHeader);
        Assert.NotNull(model.RoutingOptions);
        Assert.Equal(expectedRoutingOptions.Count, model.RoutingOptions.Count);
        for (int i = 0; i < expectedRoutingOptions.Count; i++)
        {
            Assert.Equal(expectedRoutingOptions[i], model.RoutingOptions[i]);
        }
        Assert.NotNull(model.TopicData);
        Assert.Equal(expectedTopicData.Count, model.TopicData.Count);
        foreach (var item in expectedTopicData)
        {
            Assert.True(model.TopicData.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.TopicData[item.Key]));
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PreferenceTopicReplaceRequest
        {
            DefaultStatus = PreferenceTopicReplaceRequestDefaultStatus.OptedOut,
            Name = "name",
            AllowedPreferences = [PreferenceTopicReplaceRequestAllowedPreference.Snooze],
            IncludeUnsubscribeHeader = true,
            RoutingOptions = [ChannelClassification.DirectMessage],
            TopicData = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreferenceTopicReplaceRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PreferenceTopicReplaceRequest
        {
            DefaultStatus = PreferenceTopicReplaceRequestDefaultStatus.OptedOut,
            Name = "name",
            AllowedPreferences = [PreferenceTopicReplaceRequestAllowedPreference.Snooze],
            IncludeUnsubscribeHeader = true,
            RoutingOptions = [ChannelClassification.DirectMessage],
            TopicData = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreferenceTopicReplaceRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, PreferenceTopicReplaceRequestDefaultStatus> expectedDefaultStatus =
            PreferenceTopicReplaceRequestDefaultStatus.OptedOut;
        string expectedName = "name";
        List<
            ApiEnum<string, PreferenceTopicReplaceRequestAllowedPreference>
        > expectedAllowedPreferences = [PreferenceTopicReplaceRequestAllowedPreference.Snooze];
        bool expectedIncludeUnsubscribeHeader = true;
        List<ApiEnum<string, ChannelClassification>> expectedRoutingOptions =
        [
            ChannelClassification.DirectMessage,
        ];
        Dictionary<string, JsonElement> expectedTopicData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedDefaultStatus, deserialized.DefaultStatus);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.NotNull(deserialized.AllowedPreferences);
        Assert.Equal(expectedAllowedPreferences.Count, deserialized.AllowedPreferences.Count);
        for (int i = 0; i < expectedAllowedPreferences.Count; i++)
        {
            Assert.Equal(expectedAllowedPreferences[i], deserialized.AllowedPreferences[i]);
        }
        Assert.Equal(expectedIncludeUnsubscribeHeader, deserialized.IncludeUnsubscribeHeader);
        Assert.NotNull(deserialized.RoutingOptions);
        Assert.Equal(expectedRoutingOptions.Count, deserialized.RoutingOptions.Count);
        for (int i = 0; i < expectedRoutingOptions.Count; i++)
        {
            Assert.Equal(expectedRoutingOptions[i], deserialized.RoutingOptions[i]);
        }
        Assert.NotNull(deserialized.TopicData);
        Assert.Equal(expectedTopicData.Count, deserialized.TopicData.Count);
        foreach (var item in expectedTopicData)
        {
            Assert.True(deserialized.TopicData.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.TopicData[item.Key]));
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PreferenceTopicReplaceRequest
        {
            DefaultStatus = PreferenceTopicReplaceRequestDefaultStatus.OptedOut,
            Name = "name",
            AllowedPreferences = [PreferenceTopicReplaceRequestAllowedPreference.Snooze],
            IncludeUnsubscribeHeader = true,
            RoutingOptions = [ChannelClassification.DirectMessage],
            TopicData = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PreferenceTopicReplaceRequest
        {
            DefaultStatus = PreferenceTopicReplaceRequestDefaultStatus.OptedOut,
            Name = "name",
        };

        Assert.Null(model.AllowedPreferences);
        Assert.False(model.RawData.ContainsKey("allowed_preferences"));
        Assert.Null(model.IncludeUnsubscribeHeader);
        Assert.False(model.RawData.ContainsKey("include_unsubscribe_header"));
        Assert.Null(model.RoutingOptions);
        Assert.False(model.RawData.ContainsKey("routing_options"));
        Assert.Null(model.TopicData);
        Assert.False(model.RawData.ContainsKey("topic_data"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PreferenceTopicReplaceRequest
        {
            DefaultStatus = PreferenceTopicReplaceRequestDefaultStatus.OptedOut,
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PreferenceTopicReplaceRequest
        {
            DefaultStatus = PreferenceTopicReplaceRequestDefaultStatus.OptedOut,
            Name = "name",

            AllowedPreferences = null,
            IncludeUnsubscribeHeader = null,
            RoutingOptions = null,
            TopicData = null,
        };

        Assert.Null(model.AllowedPreferences);
        Assert.True(model.RawData.ContainsKey("allowed_preferences"));
        Assert.Null(model.IncludeUnsubscribeHeader);
        Assert.True(model.RawData.ContainsKey("include_unsubscribe_header"));
        Assert.Null(model.RoutingOptions);
        Assert.True(model.RawData.ContainsKey("routing_options"));
        Assert.Null(model.TopicData);
        Assert.True(model.RawData.ContainsKey("topic_data"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PreferenceTopicReplaceRequest
        {
            DefaultStatus = PreferenceTopicReplaceRequestDefaultStatus.OptedOut,
            Name = "name",

            AllowedPreferences = null,
            IncludeUnsubscribeHeader = null,
            RoutingOptions = null,
            TopicData = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PreferenceTopicReplaceRequest
        {
            DefaultStatus = PreferenceTopicReplaceRequestDefaultStatus.OptedOut,
            Name = "name",
            AllowedPreferences = [PreferenceTopicReplaceRequestAllowedPreference.Snooze],
            IncludeUnsubscribeHeader = true,
            RoutingOptions = [ChannelClassification.DirectMessage],
            TopicData = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        PreferenceTopicReplaceRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PreferenceTopicReplaceRequestDefaultStatusTest : TestBase
{
    [Theory]
    [InlineData(PreferenceTopicReplaceRequestDefaultStatus.OptedOut)]
    [InlineData(PreferenceTopicReplaceRequestDefaultStatus.OptedIn)]
    [InlineData(PreferenceTopicReplaceRequestDefaultStatus.Required)]
    public void Validation_Works(PreferenceTopicReplaceRequestDefaultStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PreferenceTopicReplaceRequestDefaultStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PreferenceTopicReplaceRequestDefaultStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PreferenceTopicReplaceRequestDefaultStatus.OptedOut)]
    [InlineData(PreferenceTopicReplaceRequestDefaultStatus.OptedIn)]
    [InlineData(PreferenceTopicReplaceRequestDefaultStatus.Required)]
    public void SerializationRoundtrip_Works(PreferenceTopicReplaceRequestDefaultStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PreferenceTopicReplaceRequestDefaultStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PreferenceTopicReplaceRequestDefaultStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PreferenceTopicReplaceRequestDefaultStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PreferenceTopicReplaceRequestDefaultStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PreferenceTopicReplaceRequestAllowedPreferenceTest : TestBase
{
    [Theory]
    [InlineData(PreferenceTopicReplaceRequestAllowedPreference.Snooze)]
    [InlineData(PreferenceTopicReplaceRequestAllowedPreference.ChannelPreferences)]
    public void Validation_Works(PreferenceTopicReplaceRequestAllowedPreference rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PreferenceTopicReplaceRequestAllowedPreference> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PreferenceTopicReplaceRequestAllowedPreference>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PreferenceTopicReplaceRequestAllowedPreference.Snooze)]
    [InlineData(PreferenceTopicReplaceRequestAllowedPreference.ChannelPreferences)]
    public void SerializationRoundtrip_Works(
        PreferenceTopicReplaceRequestAllowedPreference rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PreferenceTopicReplaceRequestAllowedPreference> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PreferenceTopicReplaceRequestAllowedPreference>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PreferenceTopicReplaceRequestAllowedPreference>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PreferenceTopicReplaceRequestAllowedPreference>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
