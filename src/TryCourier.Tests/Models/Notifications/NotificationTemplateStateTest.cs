using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Notifications;

namespace TryCourier.Tests.Models.Notifications;

public class NotificationTemplateStateTest : TestBase
{
    [Theory]
    [InlineData(NotificationTemplateState.Draft)]
    [InlineData(NotificationTemplateState.Published)]
    public void Validation_Works(NotificationTemplateState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NotificationTemplateState> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NotificationTemplateState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NotificationTemplateState.Draft)]
    [InlineData(NotificationTemplateState.Published)]
    public void SerializationRoundtrip_Works(NotificationTemplateState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NotificationTemplateState> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NotificationTemplateState>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NotificationTemplateState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NotificationTemplateState>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
