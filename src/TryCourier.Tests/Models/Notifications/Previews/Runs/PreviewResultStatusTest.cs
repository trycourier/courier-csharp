using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Notifications.Previews.Runs;

namespace TryCourier.Tests.Models.Notifications.Previews.Runs;

public class PreviewResultStatusTest : TestBase
{
    [Theory]
    [InlineData(PreviewResultStatus.Pending)]
    [InlineData(PreviewResultStatus.Processing)]
    [InlineData(PreviewResultStatus.Completed)]
    [InlineData(PreviewResultStatus.Unsupported)]
    [InlineData(PreviewResultStatus.TimedOut)]
    [InlineData(PreviewResultStatus.Failed)]
    public void Validation_Works(PreviewResultStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PreviewResultStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PreviewResultStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PreviewResultStatus.Pending)]
    [InlineData(PreviewResultStatus.Processing)]
    [InlineData(PreviewResultStatus.Completed)]
    [InlineData(PreviewResultStatus.Unsupported)]
    [InlineData(PreviewResultStatus.TimedOut)]
    [InlineData(PreviewResultStatus.Failed)]
    public void SerializationRoundtrip_Works(PreviewResultStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PreviewResultStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PreviewResultStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PreviewResultStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PreviewResultStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
