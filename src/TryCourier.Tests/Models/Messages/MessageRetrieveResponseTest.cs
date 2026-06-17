using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Messages;

namespace TryCourier.Tests.Models.Messages;

public class MessageRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageRetrieveResponse
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
            Providers =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
        };

        string expectedID = "id";
        long expectedEnqueued = 0;
        string expectedEvent = "event";
        string expectedNotification = "notification";
        string expectedRecipient = "recipient";
        ApiEnum<string, Status> expectedStatus = Status.Canceled;
        long expectedClicked = 0;
        long expectedDelivered = 0;
        string expectedError = "error";
        long expectedOpened = 0;
        ApiEnum<string, Reason> expectedReason = Reason.Bounced;
        long expectedSent = 0;
        List<Dictionary<string, JsonElement>> expectedProviders =
        [
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        ];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedEnqueued, model.Enqueued);
        Assert.Equal(expectedEvent, model.Event);
        Assert.Equal(expectedNotification, model.Notification);
        Assert.Equal(expectedRecipient, model.Recipient);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedClicked, model.Clicked);
        Assert.Equal(expectedDelivered, model.Delivered);
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedOpened, model.Opened);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedSent, model.Sent);
        Assert.NotNull(model.Providers);
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
            Providers =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MessageRetrieveResponse
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
            Providers =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        long expectedEnqueued = 0;
        string expectedEvent = "event";
        string expectedNotification = "notification";
        string expectedRecipient = "recipient";
        ApiEnum<string, Status> expectedStatus = Status.Canceled;
        long expectedClicked = 0;
        long expectedDelivered = 0;
        string expectedError = "error";
        long expectedOpened = 0;
        ApiEnum<string, Reason> expectedReason = Reason.Bounced;
        long expectedSent = 0;
        List<Dictionary<string, JsonElement>> expectedProviders =
        [
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        ];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedEnqueued, deserialized.Enqueued);
        Assert.Equal(expectedEvent, deserialized.Event);
        Assert.Equal(expectedNotification, deserialized.Notification);
        Assert.Equal(expectedRecipient, deserialized.Recipient);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedClicked, deserialized.Clicked);
        Assert.Equal(expectedDelivered, deserialized.Delivered);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedOpened, deserialized.Opened);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedSent, deserialized.Sent);
        Assert.NotNull(deserialized.Providers);
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
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MessageRetrieveResponse
        {
            ID = "id",
            Enqueued = 0,
            Event = "event",
            Notification = "notification",
            Recipient = "recipient",
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

        Assert.Null(model.Clicked);
        Assert.False(model.RawData.ContainsKey("clicked"));
        Assert.Null(model.Delivered);
        Assert.False(model.RawData.ContainsKey("delivered"));
        Assert.Null(model.Opened);
        Assert.False(model.RawData.ContainsKey("opened"));
        Assert.Null(model.Sent);
        Assert.False(model.RawData.ContainsKey("sent"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MessageRetrieveResponse
        {
            ID = "id",
            Enqueued = 0,
            Event = "event",
            Notification = "notification",
            Recipient = "recipient",
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
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MessageRetrieveResponse
        {
            ID = "id",
            Enqueued = 0,
            Event = "event",
            Notification = "notification",
            Recipient = "recipient",
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

            // Null should be interpreted as omitted for these properties
            Clicked = null,
            Delivered = null,
            Opened = null,
            Sent = null,
        };

        Assert.Null(model.Clicked);
        Assert.False(model.RawData.ContainsKey("clicked"));
        Assert.Null(model.Delivered);
        Assert.False(model.RawData.ContainsKey("delivered"));
        Assert.Null(model.Opened);
        Assert.False(model.RawData.ContainsKey("opened"));
        Assert.Null(model.Sent);
        Assert.False(model.RawData.ContainsKey("sent"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MessageRetrieveResponse
        {
            ID = "id",
            Enqueued = 0,
            Event = "event",
            Notification = "notification",
            Recipient = "recipient",
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

            // Null should be interpreted as omitted for these properties
            Clicked = null,
            Delivered = null,
            Opened = null,
            Sent = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MessageRetrieveResponse
        {
            ID = "id",
            Enqueued = 0,
            Event = "event",
            Notification = "notification",
            Recipient = "recipient",
            Status = Status.Canceled,
            Clicked = 0,
            Delivered = 0,
            Opened = 0,
            Sent = 0,
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
            Enqueued = 0,
            Event = "event",
            Notification = "notification",
            Recipient = "recipient",
            Status = Status.Canceled,
            Clicked = 0,
            Delivered = 0,
            Opened = 0,
            Sent = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new MessageRetrieveResponse
        {
            ID = "id",
            Enqueued = 0,
            Event = "event",
            Notification = "notification",
            Recipient = "recipient",
            Status = Status.Canceled,
            Clicked = 0,
            Delivered = 0,
            Opened = 0,
            Sent = 0,

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
            Enqueued = 0,
            Event = "event",
            Notification = "notification",
            Recipient = "recipient",
            Status = Status.Canceled,
            Clicked = 0,
            Delivered = 0,
            Opened = 0,
            Sent = 0,

            Error = null,
            Reason = null,
            Providers = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MessageRetrieveResponse
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
            Providers =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
        };

        MessageRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
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

        Assert.NotNull(model.Providers);
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntersectionMember1>(
            json,
            ModelBase.SerializerOptions
        );

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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntersectionMember1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Dictionary<string, JsonElement>> expectedProviders =
        [
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        ];

        Assert.NotNull(deserialized.Providers);
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

    [Fact]
    public void CopyConstructor_Works()
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

        IntersectionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}
