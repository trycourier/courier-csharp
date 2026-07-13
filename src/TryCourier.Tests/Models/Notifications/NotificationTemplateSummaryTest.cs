using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Notifications;

namespace TryCourier.Tests.Models.Notifications;

public class NotificationTemplateSummaryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NotificationTemplateSummary
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            Name = "name",
            State = NotificationTemplateSummaryState.Draft,
            Tags = ["string"],
            SubscriptionTopicID = "subscription_topic_id",
            Updated = 0,
            Updater = "updater",
        };

        string expectedID = "id";
        long expectedCreated = 0;
        string expectedCreator = "creator";
        string expectedName = "name";
        ApiEnum<string, NotificationTemplateSummaryState> expectedState =
            NotificationTemplateSummaryState.Draft;
        List<string> expectedTags = ["string"];
        string expectedSubscriptionTopicID = "subscription_topic_id";
        long expectedUpdated = 0;
        string expectedUpdater = "updater";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreated, model.Created);
        Assert.Equal(expectedCreator, model.Creator);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
        Assert.Equal(expectedSubscriptionTopicID, model.SubscriptionTopicID);
        Assert.Equal(expectedUpdated, model.Updated);
        Assert.Equal(expectedUpdater, model.Updater);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NotificationTemplateSummary
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            Name = "name",
            State = NotificationTemplateSummaryState.Draft,
            Tags = ["string"],
            SubscriptionTopicID = "subscription_topic_id",
            Updated = 0,
            Updater = "updater",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotificationTemplateSummary>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NotificationTemplateSummary
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            Name = "name",
            State = NotificationTemplateSummaryState.Draft,
            Tags = ["string"],
            SubscriptionTopicID = "subscription_topic_id",
            Updated = 0,
            Updater = "updater",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotificationTemplateSummary>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        long expectedCreated = 0;
        string expectedCreator = "creator";
        string expectedName = "name";
        ApiEnum<string, NotificationTemplateSummaryState> expectedState =
            NotificationTemplateSummaryState.Draft;
        List<string> expectedTags = ["string"];
        string expectedSubscriptionTopicID = "subscription_topic_id";
        long expectedUpdated = 0;
        string expectedUpdater = "updater";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreated, deserialized.Created);
        Assert.Equal(expectedCreator, deserialized.Creator);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
        Assert.Equal(expectedSubscriptionTopicID, deserialized.SubscriptionTopicID);
        Assert.Equal(expectedUpdated, deserialized.Updated);
        Assert.Equal(expectedUpdater, deserialized.Updater);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NotificationTemplateSummary
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            Name = "name",
            State = NotificationTemplateSummaryState.Draft,
            Tags = ["string"],
            SubscriptionTopicID = "subscription_topic_id",
            Updated = 0,
            Updater = "updater",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NotificationTemplateSummary
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            Name = "name",
            State = NotificationTemplateSummaryState.Draft,
            Tags = ["string"],
        };

        Assert.Null(model.SubscriptionTopicID);
        Assert.False(model.RawData.ContainsKey("subscription_topic_id"));
        Assert.Null(model.Updated);
        Assert.False(model.RawData.ContainsKey("updated"));
        Assert.Null(model.Updater);
        Assert.False(model.RawData.ContainsKey("updater"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new NotificationTemplateSummary
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            Name = "name",
            State = NotificationTemplateSummaryState.Draft,
            Tags = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new NotificationTemplateSummary
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            Name = "name",
            State = NotificationTemplateSummaryState.Draft,
            Tags = ["string"],

            // Null should be interpreted as omitted for these properties
            SubscriptionTopicID = null,
            Updated = null,
            Updater = null,
        };

        Assert.Null(model.SubscriptionTopicID);
        Assert.False(model.RawData.ContainsKey("subscription_topic_id"));
        Assert.Null(model.Updated);
        Assert.False(model.RawData.ContainsKey("updated"));
        Assert.Null(model.Updater);
        Assert.False(model.RawData.ContainsKey("updater"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NotificationTemplateSummary
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            Name = "name",
            State = NotificationTemplateSummaryState.Draft,
            Tags = ["string"],

            // Null should be interpreted as omitted for these properties
            SubscriptionTopicID = null,
            Updated = null,
            Updater = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NotificationTemplateSummary
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            Name = "name",
            State = NotificationTemplateSummaryState.Draft,
            Tags = ["string"],
            SubscriptionTopicID = "subscription_topic_id",
            Updated = 0,
            Updater = "updater",
        };

        NotificationTemplateSummary copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NotificationTemplateSummaryStateTest : TestBase
{
    [Theory]
    [InlineData(NotificationTemplateSummaryState.Draft)]
    [InlineData(NotificationTemplateSummaryState.Published)]
    public void Validation_Works(NotificationTemplateSummaryState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NotificationTemplateSummaryState> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NotificationTemplateSummaryState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NotificationTemplateSummaryState.Draft)]
    [InlineData(NotificationTemplateSummaryState.Published)]
    public void SerializationRoundtrip_Works(NotificationTemplateSummaryState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NotificationTemplateSummaryState> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NotificationTemplateSummaryState>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NotificationTemplateSummaryState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NotificationTemplateSummaryState>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
