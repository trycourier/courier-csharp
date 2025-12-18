using System.Text.Json;
using Courier.Models;
using Courier.Models.Users.Preferences;

namespace Courier.Tests.Models.Users.Preferences;

public class PreferenceRetrieveTopicResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PreferenceRetrieveTopicResponse
        {
            Topic = new()
            {
                DefaultStatus = PreferenceStatus.OptedIn,
                Status = PreferenceStatus.OptedIn,
                TopicID = "topic_id",
                TopicName = "topic_name",
                CustomRouting = [ChannelClassification.DirectMessage],
                HasCustomRouting = true,
            },
        };

        TopicPreference expectedTopic = new()
        {
            DefaultStatus = PreferenceStatus.OptedIn,
            Status = PreferenceStatus.OptedIn,
            TopicID = "topic_id",
            TopicName = "topic_name",
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
        };

        Assert.Equal(expectedTopic, model.Topic);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PreferenceRetrieveTopicResponse
        {
            Topic = new()
            {
                DefaultStatus = PreferenceStatus.OptedIn,
                Status = PreferenceStatus.OptedIn,
                TopicID = "topic_id",
                TopicName = "topic_name",
                CustomRouting = [ChannelClassification.DirectMessage],
                HasCustomRouting = true,
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PreferenceRetrieveTopicResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PreferenceRetrieveTopicResponse
        {
            Topic = new()
            {
                DefaultStatus = PreferenceStatus.OptedIn,
                Status = PreferenceStatus.OptedIn,
                TopicID = "topic_id",
                TopicName = "topic_name",
                CustomRouting = [ChannelClassification.DirectMessage],
                HasCustomRouting = true,
            },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PreferenceRetrieveTopicResponse>(element);
        Assert.NotNull(deserialized);

        TopicPreference expectedTopic = new()
        {
            DefaultStatus = PreferenceStatus.OptedIn,
            Status = PreferenceStatus.OptedIn,
            TopicID = "topic_id",
            TopicName = "topic_name",
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
        };

        Assert.Equal(expectedTopic, deserialized.Topic);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PreferenceRetrieveTopicResponse
        {
            Topic = new()
            {
                DefaultStatus = PreferenceStatus.OptedIn,
                Status = PreferenceStatus.OptedIn,
                TopicID = "topic_id",
                TopicName = "topic_name",
                CustomRouting = [ChannelClassification.DirectMessage],
                HasCustomRouting = true,
            },
        };

        model.Validate();
    }
}
