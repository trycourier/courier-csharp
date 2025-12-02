using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models.Messages;

namespace Courier.Tests.Models.Messages;

public class MessageRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageRetrieveResponse
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
            Providers =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
        };

        string expectedID = "id";
        long expectedClicked = 0;
        long expectedDelivered = 0;
        long expectedEnqueued = 0;
        string expectedEvent = "event";
        string expectedNotification = "notification";
        long expectedOpened = 0;
        string expectedRecipient = "recipient";
        long expectedSent = 0;
        ApiEnum<string, Status> expectedStatus = Status.Canceled;
        string expectedError = "error";
        ApiEnum<string, Reason> expectedReason = Reason.Bounced;
        List<Dictionary<string, JsonElement>> expectedProviders =
        [
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        ];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedClicked, model.Clicked);
        Assert.Equal(expectedDelivered, model.Delivered);
        Assert.Equal(expectedEnqueued, model.Enqueued);
        Assert.Equal(expectedEvent, model.Event);
        Assert.Equal(expectedNotification, model.Notification);
        Assert.Equal(expectedOpened, model.Opened);
        Assert.Equal(expectedRecipient, model.Recipient);
        Assert.Equal(expectedSent, model.Sent);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedProviders.Count, model.Providers.Count);
        for (int i = 0; i < expectedProviders.Count; i++)
        {
            Assert.Equal(expectedProviders[i].Count, model.Providers[i].Count);
            foreach (var item in expectedProviders[i])
            {
                Assert.True(model.Providers[i].TryGetValue(item.Key, out var value));

                Assert.True(JsonElement.DeepEquals(value, model.Providers[i][item.Key]));
            }
        }
    }
}

public class IntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntersectionMember1
        {
            Providers =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
        };

        List<Dictionary<string, JsonElement>> expectedProviders =
        [
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        ];

        Assert.Equal(expectedProviders.Count, model.Providers.Count);
        for (int i = 0; i < expectedProviders.Count; i++)
        {
            Assert.Equal(expectedProviders[i].Count, model.Providers[i].Count);
            foreach (var item in expectedProviders[i])
            {
                Assert.True(model.Providers[i].TryGetValue(item.Key, out var value));

                Assert.True(JsonElement.DeepEquals(value, model.Providers[i][item.Key]));
            }
        }
    }
}
