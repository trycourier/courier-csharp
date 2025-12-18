using System.Collections.Generic;
using System.Text.Json;
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
                    EventIDs = ["string"],
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
                EventIDs = ["string"],
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
                    EventIDs = ["string"],
                    Note = "note",
                    Routing = new() { Channels = ["string"], Method = Method.All },
                    TopicID = "topic_id",
                    UpdatedAt = 0,
                    Tags = new([new() { ID = "id", Name = "name" }]),
                    Title = "title",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NotificationListResponse>(json);

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
                    EventIDs = ["string"],
                    Note = "note",
                    Routing = new() { Channels = ["string"], Method = Method.All },
                    TopicID = "topic_id",
                    UpdatedAt = 0,
                    Tags = new([new() { ID = "id", Name = "name" }]),
                    Title = "title",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NotificationListResponse>(element);
        Assert.NotNull(deserialized);

        Paging expectedPaging = new() { More = true, Cursor = "cursor" };
        List<Result> expectedResults =
        [
            new()
            {
                ID = "id",
                CreatedAt = 0,
                EventIDs = ["string"],
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
                    EventIDs = ["string"],
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
            EventIDs = ["string"],
            Note = "note",
            Routing = new() { Channels = ["string"], Method = Method.All },
            TopicID = "topic_id",
            UpdatedAt = 0,
            Tags = new([new() { ID = "id", Name = "name" }]),
            Title = "title",
        };

        string expectedID = "id";
        long expectedCreatedAt = 0;
        List<string> expectedEventIDs = ["string"];
        string expectedNote = "note";
        MessageRouting expectedRouting = new() { Channels = ["string"], Method = Method.All };
        string expectedTopicID = "topic_id";
        long expectedUpdatedAt = 0;
        Tags expectedTags = new([new() { ID = "id", Name = "name" }]);
        string expectedTitle = "title";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEventIDs.Count, model.EventIDs.Count);
        for (int i = 0; i < expectedEventIDs.Count; i++)
        {
            Assert.Equal(expectedEventIDs[i], model.EventIDs[i]);
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
            EventIDs = ["string"],
            Note = "note",
            Routing = new() { Channels = ["string"], Method = Method.All },
            TopicID = "topic_id",
            UpdatedAt = 0,
            Tags = new([new() { ID = "id", Name = "name" }]),
            Title = "title",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Result>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Result
        {
            ID = "id",
            CreatedAt = 0,
            EventIDs = ["string"],
            Note = "note",
            Routing = new() { Channels = ["string"], Method = Method.All },
            TopicID = "topic_id",
            UpdatedAt = 0,
            Tags = new([new() { ID = "id", Name = "name" }]),
            Title = "title",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Result>(element);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        long expectedCreatedAt = 0;
        List<string> expectedEventIDs = ["string"];
        string expectedNote = "note";
        MessageRouting expectedRouting = new() { Channels = ["string"], Method = Method.All };
        string expectedTopicID = "topic_id";
        long expectedUpdatedAt = 0;
        Tags expectedTags = new([new() { ID = "id", Name = "name" }]);
        string expectedTitle = "title";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEventIDs.Count, deserialized.EventIDs.Count);
        for (int i = 0; i < expectedEventIDs.Count; i++)
        {
            Assert.Equal(expectedEventIDs[i], deserialized.EventIDs[i]);
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
            EventIDs = ["string"],
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
            EventIDs = ["string"],
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
            EventIDs = ["string"],
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
            EventIDs = ["string"],
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
            EventIDs = ["string"],
            Note = "note",
            Routing = new() { Channels = ["string"], Method = Method.All },
            TopicID = "topic_id",
            UpdatedAt = 0,

            Tags = null,
            Title = null,
        };

        model.Validate();
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Tags>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Tags { Data = [new() { ID = "id", Name = "name" }] };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Tags>(element);
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Data>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Data { ID = "id", Name = "name" };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Data>(element);
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
}
