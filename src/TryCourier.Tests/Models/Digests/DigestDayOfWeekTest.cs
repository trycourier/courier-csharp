using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Digests;

namespace TryCourier.Tests.Models.Digests;

public class DigestDayOfWeekTest : TestBase
{
    [Theory]
    [InlineData(DigestDayOfWeek.Sunday)]
    [InlineData(DigestDayOfWeek.Monday)]
    [InlineData(DigestDayOfWeek.Tuesday)]
    [InlineData(DigestDayOfWeek.Wednesday)]
    [InlineData(DigestDayOfWeek.Thursday)]
    [InlineData(DigestDayOfWeek.Friday)]
    [InlineData(DigestDayOfWeek.Saturday)]
    public void Validation_Works(DigestDayOfWeek rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DigestDayOfWeek> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DigestDayOfWeek>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DigestDayOfWeek.Sunday)]
    [InlineData(DigestDayOfWeek.Monday)]
    [InlineData(DigestDayOfWeek.Tuesday)]
    [InlineData(DigestDayOfWeek.Wednesday)]
    [InlineData(DigestDayOfWeek.Thursday)]
    [InlineData(DigestDayOfWeek.Friday)]
    [InlineData(DigestDayOfWeek.Saturday)]
    public void SerializationRoundtrip_Works(DigestDayOfWeek rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DigestDayOfWeek> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DigestDayOfWeek>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DigestDayOfWeek>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DigestDayOfWeek>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
