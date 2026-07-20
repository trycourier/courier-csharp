using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models;
using TryCourier.Models.Notifications;

namespace TryCourier.Tests.Models.Notifications;

public class NotificationListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NotificationListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new Notification()
                {
                    ID = "id",
                    CreatedAt = 0,
                    EventIds = ["string"],
                    Routing = new() { Channels = ["string"], Method = Method.All },
                    TopicID = "topic_id",
                    UpdatedAt = 0,
                    Note = "note",
                    Tags = new([new() { ID = "id", Name = "name" }]),
                    Title = "title",
                },
            ],
        };

        Paging expectedPaging = new() { More = true, Cursor = "cursor" };
        List<Result> expectedResults =
        [
            new Notification()
            {
                ID = "id",
                CreatedAt = 0,
                EventIds = ["string"],
                Routing = new() { Channels = ["string"], Method = Method.All },
                TopicID = "topic_id",
                UpdatedAt = 0,
                Note = "note",
                Tags = new([new() { ID = "id", Name = "name" }]),
                Title = "title",
            },
        ];

        Assert.Equal(expectedPaging, model.Paging);
        Assert.Equal(expectedResults.Count, model.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], model.Results[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NotificationListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new Notification()
                {
                    ID = "id",
                    CreatedAt = 0,
                    EventIds = ["string"],
                    Routing = new() { Channels = ["string"], Method = Method.All },
                    TopicID = "topic_id",
                    UpdatedAt = 0,
                    Note = "note",
                    Tags = new([new() { ID = "id", Name = "name" }]),
                    Title = "title",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotificationListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NotificationListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new Notification()
                {
                    ID = "id",
                    CreatedAt = 0,
                    EventIds = ["string"],
                    Routing = new() { Channels = ["string"], Method = Method.All },
                    TopicID = "topic_id",
                    UpdatedAt = 0,
                    Note = "note",
                    Tags = new([new() { ID = "id", Name = "name" }]),
                    Title = "title",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotificationListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Paging expectedPaging = new() { More = true, Cursor = "cursor" };
        List<Result> expectedResults =
        [
            new Notification()
            {
                ID = "id",
                CreatedAt = 0,
                EventIds = ["string"],
                Routing = new() { Channels = ["string"], Method = Method.All },
                TopicID = "topic_id",
                UpdatedAt = 0,
                Note = "note",
                Tags = new([new() { ID = "id", Name = "name" }]),
                Title = "title",
            },
        ];

        Assert.Equal(expectedPaging, deserialized.Paging);
        Assert.Equal(expectedResults.Count, deserialized.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], deserialized.Results[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NotificationListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new Notification()
                {
                    ID = "id",
                    CreatedAt = 0,
                    EventIds = ["string"],
                    Routing = new() { Channels = ["string"], Method = Method.All },
                    TopicID = "topic_id",
                    UpdatedAt = 0,
                    Note = "note",
                    Tags = new([new() { ID = "id", Name = "name" }]),
                    Title = "title",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NotificationListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new Notification()
                {
                    ID = "id",
                    CreatedAt = 0,
                    EventIds = ["string"],
                    Routing = new() { Channels = ["string"], Method = Method.All },
                    TopicID = "topic_id",
                    UpdatedAt = 0,
                    Note = "note",
                    Tags = new([new() { ID = "id", Name = "name" }]),
                    Title = "title",
                },
            ],
        };

        NotificationListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResultTest : TestBase
{
    [Fact]
    public void NotificationValidationWorks()
    {
        Result value = new Notification()
        {
            ID = "id",
            CreatedAt = 0,
            EventIds = ["string"],
            Routing = new() { Channels = ["string"], Method = Method.All },
            TopicID = "topic_id",
            UpdatedAt = 0,
            Note = "note",
            Tags = new([new() { ID = "id", Name = "name" }]),
            Title = "title",
        };
        value.Validate();
    }

    [Fact]
    public void NotificationTemplateSummaryValidationWorks()
    {
        Result value = new NotificationTemplateSummary()
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            Name = "name",
            State = NotificationTemplateSummaryState.Draft,
            Tags = ["string"],
            SubscriptionTopicID = "subscription_topic_id",
            TopicID = "topic_id",
            Updated = 0,
            Updater = "updater",
        };
        value.Validate();
    }

    [Fact]
    public void NotificationSerializationRoundtripWorks()
    {
        Result value = new Notification()
        {
            ID = "id",
            CreatedAt = 0,
            EventIds = ["string"],
            Routing = new() { Channels = ["string"], Method = Method.All },
            TopicID = "topic_id",
            UpdatedAt = 0,
            Note = "note",
            Tags = new([new() { ID = "id", Name = "name" }]),
            Title = "title",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Result>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NotificationTemplateSummarySerializationRoundtripWorks()
    {
        Result value = new NotificationTemplateSummary()
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            Name = "name",
            State = NotificationTemplateSummaryState.Draft,
            Tags = ["string"],
            SubscriptionTopicID = "subscription_topic_id",
            TopicID = "topic_id",
            Updated = 0,
            Updater = "updater",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Result>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class NotificationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Notification
        {
            ID = "id",
            CreatedAt = 0,
            EventIds = ["string"],
            Routing = new() { Channels = ["string"], Method = Method.All },
            TopicID = "topic_id",
            UpdatedAt = 0,
            Note = "note",
            Tags = new([new() { ID = "id", Name = "name" }]),
            Title = "title",
        };

        string expectedID = "id";
        long expectedCreatedAt = 0;
        List<string> expectedEventIds = ["string"];
        MessageRouting expectedRouting = new() { Channels = ["string"], Method = Method.All };
        string expectedTopicID = "topic_id";
        long expectedUpdatedAt = 0;
        string expectedNote = "note";
        Tags expectedTags = new([new() { ID = "id", Name = "name" }]);
        string expectedTitle = "title";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEventIds.Count, model.EventIds.Count);
        for (int i = 0; i < expectedEventIds.Count; i++)
        {
            Assert.Equal(expectedEventIds[i], model.EventIds[i]);
        }
        Assert.Equal(expectedRouting, model.Routing);
        Assert.Equal(expectedTopicID, model.TopicID);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedNote, model.Note);
        Assert.Equal(expectedTags, model.Tags);
        Assert.Equal(expectedTitle, model.Title);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Notification
        {
            ID = "id",
            CreatedAt = 0,
            EventIds = ["string"],
            Routing = new() { Channels = ["string"], Method = Method.All },
            TopicID = "topic_id",
            UpdatedAt = 0,
            Note = "note",
            Tags = new([new() { ID = "id", Name = "name" }]),
            Title = "title",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Notification>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Notification
        {
            ID = "id",
            CreatedAt = 0,
            EventIds = ["string"],
            Routing = new() { Channels = ["string"], Method = Method.All },
            TopicID = "topic_id",
            UpdatedAt = 0,
            Note = "note",
            Tags = new([new() { ID = "id", Name = "name" }]),
            Title = "title",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Notification>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        long expectedCreatedAt = 0;
        List<string> expectedEventIds = ["string"];
        MessageRouting expectedRouting = new() { Channels = ["string"], Method = Method.All };
        string expectedTopicID = "topic_id";
        long expectedUpdatedAt = 0;
        string expectedNote = "note";
        Tags expectedTags = new([new() { ID = "id", Name = "name" }]);
        string expectedTitle = "title";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEventIds.Count, deserialized.EventIds.Count);
        for (int i = 0; i < expectedEventIds.Count; i++)
        {
            Assert.Equal(expectedEventIds[i], deserialized.EventIds[i]);
        }
        Assert.Equal(expectedRouting, deserialized.Routing);
        Assert.Equal(expectedTopicID, deserialized.TopicID);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedNote, deserialized.Note);
        Assert.Equal(expectedTags, deserialized.Tags);
        Assert.Equal(expectedTitle, deserialized.Title);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Notification
        {
            ID = "id",
            CreatedAt = 0,
            EventIds = ["string"],
            Routing = new() { Channels = ["string"], Method = Method.All },
            TopicID = "topic_id",
            UpdatedAt = 0,
            Note = "note",
            Tags = new([new() { ID = "id", Name = "name" }]),
            Title = "title",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Notification
        {
            ID = "id",
            CreatedAt = 0,
            EventIds = ["string"],
            Routing = new() { Channels = ["string"], Method = Method.All },
            TopicID = "topic_id",
            UpdatedAt = 0,
            Tags = new([new() { ID = "id", Name = "name" }]),
            Title = "title",
        };

        Assert.Null(model.Note);
        Assert.False(model.RawData.ContainsKey("note"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Notification
        {
            ID = "id",
            CreatedAt = 0,
            EventIds = ["string"],
            Routing = new() { Channels = ["string"], Method = Method.All },
            TopicID = "topic_id",
            UpdatedAt = 0,
            Tags = new([new() { ID = "id", Name = "name" }]),
            Title = "title",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Notification
        {
            ID = "id",
            CreatedAt = 0,
            EventIds = ["string"],
            Routing = new() { Channels = ["string"], Method = Method.All },
            TopicID = "topic_id",
            UpdatedAt = 0,
            Tags = new([new() { ID = "id", Name = "name" }]),
            Title = "title",

            // Null should be interpreted as omitted for these properties
            Note = null,
        };

        Assert.Null(model.Note);
        Assert.False(model.RawData.ContainsKey("note"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Notification
        {
            ID = "id",
            CreatedAt = 0,
            EventIds = ["string"],
            Routing = new() { Channels = ["string"], Method = Method.All },
            TopicID = "topic_id",
            UpdatedAt = 0,
            Tags = new([new() { ID = "id", Name = "name" }]),
            Title = "title",

            // Null should be interpreted as omitted for these properties
            Note = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Notification
        {
            ID = "id",
            CreatedAt = 0,
            EventIds = ["string"],
            Routing = new() { Channels = ["string"], Method = Method.All },
            TopicID = "topic_id",
            UpdatedAt = 0,
            Note = "note",
        };

        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Notification
        {
            ID = "id",
            CreatedAt = 0,
            EventIds = ["string"],
            Routing = new() { Channels = ["string"], Method = Method.All },
            TopicID = "topic_id",
            UpdatedAt = 0,
            Note = "note",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Notification
        {
            ID = "id",
            CreatedAt = 0,
            EventIds = ["string"],
            Routing = new() { Channels = ["string"], Method = Method.All },
            TopicID = "topic_id",
            UpdatedAt = 0,
            Note = "note",

            Tags = null,
            Title = null,
        };

        Assert.Null(model.Tags);
        Assert.True(model.RawData.ContainsKey("tags"));
        Assert.Null(model.Title);
        Assert.True(model.RawData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Notification
        {
            ID = "id",
            CreatedAt = 0,
            EventIds = ["string"],
            Routing = new() { Channels = ["string"], Method = Method.All },
            TopicID = "topic_id",
            UpdatedAt = 0,
            Note = "note",

            Tags = null,
            Title = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Notification
        {
            ID = "id",
            CreatedAt = 0,
            EventIds = ["string"],
            Routing = new() { Channels = ["string"], Method = Method.All },
            TopicID = "topic_id",
            UpdatedAt = 0,
            Note = "note",
            Tags = new([new() { ID = "id", Name = "name" }]),
            Title = "title",
        };

        Notification copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TagsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Tags { Data = [new() { ID = "id", Name = "name" }] };

        List<Data> expectedData = [new() { ID = "id", Name = "name" }];

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Tags { Data = [new() { ID = "id", Name = "name" }] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tags>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Tags { Data = [new() { ID = "id", Name = "name" }] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tags>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<Data> expectedData = [new() { ID = "id", Name = "name" }];

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Tags { Data = [new() { ID = "id", Name = "name" }] };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Tags { Data = [new() { ID = "id", Name = "name" }] };

        Tags copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data { ID = "id", Name = "name" };

        string expectedID = "id";
        string expectedName = "name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data { ID = "id", Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Data { ID = "id", Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedName = "name";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data { ID = "id", Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data { ID = "id", Name = "name" };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}
