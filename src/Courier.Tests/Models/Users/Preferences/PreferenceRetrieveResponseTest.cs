using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models;
using Courier.Models.Users.Preferences;

namespace Courier.Tests.Models.Users.Preferences;

public class PreferenceRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PreferenceRetrieveResponse
        {
            Items =
            [
                new()
                {
                    DefaultStatus = PreferenceStatus.OptedIn,
                    Status = PreferenceStatus.OptedIn,
                    TopicID = "topic_id",
                    TopicName = "topic_name",
                    CustomRouting = [ChannelClassification.DirectMessage],
                    HasCustomRouting = true,
                },
            ],
            Paging = new() { More = true, Cursor = "cursor" },
        };

        List<TopicPreference> expectedItems =
        [
            new()
            {
                DefaultStatus = PreferenceStatus.OptedIn,
                Status = PreferenceStatus.OptedIn,
                TopicID = "topic_id",
                TopicName = "topic_name",
                CustomRouting = [ChannelClassification.DirectMessage],
                HasCustomRouting = true,
            },
        ];
        Paging expectedPaging = new() { More = true, Cursor = "cursor" };

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedPaging, model.Paging);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PreferenceRetrieveResponse
        {
            Items =
            [
                new()
                {
                    DefaultStatus = PreferenceStatus.OptedIn,
                    Status = PreferenceStatus.OptedIn,
                    TopicID = "topic_id",
                    TopicName = "topic_name",
                    CustomRouting = [ChannelClassification.DirectMessage],
                    HasCustomRouting = true,
                },
            ],
            Paging = new() { More = true, Cursor = "cursor" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreferenceRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PreferenceRetrieveResponse
        {
            Items =
            [
                new()
                {
                    DefaultStatus = PreferenceStatus.OptedIn,
                    Status = PreferenceStatus.OptedIn,
                    TopicID = "topic_id",
                    TopicName = "topic_name",
                    CustomRouting = [ChannelClassification.DirectMessage],
                    HasCustomRouting = true,
                },
            ],
            Paging = new() { More = true, Cursor = "cursor" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreferenceRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<TopicPreference> expectedItems =
        [
            new()
            {
                DefaultStatus = PreferenceStatus.OptedIn,
                Status = PreferenceStatus.OptedIn,
                TopicID = "topic_id",
                TopicName = "topic_name",
                CustomRouting = [ChannelClassification.DirectMessage],
                HasCustomRouting = true,
            },
        ];
        Paging expectedPaging = new() { More = true, Cursor = "cursor" };

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedPaging, deserialized.Paging);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PreferenceRetrieveResponse
        {
            Items =
            [
                new()
                {
                    DefaultStatus = PreferenceStatus.OptedIn,
                    Status = PreferenceStatus.OptedIn,
                    TopicID = "topic_id",
                    TopicName = "topic_name",
                    CustomRouting = [ChannelClassification.DirectMessage],
                    HasCustomRouting = true,
                },
            ],
            Paging = new() { More = true, Cursor = "cursor" },
        };

        model.Validate();
    }
}
