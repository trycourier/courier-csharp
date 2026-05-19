using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Journeys;

namespace Courier.Tests.Models.Journeys;

public class JourneyMergeStrategyTest : TestBase
{
    [Theory]
    [InlineData(JourneyMergeStrategy.Overwrite)]
    [InlineData(JourneyMergeStrategy.SoftMerge)]
    [InlineData(JourneyMergeStrategy.Replace)]
    [InlineData(JourneyMergeStrategy.None)]
    public void Validation_Works(JourneyMergeStrategy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyMergeStrategy> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JourneyMergeStrategy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(JourneyMergeStrategy.Overwrite)]
    [InlineData(JourneyMergeStrategy.SoftMerge)]
    [InlineData(JourneyMergeStrategy.Replace)]
    [InlineData(JourneyMergeStrategy.None)]
    public void SerializationRoundtrip_Works(JourneyMergeStrategy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyMergeStrategy> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, JourneyMergeStrategy>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JourneyMergeStrategy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, JourneyMergeStrategy>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
