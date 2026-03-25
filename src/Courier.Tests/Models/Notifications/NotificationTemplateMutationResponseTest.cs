using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Notifications;

namespace Courier.Tests.Models.Notifications;

public class NotificationTemplateMutationResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NotificationTemplateMutationResponse
        {
            Notification = new("id"),
            State = NotificationTemplateMutationResponseState.Draft,
        };

        NotificationTemplateMutationResponseNotification expectedNotification = new("id");
        ApiEnum<string, NotificationTemplateMutationResponseState> expectedState =
            NotificationTemplateMutationResponseState.Draft;

        Assert.Equal(expectedNotification, model.Notification);
        Assert.Equal(expectedState, model.State);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NotificationTemplateMutationResponse
        {
            Notification = new("id"),
            State = NotificationTemplateMutationResponseState.Draft,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotificationTemplateMutationResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NotificationTemplateMutationResponse
        {
            Notification = new("id"),
            State = NotificationTemplateMutationResponseState.Draft,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotificationTemplateMutationResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        NotificationTemplateMutationResponseNotification expectedNotification = new("id");
        ApiEnum<string, NotificationTemplateMutationResponseState> expectedState =
            NotificationTemplateMutationResponseState.Draft;

        Assert.Equal(expectedNotification, deserialized.Notification);
        Assert.Equal(expectedState, deserialized.State);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NotificationTemplateMutationResponse
        {
            Notification = new("id"),
            State = NotificationTemplateMutationResponseState.Draft,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NotificationTemplateMutationResponse
        {
            Notification = new("id"),
            State = NotificationTemplateMutationResponseState.Draft,
        };

        NotificationTemplateMutationResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NotificationTemplateMutationResponseNotificationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NotificationTemplateMutationResponseNotification { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NotificationTemplateMutationResponseNotification { ID = "id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<NotificationTemplateMutationResponseNotification>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NotificationTemplateMutationResponseNotification { ID = "id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<NotificationTemplateMutationResponseNotification>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "id";

        Assert.Equal(expectedID, deserialized.ID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NotificationTemplateMutationResponseNotification { ID = "id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NotificationTemplateMutationResponseNotification { ID = "id" };

        NotificationTemplateMutationResponseNotification copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NotificationTemplateMutationResponseStateTest : TestBase
{
    [Theory]
    [InlineData(NotificationTemplateMutationResponseState.Draft)]
    [InlineData(NotificationTemplateMutationResponseState.Published)]
    public void Validation_Works(NotificationTemplateMutationResponseState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NotificationTemplateMutationResponseState> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NotificationTemplateMutationResponseState>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NotificationTemplateMutationResponseState.Draft)]
    [InlineData(NotificationTemplateMutationResponseState.Published)]
    public void SerializationRoundtrip_Works(NotificationTemplateMutationResponseState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NotificationTemplateMutationResponseState> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NotificationTemplateMutationResponseState>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NotificationTemplateMutationResponseState>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NotificationTemplateMutationResponseState>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
