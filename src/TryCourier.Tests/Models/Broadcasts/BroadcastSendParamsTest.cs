using System;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Broadcasts;

namespace TryCourier.Tests.Models.Broadcasts;

public class BroadcastSendParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BroadcastSendParams
        {
            BroadcastID = "broadcastId",
            RecipientID = "cool-customers",
            RecipientType = BroadcastSendParamsRecipientType.List,
        };

        string expectedBroadcastID = "broadcastId";
        string expectedRecipientID = "cool-customers";
        ApiEnum<string, BroadcastSendParamsRecipientType> expectedRecipientType =
            BroadcastSendParamsRecipientType.List;

        Assert.Equal(expectedBroadcastID, parameters.BroadcastID);
        Assert.Equal(expectedRecipientID, parameters.RecipientID);
        Assert.Equal(expectedRecipientType, parameters.RecipientType);
    }

    [Fact]
    public void Url_Works()
    {
        BroadcastSendParams parameters = new()
        {
            BroadcastID = "broadcastId",
            RecipientID = "cool-customers",
            RecipientType = BroadcastSendParamsRecipientType.List,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.courier.com/broadcasts/broadcastId/send"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BroadcastSendParams
        {
            BroadcastID = "broadcastId",
            RecipientID = "cool-customers",
            RecipientType = BroadcastSendParamsRecipientType.List,
        };

        BroadcastSendParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class BroadcastSendParamsRecipientTypeTest : TestBase
{
    [Theory]
    [InlineData(BroadcastSendParamsRecipientType.List)]
    [InlineData(BroadcastSendParamsRecipientType.Audience)]
    public void Validation_Works(BroadcastSendParamsRecipientType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BroadcastSendParamsRecipientType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BroadcastSendParamsRecipientType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BroadcastSendParamsRecipientType.List)]
    [InlineData(BroadcastSendParamsRecipientType.Audience)]
    public void SerializationRoundtrip_Works(BroadcastSendParamsRecipientType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BroadcastSendParamsRecipientType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BroadcastSendParamsRecipientType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BroadcastSendParamsRecipientType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BroadcastSendParamsRecipientType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
