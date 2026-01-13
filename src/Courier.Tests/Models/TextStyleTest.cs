using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models;

namespace Courier.Tests.Models;

public class TextStyleTest : TestBase
{
    [Theory]
    [InlineData(TextStyle.Text)]
    [InlineData(TextStyle.H1)]
    [InlineData(TextStyle.H2)]
    [InlineData(TextStyle.Subtext)]
    public void Validation_Works(TextStyle rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TextStyle> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TextStyle>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TextStyle.Text)]
    [InlineData(TextStyle.H1)]
    [InlineData(TextStyle.H2)]
    [InlineData(TextStyle.Subtext)]
    public void SerializationRoundtrip_Works(TextStyle rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TextStyle> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TextStyle>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TextStyle>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TextStyle>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
