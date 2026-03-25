using System;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models;
using Courier.Models.Notifications;

namespace Courier.Tests.Models.Notifications;

public class NotificationCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NotificationCreateParams
        {
            Notification = new()
            {
                Brand = new("brand_abc"),
                Content = new()
                {
                    Elements =
                    [
                        new ElementalChannelNodeWithType()
                        {
                            Type = ElementalChannelNodeWithTypeIntersectionMember1Type.Channel,
                        },
                    ],
                    Version = "2022-01-01",
                },
                Name = "Welcome Email",
                Routing = new("rs_123"),
                Subscription = new("marketing"),
                Tags = ["onboarding", "welcome"],
            },
            State = State.Draft,
        };

        NotificationTemplatePayload expectedNotification = new()
        {
            Brand = new("brand_abc"),
            Content = new()
            {
                Elements =
                [
                    new ElementalChannelNodeWithType()
                    {
                        Type = ElementalChannelNodeWithTypeIntersectionMember1Type.Channel,
                    },
                ],
                Version = "2022-01-01",
            },
            Name = "Welcome Email",
            Routing = new("rs_123"),
            Subscription = new("marketing"),
            Tags = ["onboarding", "welcome"],
        };
        ApiEnum<string, State> expectedState = State.Draft;

        Assert.Equal(expectedNotification, parameters.Notification);
        Assert.Equal(expectedState, parameters.State);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new NotificationCreateParams
        {
            Notification = new()
            {
                Brand = new("brand_abc"),
                Content = new()
                {
                    Elements =
                    [
                        new ElementalChannelNodeWithType()
                        {
                            Type = ElementalChannelNodeWithTypeIntersectionMember1Type.Channel,
                        },
                    ],
                    Version = "2022-01-01",
                },
                Name = "Welcome Email",
                Routing = new("rs_123"),
                Subscription = new("marketing"),
                Tags = ["onboarding", "welcome"],
            },
        };

        Assert.Null(parameters.State);
        Assert.False(parameters.RawBodyData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new NotificationCreateParams
        {
            Notification = new()
            {
                Brand = new("brand_abc"),
                Content = new()
                {
                    Elements =
                    [
                        new ElementalChannelNodeWithType()
                        {
                            Type = ElementalChannelNodeWithTypeIntersectionMember1Type.Channel,
                        },
                    ],
                    Version = "2022-01-01",
                },
                Name = "Welcome Email",
                Routing = new("rs_123"),
                Subscription = new("marketing"),
                Tags = ["onboarding", "welcome"],
            },

            // Null should be interpreted as omitted for these properties
            State = null,
        };

        Assert.Null(parameters.State);
        Assert.False(parameters.RawBodyData.ContainsKey("state"));
    }

    [Fact]
    public void Url_Works()
    {
        NotificationCreateParams parameters = new()
        {
            Notification = new()
            {
                Brand = new("brand_abc"),
                Content = new()
                {
                    Elements =
                    [
                        new ElementalChannelNodeWithType()
                        {
                            Type = ElementalChannelNodeWithTypeIntersectionMember1Type.Channel,
                        },
                    ],
                    Version = "2022-01-01",
                },
                Name = "Welcome Email",
                Routing = new("rs_123"),
                Subscription = new("marketing"),
                Tags = ["onboarding", "welcome"],
            },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/notifications"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new NotificationCreateParams
        {
            Notification = new()
            {
                Brand = new("brand_abc"),
                Content = new()
                {
                    Elements =
                    [
                        new ElementalChannelNodeWithType()
                        {
                            Type = ElementalChannelNodeWithTypeIntersectionMember1Type.Channel,
                        },
                    ],
                    Version = "2022-01-01",
                },
                Name = "Welcome Email",
                Routing = new("rs_123"),
                Subscription = new("marketing"),
                Tags = ["onboarding", "welcome"],
            },
            State = State.Draft,
        };

        NotificationCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class StateTest : TestBase
{
    [Theory]
    [InlineData(State.Draft)]
    [InlineData(State.Published)]
    public void Validation_Works(State rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, State> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, State>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(State.Draft)]
    [InlineData(State.Published)]
    public void SerializationRoundtrip_Works(State rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, State> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, State>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, State>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, State>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
