using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models;
using TryCourier.Models.Users.Preferences;

namespace TryCourier.Tests.Models.Users.Preferences;

public class PreferenceBulkReplaceResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PreferenceBulkReplaceResponse
        {
            Deleted = ["string"],
            Items =
            [
                new()
                {
                    CustomRouting = [ChannelClassification.DirectMessage],
                    HasCustomRouting = true,
                    Status = BulkPreferenceTopicStatus.OptedIn,
                    TopicID = "topic_id",
                },
            ],
        };

        List<string> expectedDeleted = ["string"];
        List<BulkPreferenceTopic> expectedItems =
        [
            new()
            {
                CustomRouting = [ChannelClassification.DirectMessage],
                HasCustomRouting = true,
                Status = BulkPreferenceTopicStatus.OptedIn,
                TopicID = "topic_id",
            },
        ];

        Assert.Equal(expectedDeleted.Count, model.Deleted.Count);
        for (int i = 0; i < expectedDeleted.Count; i++)
        {
            Assert.Equal(expectedDeleted[i], model.Deleted[i]);
        }
        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PreferenceBulkReplaceResponse
        {
            Deleted = ["string"],
            Items =
            [
                new()
                {
                    CustomRouting = [ChannelClassification.DirectMessage],
                    HasCustomRouting = true,
                    Status = BulkPreferenceTopicStatus.OptedIn,
                    TopicID = "topic_id",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreferenceBulkReplaceResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PreferenceBulkReplaceResponse
        {
            Deleted = ["string"],
            Items =
            [
                new()
                {
                    CustomRouting = [ChannelClassification.DirectMessage],
                    HasCustomRouting = true,
                    Status = BulkPreferenceTopicStatus.OptedIn,
                    TopicID = "topic_id",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreferenceBulkReplaceResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedDeleted = ["string"];
        List<BulkPreferenceTopic> expectedItems =
        [
            new()
            {
                CustomRouting = [ChannelClassification.DirectMessage],
                HasCustomRouting = true,
                Status = BulkPreferenceTopicStatus.OptedIn,
                TopicID = "topic_id",
            },
        ];

        Assert.Equal(expectedDeleted.Count, deserialized.Deleted.Count);
        for (int i = 0; i < expectedDeleted.Count; i++)
        {
            Assert.Equal(expectedDeleted[i], deserialized.Deleted[i]);
        }
        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PreferenceBulkReplaceResponse
        {
            Deleted = ["string"],
            Items =
            [
                new()
                {
                    CustomRouting = [ChannelClassification.DirectMessage],
                    HasCustomRouting = true,
                    Status = BulkPreferenceTopicStatus.OptedIn,
                    TopicID = "topic_id",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PreferenceBulkReplaceResponse
        {
            Deleted = ["string"],
            Items =
            [
                new()
                {
                    CustomRouting = [ChannelClassification.DirectMessage],
                    HasCustomRouting = true,
                    Status = BulkPreferenceTopicStatus.OptedIn,
                    TopicID = "topic_id",
                },
            ],
        };

        PreferenceBulkReplaceResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
