using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models;
using Courier.Models.Messages;

namespace Courier.Tests.Models.Messages;

public class MessageListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
                {
                    ID = "id",
                    Enqueued = 0,
                    Event = "event",
                    Notification = "notification",
                    Recipient = "recipient",
                    Status = Status.Canceled,
                    Clicked = 0,
                    Delivered = 0,
                    Error = "error",
                    Opened = 0,
                    Reason = Reason.Bounced,
                    Sent = 0,
                },
            ],
        };

        Paging expectedPaging = new() { More = true, Cursor = "cursor" };
        List<MessageDetails> expectedResults =
        [
            new()
            {
                ID = "id",
                Enqueued = 0,
                Event = "event",
                Notification = "notification",
                Recipient = "recipient",
                Status = Status.Canceled,
                Clicked = 0,
                Delivered = 0,
                Error = "error",
                Opened = 0,
                Reason = Reason.Bounced,
                Sent = 0,
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
        var model = new MessageListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
                {
                    ID = "id",
                    Enqueued = 0,
                    Event = "event",
                    Notification = "notification",
                    Recipient = "recipient",
                    Status = Status.Canceled,
                    Clicked = 0,
                    Delivered = 0,
                    Error = "error",
                    Opened = 0,
                    Reason = Reason.Bounced,
                    Sent = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MessageListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
                {
                    ID = "id",
                    Enqueued = 0,
                    Event = "event",
                    Notification = "notification",
                    Recipient = "recipient",
                    Status = Status.Canceled,
                    Clicked = 0,
                    Delivered = 0,
                    Error = "error",
                    Opened = 0,
                    Reason = Reason.Bounced,
                    Sent = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Paging expectedPaging = new() { More = true, Cursor = "cursor" };
        List<MessageDetails> expectedResults =
        [
            new()
            {
                ID = "id",
                Enqueued = 0,
                Event = "event",
                Notification = "notification",
                Recipient = "recipient",
                Status = Status.Canceled,
                Clicked = 0,
                Delivered = 0,
                Error = "error",
                Opened = 0,
                Reason = Reason.Bounced,
                Sent = 0,
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
        var model = new MessageListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
                {
                    ID = "id",
                    Enqueued = 0,
                    Event = "event",
                    Notification = "notification",
                    Recipient = "recipient",
                    Status = Status.Canceled,
                    Clicked = 0,
                    Delivered = 0,
                    Error = "error",
                    Opened = 0,
                    Reason = Reason.Bounced,
                    Sent = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MessageListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
                {
                    ID = "id",
                    Enqueued = 0,
                    Event = "event",
                    Notification = "notification",
                    Recipient = "recipient",
                    Status = Status.Canceled,
                    Clicked = 0,
                    Delivered = 0,
                    Error = "error",
                    Opened = 0,
                    Reason = Reason.Bounced,
                    Sent = 0,
                },
            ],
        };

        MessageListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
