using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models;
using TryCourier.Models.Users.Preferences;

namespace TryCourier.Tests.Models.Users.Preferences;

public class PreferenceBulkUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PreferenceBulkUpdateResponse
        {
            Errors = [new() { Reason = "reason", TopicID = "topic_id" }],
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

        List<Error> expectedErrors = [new() { Reason = "reason", TopicID = "topic_id" }];
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

        Assert.Equal(expectedErrors.Count, model.Errors.Count);
        for (int i = 0; i < expectedErrors.Count; i++)
        {
            Assert.Equal(expectedErrors[i], model.Errors[i]);
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
        var model = new PreferenceBulkUpdateResponse
        {
            Errors = [new() { Reason = "reason", TopicID = "topic_id" }],
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
        var deserialized = JsonSerializer.Deserialize<PreferenceBulkUpdateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PreferenceBulkUpdateResponse
        {
            Errors = [new() { Reason = "reason", TopicID = "topic_id" }],
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
        var deserialized = JsonSerializer.Deserialize<PreferenceBulkUpdateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Error> expectedErrors = [new() { Reason = "reason", TopicID = "topic_id" }];
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

        Assert.Equal(expectedErrors.Count, deserialized.Errors.Count);
        for (int i = 0; i < expectedErrors.Count; i++)
        {
            Assert.Equal(expectedErrors[i], deserialized.Errors[i]);
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
        var model = new PreferenceBulkUpdateResponse
        {
            Errors = [new() { Reason = "reason", TopicID = "topic_id" }],
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
        var model = new PreferenceBulkUpdateResponse
        {
            Errors = [new() { Reason = "reason", TopicID = "topic_id" }],
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

        PreferenceBulkUpdateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Error { Reason = "reason", TopicID = "topic_id" };

        string expectedReason = "reason";
        string expectedTopicID = "topic_id";

        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedTopicID, model.TopicID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Error { Reason = "reason", TopicID = "topic_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Error { Reason = "reason", TopicID = "topic_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedReason = "reason";
        string expectedTopicID = "topic_id";

        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedTopicID, deserialized.TopicID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Error { Reason = "reason", TopicID = "topic_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Error { Reason = "reason", TopicID = "topic_id" };

        Error copied = new(model);

        Assert.Equal(model, copied);
    }
}
