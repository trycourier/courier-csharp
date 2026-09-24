using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Notifications.Previews.Runs;

namespace TryCourier.Tests.Models.Notifications.Previews.Runs;

public class PreviewResultFailureReasonTest : TestBase
{
    [Theory]
    [InlineData(PreviewResultFailureReason.DeliveryFailed)]
    public void Validation_Works(PreviewResultFailureReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PreviewResultFailureReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PreviewResultFailureReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PreviewResultFailureReason.DeliveryFailed)]
    public void SerializationRoundtrip_Works(PreviewResultFailureReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PreviewResultFailureReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PreviewResultFailureReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PreviewResultFailureReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PreviewResultFailureReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
