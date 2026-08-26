using System;
using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Notifications;

namespace TryCourier.Tests.Models.Notifications;

public class NotificationMetricsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NotificationMetricsResponse
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Granularity = NotificationMetricsResponseGranularity.Hour,
            NotificationID = "notificationId",
            Series =
            [
                new()
                {
                    Data =
                    [
                        new()
                        {
                            Channel = "channel",
                            Clicked = 0,
                            Delivered = 0,
                            Errors = 0,
                            Opened = 0,
                            Provider = "provider",
                            Sent = 0,
                            Undeliverable = 0,
                        },
                    ],
                    Period = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, NotificationMetricsResponseGranularity> expectedGranularity =
            NotificationMetricsResponseGranularity.Hour;
        string expectedNotificationID = "notificationId";
        List<Series> expectedSeries =
        [
            new()
            {
                Data =
                [
                    new()
                    {
                        Channel = "channel",
                        Clicked = 0,
                        Delivered = 0,
                        Errors = 0,
                        Opened = 0,
                        Provider = "provider",
                        Sent = 0,
                        Undeliverable = 0,
                    },
                ],
                Period = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        DateTimeOffset expectedStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedEnd, model.End);
        Assert.Equal(expectedGranularity, model.Granularity);
        Assert.Equal(expectedNotificationID, model.NotificationID);
        Assert.Equal(expectedSeries.Count, model.Series.Count);
        for (int i = 0; i < expectedSeries.Count; i++)
        {
            Assert.Equal(expectedSeries[i], model.Series[i]);
        }
        Assert.Equal(expectedStart, model.Start);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NotificationMetricsResponse
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Granularity = NotificationMetricsResponseGranularity.Hour,
            NotificationID = "notificationId",
            Series =
            [
                new()
                {
                    Data =
                    [
                        new()
                        {
                            Channel = "channel",
                            Clicked = 0,
                            Delivered = 0,
                            Errors = 0,
                            Opened = 0,
                            Provider = "provider",
                            Sent = 0,
                            Undeliverable = 0,
                        },
                    ],
                    Period = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotificationMetricsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NotificationMetricsResponse
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Granularity = NotificationMetricsResponseGranularity.Hour,
            NotificationID = "notificationId",
            Series =
            [
                new()
                {
                    Data =
                    [
                        new()
                        {
                            Channel = "channel",
                            Clicked = 0,
                            Delivered = 0,
                            Errors = 0,
                            Opened = 0,
                            Provider = "provider",
                            Sent = 0,
                            Undeliverable = 0,
                        },
                    ],
                    Period = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotificationMetricsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, NotificationMetricsResponseGranularity> expectedGranularity =
            NotificationMetricsResponseGranularity.Hour;
        string expectedNotificationID = "notificationId";
        List<Series> expectedSeries =
        [
            new()
            {
                Data =
                [
                    new()
                    {
                        Channel = "channel",
                        Clicked = 0,
                        Delivered = 0,
                        Errors = 0,
                        Opened = 0,
                        Provider = "provider",
                        Sent = 0,
                        Undeliverable = 0,
                    },
                ],
                Period = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        DateTimeOffset expectedStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedEnd, deserialized.End);
        Assert.Equal(expectedGranularity, deserialized.Granularity);
        Assert.Equal(expectedNotificationID, deserialized.NotificationID);
        Assert.Equal(expectedSeries.Count, deserialized.Series.Count);
        for (int i = 0; i < expectedSeries.Count; i++)
        {
            Assert.Equal(expectedSeries[i], deserialized.Series[i]);
        }
        Assert.Equal(expectedStart, deserialized.Start);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NotificationMetricsResponse
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Granularity = NotificationMetricsResponseGranularity.Hour,
            NotificationID = "notificationId",
            Series =
            [
                new()
                {
                    Data =
                    [
                        new()
                        {
                            Channel = "channel",
                            Clicked = 0,
                            Delivered = 0,
                            Errors = 0,
                            Opened = 0,
                            Provider = "provider",
                            Sent = 0,
                            Undeliverable = 0,
                        },
                    ],
                    Period = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NotificationMetricsResponse
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Granularity = NotificationMetricsResponseGranularity.Hour,
            NotificationID = "notificationId",
            Series =
            [
                new()
                {
                    Data =
                    [
                        new()
                        {
                            Channel = "channel",
                            Clicked = 0,
                            Delivered = 0,
                            Errors = 0,
                            Opened = 0,
                            Provider = "provider",
                            Sent = 0,
                            Undeliverable = 0,
                        },
                    ],
                    Period = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        NotificationMetricsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NotificationMetricsResponseGranularityTest : TestBase
{
    [Theory]
    [InlineData(NotificationMetricsResponseGranularity.Hour)]
    [InlineData(NotificationMetricsResponseGranularity.Day)]
    [InlineData(NotificationMetricsResponseGranularity.Week)]
    [InlineData(NotificationMetricsResponseGranularity.Month)]
    public void Validation_Works(NotificationMetricsResponseGranularity rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NotificationMetricsResponseGranularity> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NotificationMetricsResponseGranularity>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NotificationMetricsResponseGranularity.Hour)]
    [InlineData(NotificationMetricsResponseGranularity.Day)]
    [InlineData(NotificationMetricsResponseGranularity.Week)]
    [InlineData(NotificationMetricsResponseGranularity.Month)]
    public void SerializationRoundtrip_Works(NotificationMetricsResponseGranularity rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NotificationMetricsResponseGranularity> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NotificationMetricsResponseGranularity>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, NotificationMetricsResponseGranularity>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NotificationMetricsResponseGranularity>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SeriesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Series
        {
            Data =
            [
                new()
                {
                    Channel = "channel",
                    Clicked = 0,
                    Delivered = 0,
                    Errors = 0,
                    Opened = 0,
                    Provider = "provider",
                    Sent = 0,
                    Undeliverable = 0,
                },
            ],
            Period = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        List<Data> expectedData =
        [
            new()
            {
                Channel = "channel",
                Clicked = 0,
                Delivered = 0,
                Errors = 0,
                Opened = 0,
                Provider = "provider",
                Sent = 0,
                Undeliverable = 0,
            },
        ];
        DateTimeOffset expectedPeriod = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedPeriod, model.Period);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Series
        {
            Data =
            [
                new()
                {
                    Channel = "channel",
                    Clicked = 0,
                    Delivered = 0,
                    Errors = 0,
                    Opened = 0,
                    Provider = "provider",
                    Sent = 0,
                    Undeliverable = 0,
                },
            ],
            Period = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Series>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Series
        {
            Data =
            [
                new()
                {
                    Channel = "channel",
                    Clicked = 0,
                    Delivered = 0,
                    Errors = 0,
                    Opened = 0,
                    Provider = "provider",
                    Sent = 0,
                    Undeliverable = 0,
                },
            ],
            Period = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Series>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<Data> expectedData =
        [
            new()
            {
                Channel = "channel",
                Clicked = 0,
                Delivered = 0,
                Errors = 0,
                Opened = 0,
                Provider = "provider",
                Sent = 0,
                Undeliverable = 0,
            },
        ];
        DateTimeOffset expectedPeriod = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedPeriod, deserialized.Period);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Series
        {
            Data =
            [
                new()
                {
                    Channel = "channel",
                    Clicked = 0,
                    Delivered = 0,
                    Errors = 0,
                    Opened = 0,
                    Provider = "provider",
                    Sent = 0,
                    Undeliverable = 0,
                },
            ],
            Period = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Series
        {
            Data =
            [
                new()
                {
                    Channel = "channel",
                    Clicked = 0,
                    Delivered = 0,
                    Errors = 0,
                    Opened = 0,
                    Provider = "provider",
                    Sent = 0,
                    Undeliverable = 0,
                },
            ],
            Period = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Series copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
        {
            Channel = "channel",
            Clicked = 0,
            Delivered = 0,
            Errors = 0,
            Opened = 0,
            Provider = "provider",
            Sent = 0,
            Undeliverable = 0,
        };

        string expectedChannel = "channel";
        long expectedClicked = 0;
        long expectedDelivered = 0;
        long expectedErrors = 0;
        long expectedOpened = 0;
        string expectedProvider = "provider";
        long expectedSent = 0;
        long expectedUndeliverable = 0;

        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedClicked, model.Clicked);
        Assert.Equal(expectedDelivered, model.Delivered);
        Assert.Equal(expectedErrors, model.Errors);
        Assert.Equal(expectedOpened, model.Opened);
        Assert.Equal(expectedProvider, model.Provider);
        Assert.Equal(expectedSent, model.Sent);
        Assert.Equal(expectedUndeliverable, model.Undeliverable);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            Channel = "channel",
            Clicked = 0,
            Delivered = 0,
            Errors = 0,
            Opened = 0,
            Provider = "provider",
            Sent = 0,
            Undeliverable = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Data
        {
            Channel = "channel",
            Clicked = 0,
            Delivered = 0,
            Errors = 0,
            Opened = 0,
            Provider = "provider",
            Sent = 0,
            Undeliverable = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedChannel = "channel";
        long expectedClicked = 0;
        long expectedDelivered = 0;
        long expectedErrors = 0;
        long expectedOpened = 0;
        string expectedProvider = "provider";
        long expectedSent = 0;
        long expectedUndeliverable = 0;

        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedClicked, deserialized.Clicked);
        Assert.Equal(expectedDelivered, deserialized.Delivered);
        Assert.Equal(expectedErrors, deserialized.Errors);
        Assert.Equal(expectedOpened, deserialized.Opened);
        Assert.Equal(expectedProvider, deserialized.Provider);
        Assert.Equal(expectedSent, deserialized.Sent);
        Assert.Equal(expectedUndeliverable, deserialized.Undeliverable);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            Channel = "channel",
            Clicked = 0,
            Delivered = 0,
            Errors = 0,
            Opened = 0,
            Provider = "provider",
            Sent = 0,
            Undeliverable = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
        {
            Channel = "channel",
            Clicked = 0,
            Delivered = 0,
            Errors = 0,
            Opened = 0,
            Provider = "provider",
            Sent = 0,
            Undeliverable = 0,
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}
