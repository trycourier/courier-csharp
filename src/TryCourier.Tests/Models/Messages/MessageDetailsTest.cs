using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Messages;

namespace TryCourier.Tests.Models.Messages;

public class MessageDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageDetails
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
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MessageDetails
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MessageDetails
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageDetails>(
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
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MessageDetails
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MessageDetails
        {
            ID = "id",
            Enqueued = 0,
            Event = "event",
            Notification = "notification",
            Recipient = "recipient",
            Status = Status.Canceled,
            Error = "error",
            Reason = Reason.Bounced,
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
        var model = new MessageDetails
        {
            ID = "id",
            Enqueued = 0,
            Event = "event",
            Notification = "notification",
            Recipient = "recipient",
            Status = Status.Canceled,
            Error = "error",
            Reason = Reason.Bounced,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MessageDetails
        {
            ID = "id",
            Enqueued = 0,
            Event = "event",
            Notification = "notification",
            Recipient = "recipient",
            Status = Status.Canceled,
            Error = "error",
            Reason = Reason.Bounced,

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
        var model = new MessageDetails
        {
            ID = "id",
            Enqueued = 0,
            Event = "event",
            Notification = "notification",
            Recipient = "recipient",
            Status = Status.Canceled,
            Error = "error",
            Reason = Reason.Bounced,

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
        var model = new MessageDetails
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
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new MessageDetails
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
        var model = new MessageDetails
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
        };

        Assert.Null(model.Error);
        Assert.True(model.RawData.ContainsKey("error"));
        Assert.Null(model.Reason);
        Assert.True(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MessageDetails
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MessageDetails
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
        };

        MessageDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Canceled)]
    [InlineData(Status.Clicked)]
    [InlineData(Status.Delayed)]
    [InlineData(Status.Delivered)]
    [InlineData(Status.Digested)]
    [InlineData(Status.Enqueued)]
    [InlineData(Status.Filtered)]
    [InlineData(Status.Opened)]
    [InlineData(Status.Routed)]
    [InlineData(Status.Sent)]
    [InlineData(Status.Simulated)]
    [InlineData(Status.Throttled)]
    [InlineData(Status.Undeliverable)]
    [InlineData(Status.Unmapped)]
    [InlineData(Status.Unroutable)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Canceled)]
    [InlineData(Status.Clicked)]
    [InlineData(Status.Delayed)]
    [InlineData(Status.Delivered)]
    [InlineData(Status.Digested)]
    [InlineData(Status.Enqueued)]
    [InlineData(Status.Filtered)]
    [InlineData(Status.Opened)]
    [InlineData(Status.Routed)]
    [InlineData(Status.Sent)]
    [InlineData(Status.Simulated)]
    [InlineData(Status.Throttled)]
    [InlineData(Status.Undeliverable)]
    [InlineData(Status.Unmapped)]
    [InlineData(Status.Unroutable)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ReasonTest : TestBase
{
    [Theory]
    [InlineData(Reason.Bounced)]
    [InlineData(Reason.Failed)]
    [InlineData(Reason.Filtered)]
    [InlineData(Reason.NoChannels)]
    [InlineData(Reason.NoProviders)]
    [InlineData(Reason.OptInRequired)]
    [InlineData(Reason.ProviderError)]
    [InlineData(Reason.Unpublished)]
    [InlineData(Reason.Unsubscribed)]
    public void Validation_Works(Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Reason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Reason.Bounced)]
    [InlineData(Reason.Failed)]
    [InlineData(Reason.Filtered)]
    [InlineData(Reason.NoChannels)]
    [InlineData(Reason.NoProviders)]
    [InlineData(Reason.OptInRequired)]
    [InlineData(Reason.ProviderError)]
    [InlineData(Reason.Unpublished)]
    [InlineData(Reason.Unsubscribed)]
    public void SerializationRoundtrip_Works(Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Reason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
