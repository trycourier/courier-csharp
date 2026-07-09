using System;
using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models;
using TryCourier.Models.WorkspacePreferences.Topics;

namespace TryCourier.Tests.Models.WorkspacePreferences.Topics;

public class TopicReplaceParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TopicReplaceParams
        {
            SectionID = "section_id",
            TopicID = "topic_id",
            DefaultStatus = TopicReplaceParamsDefaultStatus.OptedOut,
            Name = "name",
            AllowedPreferences = [TopicReplaceParamsAllowedPreference.Snooze],
            Description = "description",
            IncludeUnsubscribeHeader = true,
            RoutingOptions = [ChannelClassification.DirectMessage],
            TopicData = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string expectedSectionID = "section_id";
        string expectedTopicID = "topic_id";
        ApiEnum<string, TopicReplaceParamsDefaultStatus> expectedDefaultStatus =
            TopicReplaceParamsDefaultStatus.OptedOut;
        string expectedName = "name";
        List<ApiEnum<string, TopicReplaceParamsAllowedPreference>> expectedAllowedPreferences =
        [
            TopicReplaceParamsAllowedPreference.Snooze,
        ];
        string expectedDescription = "description";
        bool expectedIncludeUnsubscribeHeader = true;
        List<ApiEnum<string, ChannelClassification>> expectedRoutingOptions =
        [
            ChannelClassification.DirectMessage,
        ];
        Dictionary<string, JsonElement> expectedTopicData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedSectionID, parameters.SectionID);
        Assert.Equal(expectedTopicID, parameters.TopicID);
        Assert.Equal(expectedDefaultStatus, parameters.DefaultStatus);
        Assert.Equal(expectedName, parameters.Name);
        Assert.NotNull(parameters.AllowedPreferences);
        Assert.Equal(expectedAllowedPreferences.Count, parameters.AllowedPreferences.Count);
        for (int i = 0; i < expectedAllowedPreferences.Count; i++)
        {
            Assert.Equal(expectedAllowedPreferences[i], parameters.AllowedPreferences[i]);
        }
        Assert.Equal(expectedDescription, parameters.Description);
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
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TopicReplaceParams
        {
            SectionID = "section_id",
            TopicID = "topic_id",
            DefaultStatus = TopicReplaceParamsDefaultStatus.OptedOut,
            Name = "name",
        };

        Assert.Null(parameters.AllowedPreferences);
        Assert.False(parameters.RawBodyData.ContainsKey("allowed_preferences"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
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
        var parameters = new TopicReplaceParams
        {
            SectionID = "section_id",
            TopicID = "topic_id",
            DefaultStatus = TopicReplaceParamsDefaultStatus.OptedOut,
            Name = "name",

            AllowedPreferences = null,
            Description = null,
            IncludeUnsubscribeHeader = null,
            RoutingOptions = null,
            TopicData = null,
        };

        Assert.Null(parameters.AllowedPreferences);
        Assert.True(parameters.RawBodyData.ContainsKey("allowed_preferences"));
        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
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
        TopicReplaceParams parameters = new()
        {
            SectionID = "section_id",
            TopicID = "topic_id",
            DefaultStatus = TopicReplaceParamsDefaultStatus.OptedOut,
            Name = "name",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.courier.com/preferences/sections/section_id/topics/topic_id"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TopicReplaceParams
        {
            SectionID = "section_id",
            TopicID = "topic_id",
            DefaultStatus = TopicReplaceParamsDefaultStatus.OptedOut,
            Name = "name",
            AllowedPreferences = [TopicReplaceParamsAllowedPreference.Snooze],
            Description = "description",
            IncludeUnsubscribeHeader = true,
            RoutingOptions = [ChannelClassification.DirectMessage],
            TopicData = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        TopicReplaceParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class TopicReplaceParamsDefaultStatusTest : TestBase
{
    [Theory]
    [InlineData(TopicReplaceParamsDefaultStatus.OptedOut)]
    [InlineData(TopicReplaceParamsDefaultStatus.OptedIn)]
    [InlineData(TopicReplaceParamsDefaultStatus.Required)]
    public void Validation_Works(TopicReplaceParamsDefaultStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TopicReplaceParamsDefaultStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TopicReplaceParamsDefaultStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TopicReplaceParamsDefaultStatus.OptedOut)]
    [InlineData(TopicReplaceParamsDefaultStatus.OptedIn)]
    [InlineData(TopicReplaceParamsDefaultStatus.Required)]
    public void SerializationRoundtrip_Works(TopicReplaceParamsDefaultStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TopicReplaceParamsDefaultStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TopicReplaceParamsDefaultStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TopicReplaceParamsDefaultStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TopicReplaceParamsDefaultStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TopicReplaceParamsAllowedPreferenceTest : TestBase
{
    [Theory]
    [InlineData(TopicReplaceParamsAllowedPreference.Snooze)]
    [InlineData(TopicReplaceParamsAllowedPreference.ChannelPreferences)]
    public void Validation_Works(TopicReplaceParamsAllowedPreference rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TopicReplaceParamsAllowedPreference> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, TopicReplaceParamsAllowedPreference>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TopicReplaceParamsAllowedPreference.Snooze)]
    [InlineData(TopicReplaceParamsAllowedPreference.ChannelPreferences)]
    public void SerializationRoundtrip_Works(TopicReplaceParamsAllowedPreference rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TopicReplaceParamsAllowedPreference> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TopicReplaceParamsAllowedPreference>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, TopicReplaceParamsAllowedPreference>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TopicReplaceParamsAllowedPreference>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
