using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Digests;

namespace TryCourier.Tests.Models.Digests;

public class DigestFrequencyTest : TestBase
{
    [Theory]
    [InlineData(DigestFrequency.Instant)]
    [InlineData(DigestFrequency.Daily)]
    [InlineData(DigestFrequency.Weekdays)]
    [InlineData(DigestFrequency.Weekly)]
    [InlineData(DigestFrequency.CustomDays)]
    [InlineData(DigestFrequency.Monthly)]
    public void Validation_Works(DigestFrequency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DigestFrequency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DigestFrequency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DigestFrequency.Instant)]
    [InlineData(DigestFrequency.Daily)]
    [InlineData(DigestFrequency.Weekdays)]
    [InlineData(DigestFrequency.Weekly)]
    [InlineData(DigestFrequency.CustomDays)]
    [InlineData(DigestFrequency.Monthly)]
    public void SerializationRoundtrip_Works(DigestFrequency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DigestFrequency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DigestFrequency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DigestFrequency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DigestFrequency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
