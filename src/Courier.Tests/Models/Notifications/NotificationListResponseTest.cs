using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models;
using Courier.Models.Notifications;

namespace Courier.Tests.Models.Notifications;

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
                new()
                {
                    ID = "id",
                    CreatedAt = 0,
                    EventIds = ["string"],
                    Note = "note",
                    Routing = new() { Channels = ["string"], Method = Method.All },
                    TopicID = "topic_id",
                    UpdatedAt = 0,
                    Tags = new([new() { ID = "id", Name = "name" }]),
                    Title = "title",
                },
            ],
        };

        Paging expectedPaging = new() { More = true, Cursor = "cursor" };
        List<Result> expectedResults =
        [
            new()
            {
                ID = "id",
                CreatedAt = 0,
                EventIds = ["string"],
                Note = "note",
                Routing = new() { Channels = ["string"], Method = Method.All },
                TopicID = "topic_id",
                UpdatedAt = 0,
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
                new()
                {
                    ID = "id",
                    CreatedAt = 0,
                    EventIds = ["string"],
                    Note = "note",
                    Routing = new() { Channels = ["string"], Method = Method.All },
                    TopicID = "topic_id",
                    UpdatedAt = 0,
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
                new()
                {
                    ID = "id",
                    CreatedAt = 0,
                    EventIds = ["string"],
                    Note = "note",
                    Routing = new() { Channels = ["string"], Method = Method.All },
                    TopicID = "topic_id",
                    UpdatedAt = 0,
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
            new()
            {
                ID = "id",
                CreatedAt = 0,
                EventIds = ["string"],
                Note = "note",
                Routing = new() { Channels = ["string"], Method = Method.All },
                TopicID = "topic_id",
                UpdatedAt = 0,
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
                new()
                {
                    ID = "id",
                    CreatedAt = 0,
                    EventIds = ["string"],
                    Note = "note",
                    Routing = new() { Channels = ["string"], Method = Method.All },
                    TopicID = "topic_id",
                    UpdatedAt = 0,
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
                new()
                {
                    ID = "id",
                    CreatedAt = 0,
                    EventIds = ["string"],
                    Note = "note",
                    Routing = new() { Channels = ["string"], Method = Method.All },
                    TopicID = "topic_id",
                    UpdatedAt = 0,
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
    public void FieldRoundtrip_Works()
    {
        var model = new Result
        {
            ID = "id",
            CreatedAt = 0,
            EventIds = ["string"],
            Note = "note",
            Routing = new() { Channels = ["string"], Method = Method.All },
            TopicID = "topic_id",
            UpdatedAt = 0,
            Tags = new([new() { ID = "id", Name = "name" }]),
            Title = "title",
        };

        string expectedID = "id";
        long expectedCreatedAt = 0;
        List<string> expectedEventIds = ["string"];
        string expectedNote = "note";
        MessageRouting expectedRouting = new() { Channels = ["string"], Method = Method.All };
        string expectedTopicID = "topic_id";
        long expectedUpdatedAt = 0;
        Tags expectedTags = new([new() { ID = "id", Name = "name" }]);
        string expectedTitle = "title";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEventIds.Count, model.EventIds.Count);
        for (int i = 0; i < expectedEventIds.Count; i++)
        {
            Assert.Equal(expectedEventIds[i], model.EventIds[i]);
        }
        Assert.Equal(expectedNote, model.Note);
        Assert.Equal(expectedRouting, model.Routing);
        Assert.Equal(expectedTopicID, model.TopicID);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedTags, model.Tags);
        Assert.Equal(expectedTitle, model.Title);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Result
        {
            ID = "id",
            CreatedAt = 0,
            EventIds = ["string"],
            Note = "note",
            Routing = new() { Channels = ["string"], Method = Method.All },
            TopicID = "topic_id",
            UpdatedAt = 0,
            Tags = new([new() { ID = "id", Name = "name" }]),
            Title = "title",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Result>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Result
        {
            ID = "id",
            CreatedAt = 0,
            EventIds = ["string"],
            Note = "note",
            Routing = new() { Channels = ["string"], Method = Method.All },
            TopicID = "topic_id",
            UpdatedAt = 0,
            Tags = new([new() { ID = "id", Name = "name" }]),
            Title = "title",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Result>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        long expectedCreatedAt = 0;
        List<string> expectedEventIds = ["string"];
        string expectedNote = "note";
        MessageRouting expectedRouting = new() { Channels = ["string"], Method = Method.All };
        string expectedTopicID = "topic_id";
        long expectedUpdatedAt = 0;
        Tags expectedTags = new([new() { ID = "id", Name = "name" }]);
        string expectedTitle = "title";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEventIds.Count, deserialized.EventIds.Count);
        for (int i = 0; i < expectedEventIds.Count; i++)
        {
            Assert.Equal(expectedEventIds[i], deserialized.EventIds[i]);
        }
        Assert.Equal(expectedNote, deserialized.Note);
        Assert.Equal(expectedRouting, deserialized.Routing);
        Assert.Equal(expectedTopicID, deserialized.TopicID);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedTags, deserialized.Tags);
        Assert.Equal(expectedTitle, deserialized.Title);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Result
        {
            ID = "id",
            CreatedAt = 0,
            EventIds = ["string"],
            Note = "note",
            Routing = new() { Channels = ["string"], Method = Method.All },
            TopicID = "topic_id",
            UpdatedAt = 0,
            Tags = new([new() { ID = "id", Name = "name" }]),
            Title = "title",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Result
        {
            ID = "id",
            CreatedAt = 0,
            EventIds = ["string"],
            Note = "note",
            Routing = new() { Channels = ["string"], Method = Method.All },
            TopicID = "topic_id",
            UpdatedAt = 0,
        };

        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Result
        {
            ID = "id",
            CreatedAt = 0,
            EventIds = ["string"],
            Note = "note",
            Routing = new() { Channels = ["string"], Method = Method.All },
            TopicID = "topic_id",
            UpdatedAt = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Result
        {
            ID = "id",
            CreatedAt = 0,
            EventIds = ["string"],
            Note = "note",
            Routing = new() { Channels = ["string"], Method = Method.All },
            TopicID = "topic_id",
            UpdatedAt = 0,

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
        var model = new Result
        {
            ID = "id",
            CreatedAt = 0,
            EventIds = ["string"],
            Note = "note",
            Routing = new() { Channels = ["string"], Method = Method.All },
            TopicID = "topic_id",
            UpdatedAt = 0,

            Tags = null,
            Title = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Result
        {
            ID = "id",
            CreatedAt = 0,
            EventIds = ["string"],
            Note = "note",
            Routing = new() { Channels = ["string"], Method = Method.All },
            TopicID = "topic_id",
            UpdatedAt = 0,
            Tags = new([new() { ID = "id", Name = "name" }]),
            Title = "title",
        };

        Result copied = new(model);

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
