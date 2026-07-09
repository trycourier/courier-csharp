using System;
using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models;
using TryCourier.Models.WorkspacePreferences.Topics;

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
            IncludeUnsubscribeHeader = true,
            RoutingOptions = [ChannelClassification.DirectMessage],
            TopicData = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string expectedSectionID = "section_id";
        ApiEnum<string, DefaultStatus> expectedDefaultStatus = DefaultStatus.OptedOut;
        string expectedName = "Marketing";
        List<ApiEnum<string, AllowedPreference>> expectedAllowedPreferences =
        [
            AllowedPreference.Snooze,
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
        var parameters = new TopicCreateParams
        {
            SectionID = "section_id",
            DefaultStatus = DefaultStatus.OptedOut,
            Name = "Marketing",
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
        var parameters = new TopicCreateParams
        {
            SectionID = "section_id",
            DefaultStatus = DefaultStatus.OptedOut,
            Name = "Marketing",

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
    public void CopyConstructor_Works()
    {
        var parameters = new TopicCreateParams
        {
            SectionID = "section_id",
            DefaultStatus = DefaultStatus.OptedOut,
            Name = "Marketing",
            AllowedPreferences = [AllowedPreference.Snooze],
            Description = "description",
            IncludeUnsubscribeHeader = true,
            RoutingOptions = [ChannelClassification.DirectMessage],
            TopicData = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
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
