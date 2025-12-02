using System.Collections.Generic;
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
                    Clicked = 0,
                    Delivered = 0,
                    Enqueued = 0,
                    Event = "event",
                    Notification = "notification",
                    Opened = 0,
                    Recipient = "recipient",
                    Sent = 0,
                    Status = Status.Canceled,
                    Error = "error",
                    Reason = Reason.Bounced,
                },
            ],
        };

        Paging expectedPaging = new() { More = true, Cursor = "cursor" };
        List<MessageDetails> expectedResults =
        [
            new()
            {
                ID = "id",
                Clicked = 0,
                Delivered = 0,
                Enqueued = 0,
                Event = "event",
                Notification = "notification",
                Opened = 0,
                Recipient = "recipient",
                Sent = 0,
                Status = Status.Canceled,
                Error = "error",
                Reason = Reason.Bounced,
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
