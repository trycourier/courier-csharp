using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models;
using TryCourier.Models.Users.Preferences;

namespace TryCourier.Tests.Models.Users.Preferences;

public class BulkPreferenceTopicTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BulkPreferenceTopic
        {
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
            Status = BulkPreferenceTopicStatus.OptedIn,
            TopicID = "topic_id",
        };

        List<ApiEnum<string, ChannelClassification>> expectedCustomRouting =
        [
            ChannelClassification.DirectMessage,
        ];
        bool expectedHasCustomRouting = true;
        ApiEnum<string, BulkPreferenceTopicStatus> expectedStatus =
            BulkPreferenceTopicStatus.OptedIn;
        string expectedTopicID = "topic_id";

        Assert.Equal(expectedCustomRouting.Count, model.CustomRouting.Count);
        for (int i = 0; i < expectedCustomRouting.Count; i++)
        {
            Assert.Equal(expectedCustomRouting[i], model.CustomRouting[i]);
        }
        Assert.Equal(expectedHasCustomRouting, model.HasCustomRouting);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTopicID, model.TopicID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BulkPreferenceTopic
        {
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
            Status = BulkPreferenceTopicStatus.OptedIn,
            TopicID = "topic_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BulkPreferenceTopic>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BulkPreferenceTopic
        {
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
            Status = BulkPreferenceTopicStatus.OptedIn,
            TopicID = "topic_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BulkPreferenceTopic>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ApiEnum<string, ChannelClassification>> expectedCustomRouting =
        [
            ChannelClassification.DirectMessage,
        ];
        bool expectedHasCustomRouting = true;
        ApiEnum<string, BulkPreferenceTopicStatus> expectedStatus =
            BulkPreferenceTopicStatus.OptedIn;
        string expectedTopicID = "topic_id";

        Assert.Equal(expectedCustomRouting.Count, deserialized.CustomRouting.Count);
        for (int i = 0; i < expectedCustomRouting.Count; i++)
        {
            Assert.Equal(expectedCustomRouting[i], deserialized.CustomRouting[i]);
        }
        Assert.Equal(expectedHasCustomRouting, deserialized.HasCustomRouting);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTopicID, deserialized.TopicID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BulkPreferenceTopic
        {
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
            Status = BulkPreferenceTopicStatus.OptedIn,
            TopicID = "topic_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BulkPreferenceTopic
        {
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
            Status = BulkPreferenceTopicStatus.OptedIn,
            TopicID = "topic_id",
        };

        BulkPreferenceTopic copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BulkPreferenceTopicStatusTest : TestBase
{
    [Theory]
    [InlineData(BulkPreferenceTopicStatus.OptedIn)]
    [InlineData(BulkPreferenceTopicStatus.OptedOut)]
    public void Validation_Works(BulkPreferenceTopicStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BulkPreferenceTopicStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BulkPreferenceTopicStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BulkPreferenceTopicStatus.OptedIn)]
    [InlineData(BulkPreferenceTopicStatus.OptedOut)]
    public void SerializationRoundtrip_Works(BulkPreferenceTopicStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BulkPreferenceTopicStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BulkPreferenceTopicStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BulkPreferenceTopicStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BulkPreferenceTopicStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
