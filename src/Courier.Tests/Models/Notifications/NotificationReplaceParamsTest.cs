using System;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models;
using Courier.Models.Notifications;

namespace Courier.Tests.Models.Notifications;

public class NotificationReplaceParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NotificationReplaceParams
        {
            ID = "id",
            Notification = new()
            {
                Brand = new("id"),
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
                Name = "Updated Name",
                Routing = new("strategy_id"),
                Subscription = new("topic_id"),
                Tags = ["updated"],
            },
            State = NotificationReplaceParamsState.Published,
        };

        string expectedID = "id";
        NotificationTemplatePayload expectedNotification = new()
        {
            Brand = new("id"),
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
            Name = "Updated Name",
            Routing = new("strategy_id"),
            Subscription = new("topic_id"),
            Tags = ["updated"],
        };
        ApiEnum<string, NotificationReplaceParamsState> expectedState =
            NotificationReplaceParamsState.Published;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedNotification, parameters.Notification);
        Assert.Equal(expectedState, parameters.State);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new NotificationReplaceParams
        {
            ID = "id",
            Notification = new()
            {
                Brand = new("id"),
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
                Name = "Updated Name",
                Routing = new("strategy_id"),
                Subscription = new("topic_id"),
                Tags = ["updated"],
            },
        };

        Assert.Null(parameters.State);
        Assert.False(parameters.RawBodyData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new NotificationReplaceParams
        {
            ID = "id",
            Notification = new()
            {
                Brand = new("id"),
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
                Name = "Updated Name",
                Routing = new("strategy_id"),
                Subscription = new("topic_id"),
                Tags = ["updated"],
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
        NotificationReplaceParams parameters = new()
        {
            ID = "id",
            Notification = new()
            {
                Brand = new("id"),
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
                Name = "Updated Name",
                Routing = new("strategy_id"),
                Subscription = new("topic_id"),
                Tags = ["updated"],
            },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/notifications/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new NotificationReplaceParams
        {
            ID = "id",
            Notification = new()
            {
                Brand = new("id"),
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
                Name = "Updated Name",
                Routing = new("strategy_id"),
                Subscription = new("topic_id"),
                Tags = ["updated"],
            },
            State = NotificationReplaceParamsState.Published,
        };

        NotificationReplaceParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class NotificationReplaceParamsStateTest : TestBase
{
    [Theory]
    [InlineData(NotificationReplaceParamsState.Draft)]
    [InlineData(NotificationReplaceParamsState.Published)]
    public void Validation_Works(NotificationReplaceParamsState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NotificationReplaceParamsState> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NotificationReplaceParamsState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NotificationReplaceParamsState.Draft)]
    [InlineData(NotificationReplaceParamsState.Published)]
    public void SerializationRoundtrip_Works(NotificationReplaceParamsState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NotificationReplaceParamsState> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NotificationReplaceParamsState>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NotificationReplaceParamsState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NotificationReplaceParamsState>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
