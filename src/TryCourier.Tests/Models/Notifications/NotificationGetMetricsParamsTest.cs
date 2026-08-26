using System;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Notifications;

namespace TryCourier.Tests.Models.Notifications;

public class NotificationGetMetricsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NotificationGetMetricsParams
        {
            ID = "x",
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Granularity = Granularity.Hour,
            Lookback = "lookback",
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "x";
        DateTimeOffset expectedEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Granularity> expectedGranularity = Granularity.Hour;
        string expectedLookback = "lookback";
        DateTimeOffset expectedStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedEnd, parameters.End);
        Assert.Equal(expectedGranularity, parameters.Granularity);
        Assert.Equal(expectedLookback, parameters.Lookback);
        Assert.Equal(expectedStart, parameters.Start);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new NotificationGetMetricsParams { ID = "x" };

        Assert.Null(parameters.End);
        Assert.False(parameters.RawQueryData.ContainsKey("end"));
        Assert.Null(parameters.Granularity);
        Assert.False(parameters.RawQueryData.ContainsKey("granularity"));
        Assert.Null(parameters.Lookback);
        Assert.False(parameters.RawQueryData.ContainsKey("lookback"));
        Assert.Null(parameters.Start);
        Assert.False(parameters.RawQueryData.ContainsKey("start"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new NotificationGetMetricsParams
        {
            ID = "x",

            // Null should be interpreted as omitted for these properties
            End = null,
            Granularity = null,
            Lookback = null,
            Start = null,
        };

        Assert.Null(parameters.End);
        Assert.False(parameters.RawQueryData.ContainsKey("end"));
        Assert.Null(parameters.Granularity);
        Assert.False(parameters.RawQueryData.ContainsKey("granularity"));
        Assert.Null(parameters.Lookback);
        Assert.False(parameters.RawQueryData.ContainsKey("lookback"));
        Assert.Null(parameters.Start);
        Assert.False(parameters.RawQueryData.ContainsKey("start"));
    }

    [Fact]
    public void Url_Works()
    {
        NotificationGetMetricsParams parameters = new()
        {
            ID = "x",
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            Granularity = Granularity.Hour,
            Lookback = "lookback",
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.courier.com/notifications/x/metrics?end=2019-12-27T18%3a11%3a19.117%2b00%3a00&granularity=HOUR&lookback=lookback&start=2019-12-27T18%3a11%3a19.117%2b00%3a00"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new NotificationGetMetricsParams
        {
            ID = "x",
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Granularity = Granularity.Hour,
            Lookback = "lookback",
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        NotificationGetMetricsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class GranularityTest : TestBase
{
    [Theory]
    [InlineData(Granularity.Hour)]
    [InlineData(Granularity.Day)]
    [InlineData(Granularity.Week)]
    [InlineData(Granularity.Month)]
    public void Validation_Works(Granularity rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Granularity> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Granularity>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Granularity.Hour)]
    [InlineData(Granularity.Day)]
    [InlineData(Granularity.Week)]
    [InlineData(Granularity.Month)]
    public void SerializationRoundtrip_Works(Granularity rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Granularity> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Granularity>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Granularity>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Granularity>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
