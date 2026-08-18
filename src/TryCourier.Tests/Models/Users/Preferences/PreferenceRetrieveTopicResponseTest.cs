using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models;
using TryCourier.Models.Users.Preferences;

namespace TryCourier.Tests.Models.Users.Preferences;

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
                SectionID = "section_id",
                SectionName = "section_name",
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
            SectionID = "section_id",
            SectionName = "section_name",
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
                SectionID = "section_id",
                SectionName = "section_name",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreferenceRetrieveTopicResponse>(
            json,
            ModelBase.SerializerOptions
        );

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
                SectionID = "section_id",
                SectionName = "section_name",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreferenceRetrieveTopicResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        TopicPreference expectedTopic = new()
        {
            DefaultStatus = PreferenceStatus.OptedIn,
            Status = PreferenceStatus.OptedIn,
            TopicID = "topic_id",
            TopicName = "topic_name",
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
            SectionID = "section_id",
            SectionName = "section_name",
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
                SectionID = "section_id",
                SectionName = "section_name",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
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
                SectionID = "section_id",
                SectionName = "section_name",
            },
        };

        PreferenceRetrieveTopicResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
