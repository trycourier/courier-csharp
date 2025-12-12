using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models;
using Courier.Models.Users.Preferences;

namespace Courier.Tests.Models.Users.Preferences;

public class TopicPreferenceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopicPreference
        {
            DefaultStatus = PreferenceStatus.OptedIn,
            Status = PreferenceStatus.OptedIn,
            TopicID = "topic_id",
            TopicName = "topic_name",
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
        };

        ApiEnum<string, PreferenceStatus> expectedDefaultStatus = PreferenceStatus.OptedIn;
        ApiEnum<string, PreferenceStatus> expectedStatus = PreferenceStatus.OptedIn;
        string expectedTopicID = "topic_id";
        string expectedTopicName = "topic_name";
        List<ApiEnum<string, ChannelClassification>> expectedCustomRouting =
        [
            ChannelClassification.DirectMessage,
        ];
        bool expectedHasCustomRouting = true;

        Assert.Equal(expectedDefaultStatus, model.DefaultStatus);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTopicID, model.TopicID);
        Assert.Equal(expectedTopicName, model.TopicName);
        Assert.NotNull(model.CustomRouting);
        Assert.Equal(expectedCustomRouting.Count, model.CustomRouting.Count);
        for (int i = 0; i < expectedCustomRouting.Count; i++)
        {
            Assert.Equal(expectedCustomRouting[i], model.CustomRouting[i]);
        }
        Assert.Equal(expectedHasCustomRouting, model.HasCustomRouting);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopicPreference
        {
            DefaultStatus = PreferenceStatus.OptedIn,
            Status = PreferenceStatus.OptedIn,
            TopicID = "topic_id",
            TopicName = "topic_name",
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TopicPreference>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopicPreference
        {
            DefaultStatus = PreferenceStatus.OptedIn,
            Status = PreferenceStatus.OptedIn,
            TopicID = "topic_id",
            TopicName = "topic_name",
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TopicPreference>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, PreferenceStatus> expectedDefaultStatus = PreferenceStatus.OptedIn;
        ApiEnum<string, PreferenceStatus> expectedStatus = PreferenceStatus.OptedIn;
        string expectedTopicID = "topic_id";
        string expectedTopicName = "topic_name";
        List<ApiEnum<string, ChannelClassification>> expectedCustomRouting =
        [
            ChannelClassification.DirectMessage,
        ];
        bool expectedHasCustomRouting = true;

        Assert.Equal(expectedDefaultStatus, deserialized.DefaultStatus);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTopicID, deserialized.TopicID);
        Assert.Equal(expectedTopicName, deserialized.TopicName);
        Assert.NotNull(deserialized.CustomRouting);
        Assert.Equal(expectedCustomRouting.Count, deserialized.CustomRouting.Count);
        for (int i = 0; i < expectedCustomRouting.Count; i++)
        {
            Assert.Equal(expectedCustomRouting[i], deserialized.CustomRouting[i]);
        }
        Assert.Equal(expectedHasCustomRouting, deserialized.HasCustomRouting);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopicPreference
        {
            DefaultStatus = PreferenceStatus.OptedIn,
            Status = PreferenceStatus.OptedIn,
            TopicID = "topic_id",
            TopicName = "topic_name",
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TopicPreference
        {
            DefaultStatus = PreferenceStatus.OptedIn,
            Status = PreferenceStatus.OptedIn,
            TopicID = "topic_id",
            TopicName = "topic_name",
        };

        Assert.Null(model.CustomRouting);
        Assert.False(model.RawData.ContainsKey("custom_routing"));
        Assert.Null(model.HasCustomRouting);
        Assert.False(model.RawData.ContainsKey("has_custom_routing"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TopicPreference
        {
            DefaultStatus = PreferenceStatus.OptedIn,
            Status = PreferenceStatus.OptedIn,
            TopicID = "topic_id",
            TopicName = "topic_name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TopicPreference
        {
            DefaultStatus = PreferenceStatus.OptedIn,
            Status = PreferenceStatus.OptedIn,
            TopicID = "topic_id",
            TopicName = "topic_name",

            CustomRouting = null,
            HasCustomRouting = null,
        };

        Assert.Null(model.CustomRouting);
        Assert.True(model.RawData.ContainsKey("custom_routing"));
        Assert.Null(model.HasCustomRouting);
        Assert.True(model.RawData.ContainsKey("has_custom_routing"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TopicPreference
        {
            DefaultStatus = PreferenceStatus.OptedIn,
            Status = PreferenceStatus.OptedIn,
            TopicID = "topic_id",
            TopicName = "topic_name",

            CustomRouting = null,
            HasCustomRouting = null,
        };

        model.Validate();
    }
}
