using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Notifications.Previews.Runs;

namespace TryCourier.Tests.Models.Notifications.Previews.Runs;

public class PreviewRunFailureReasonTest : TestBase
{
    [Theory]
    [InlineData(PreviewRunFailureReason.TemplateNotSupported)]
    [InlineData(PreviewRunFailureReason.NoEmailChannel)]
    [InlineData(PreviewRunFailureReason.RenderFailed)]
    [InlineData(PreviewRunFailureReason.AllDevicesUnsupported)]
    [InlineData(PreviewRunFailureReason.VendorError)]
    public void Validation_Works(PreviewRunFailureReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PreviewRunFailureReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PreviewRunFailureReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PreviewRunFailureReason.TemplateNotSupported)]
    [InlineData(PreviewRunFailureReason.NoEmailChannel)]
    [InlineData(PreviewRunFailureReason.RenderFailed)]
    [InlineData(PreviewRunFailureReason.AllDevicesUnsupported)]
    [InlineData(PreviewRunFailureReason.VendorError)]
    public void SerializationRoundtrip_Works(PreviewRunFailureReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PreviewRunFailureReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PreviewRunFailureReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PreviewRunFailureReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PreviewRunFailureReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
