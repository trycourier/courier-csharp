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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MessageRetrieveResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MessageRetrieveResponse>(json);
        Assert.NotNull(deserialized);

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

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedClicked, deserialized.Clicked);
        Assert.Equal(expectedDelivered, deserialized.Delivered);
        Assert.Equal(expectedEnqueued, deserialized.Enqueued);
        Assert.Equal(expectedEvent, deserialized.Event);
        Assert.Equal(expectedNotification, deserialized.Notification);
        Assert.Equal(expectedOpened, deserialized.Opened);
        Assert.Equal(expectedRecipient, deserialized.Recipient);
        Assert.Equal(expectedSent, deserialized.Sent);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedProviders.Count, deserialized.Providers.Count);
        for (int i = 0; i < expectedProviders.Count; i++)
        {
            Assert.Equal(expectedProviders[i].Count, deserialized.Providers[i].Count);
            foreach (var item in expectedProviders[i])
            {
                Assert.True(deserialized.Providers[i].TryGetValue(item.Key, out var value));

                Assert.True(JsonElement.DeepEquals(value, deserialized.Providers[i][item.Key]));
            }
        }
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
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
        };

        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
        Assert.Null(model.Providers);
        Assert.False(model.RawData.ContainsKey("providers"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
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

            Error = null,
            Reason = null,
            Providers = null,
        };

        Assert.Null(model.Error);
        Assert.True(model.RawData.ContainsKey("error"));
        Assert.Null(model.Reason);
        Assert.True(model.RawData.ContainsKey("reason"));
        Assert.Null(model.Providers);
        Assert.True(model.RawData.ContainsKey("providers"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
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

            Error = null,
            Reason = null,
            Providers = null,
        };

        model.Validate();
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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<IntersectionMember1>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<IntersectionMember1>(json);
        Assert.NotNull(deserialized);

        List<Dictionary<string, JsonElement>> expectedProviders =
        [
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        ];

        Assert.Equal(expectedProviders.Count, deserialized.Providers.Count);
        for (int i = 0; i < expectedProviders.Count; i++)
        {
            Assert.Equal(expectedProviders[i].Count, deserialized.Providers[i].Count);
            foreach (var item in expectedProviders[i])
            {
                Assert.True(deserialized.Providers[i].TryGetValue(item.Key, out var value));

                Assert.True(JsonElement.DeepEquals(value, deserialized.Providers[i][item.Key]));
            }
        }
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new IntersectionMember1 { };

        Assert.Null(model.Providers);
        Assert.False(model.RawData.ContainsKey("providers"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new IntersectionMember1 { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new IntersectionMember1 { Providers = null };

        Assert.Null(model.Providers);
        Assert.True(model.RawData.ContainsKey("providers"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new IntersectionMember1 { Providers = null };

        model.Validate();
    }
}
