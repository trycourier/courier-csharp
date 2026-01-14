using System;
using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Inbound = Courier.Models.Inbound;

namespace Courier.Tests.Models.Inbound;

public class InboundTrackEventParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Inbound::InboundTrackEventParams
        {
            Event = "New Order Placed",
            MessageID = "4c62c457-b329-4bea-9bfc-17bba86c393f",
            Properties = new Dictionary<string, JsonElement>()
            {
                { "order_id", JsonSerializer.SerializeToElement("bar") },
                { "total_orders", JsonSerializer.SerializeToElement("bar") },
                { "last_order_id", JsonSerializer.SerializeToElement("bar") },
            },
            Type = Inbound::Type.Track,
            UserID = "1234",
        };

        string expectedEvent = "New Order Placed";
        string expectedMessageID = "4c62c457-b329-4bea-9bfc-17bba86c393f";
        Dictionary<string, JsonElement> expectedProperties = new()
        {
            { "order_id", JsonSerializer.SerializeToElement("bar") },
            { "total_orders", JsonSerializer.SerializeToElement("bar") },
            { "last_order_id", JsonSerializer.SerializeToElement("bar") },
        };
        ApiEnum<string, Inbound::Type> expectedType = Inbound::Type.Track;
        string expectedUserID = "1234";

        Assert.Equal(expectedEvent, parameters.Event);
        Assert.Equal(expectedMessageID, parameters.MessageID);
        Assert.Equal(expectedProperties.Count, parameters.Properties.Count);
        foreach (var item in expectedProperties)
        {
            Assert.True(parameters.Properties.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.Properties[item.Key]));
        }
        Assert.Equal(expectedType, parameters.Type);
        Assert.Equal(expectedUserID, parameters.UserID);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Inbound::InboundTrackEventParams
        {
            Event = "New Order Placed",
            MessageID = "4c62c457-b329-4bea-9bfc-17bba86c393f",
            Properties = new Dictionary<string, JsonElement>()
            {
                { "order_id", JsonSerializer.SerializeToElement("bar") },
                { "total_orders", JsonSerializer.SerializeToElement("bar") },
                { "last_order_id", JsonSerializer.SerializeToElement("bar") },
            },
            Type = Inbound::Type.Track,
        };

        Assert.Null(parameters.UserID);
        Assert.False(parameters.RawBodyData.ContainsKey("userId"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new Inbound::InboundTrackEventParams
        {
            Event = "New Order Placed",
            MessageID = "4c62c457-b329-4bea-9bfc-17bba86c393f",
            Properties = new Dictionary<string, JsonElement>()
            {
                { "order_id", JsonSerializer.SerializeToElement("bar") },
                { "total_orders", JsonSerializer.SerializeToElement("bar") },
                { "last_order_id", JsonSerializer.SerializeToElement("bar") },
            },
            Type = Inbound::Type.Track,

            UserID = null,
        };

        Assert.Null(parameters.UserID);
        Assert.True(parameters.RawBodyData.ContainsKey("userId"));
    }

    [Fact]
    public void Url_Works()
    {
        Inbound::InboundTrackEventParams parameters = new()
        {
            Event = "New Order Placed",
            MessageID = "4c62c457-b329-4bea-9bfc-17bba86c393f",
            Properties = new Dictionary<string, JsonElement>()
            {
                { "order_id", JsonSerializer.SerializeToElement("bar") },
                { "total_orders", JsonSerializer.SerializeToElement("bar") },
                { "last_order_id", JsonSerializer.SerializeToElement("bar") },
            },
            Type = Inbound::Type.Track,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/inbound/courier"), url);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Inbound::Type.Track)]
    public void Validation_Works(Inbound::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Inbound::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Inbound::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Inbound::Type.Track)]
    public void SerializationRoundtrip_Works(Inbound::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Inbound::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Inbound::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Inbound::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Inbound::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
