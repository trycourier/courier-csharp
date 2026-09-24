using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Notifications.Previews.Runs;

namespace TryCourier.Tests.Models.Notifications.Previews.Runs;

public class PreviewRunStatusTest : TestBase
{
    [Theory]
    [InlineData(PreviewRunStatus.Pending)]
    [InlineData(PreviewRunStatus.Rendered)]
    [InlineData(PreviewRunStatus.Submitted)]
    [InlineData(PreviewRunStatus.Completed)]
    [InlineData(PreviewRunStatus.Failed)]
    public void Validation_Works(PreviewRunStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PreviewRunStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PreviewRunStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PreviewRunStatus.Pending)]
    [InlineData(PreviewRunStatus.Rendered)]
    [InlineData(PreviewRunStatus.Submitted)]
    [InlineData(PreviewRunStatus.Completed)]
    [InlineData(PreviewRunStatus.Failed)]
    public void SerializationRoundtrip_Works(PreviewRunStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PreviewRunStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PreviewRunStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PreviewRunStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PreviewRunStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
