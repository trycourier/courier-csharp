using System.Collections.Generic;
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
            Note = "note",
            Routing = new() { Channels = ["string"], Method = Method.All },
            TopicID = "topic_id",
            UpdatedAt = 0,
            Tags = new([new() { ID = "id", Name = "name" }]),
            Title = "title",
        };

        string expectedID = "id";
        long expectedCreatedAt = 0;
        string expectedNote = "note";
        MessageRouting expectedRouting = new() { Channels = ["string"], Method = Method.All };
        string expectedTopicID = "topic_id";
        long expectedUpdatedAt = 0;
        Tags expectedTags = new([new() { ID = "id", Name = "name" }]);
        string expectedTitle = "title";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedNote, model.Note);
        Assert.Equal(expectedRouting, model.Routing);
        Assert.Equal(expectedTopicID, model.TopicID);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedTags, model.Tags);
        Assert.Equal(expectedTitle, model.Title);
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
}
