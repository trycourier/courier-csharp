using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models;

namespace Courier.Tests.Models;

public class PreferenceStatusTest : TestBase
{
    [Theory]
    [InlineData(PreferenceStatus.OptedIn)]
    [InlineData(PreferenceStatus.OptedOut)]
    [InlineData(PreferenceStatus.Required)]
    public void Validation_Works(PreferenceStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PreferenceStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PreferenceStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PreferenceStatus.OptedIn)]
    [InlineData(PreferenceStatus.OptedOut)]
    [InlineData(PreferenceStatus.Required)]
    public void SerializationRoundtrip_Works(PreferenceStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PreferenceStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PreferenceStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PreferenceStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PreferenceStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
