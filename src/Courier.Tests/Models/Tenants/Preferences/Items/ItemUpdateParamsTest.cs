using System;
using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models;
using Courier.Models.Tenants.Preferences.Items;

namespace Courier.Tests.Models.Tenants.Preferences.Items;

public class ItemUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ItemUpdateParams
        {
            TenantID = "tenant_id",
            TopicID = "topic_id",
            Status = Status.OptedIn,
            CustomRouting = [ChannelClassification.Inbox],
            HasCustomRouting = true,
        };

        string expectedTenantID = "tenant_id";
        string expectedTopicID = "topic_id";
        ApiEnum<string, Status> expectedStatus = Status.OptedIn;
        List<ApiEnum<string, ChannelClassification>> expectedCustomRouting =
        [
            ChannelClassification.Inbox,
        ];
        bool expectedHasCustomRouting = true;

        Assert.Equal(expectedTenantID, parameters.TenantID);
        Assert.Equal(expectedTopicID, parameters.TopicID);
        Assert.Equal(expectedStatus, parameters.Status);
        Assert.NotNull(parameters.CustomRouting);
        Assert.Equal(expectedCustomRouting.Count, parameters.CustomRouting.Count);
        for (int i = 0; i < expectedCustomRouting.Count; i++)
        {
            Assert.Equal(expectedCustomRouting[i], parameters.CustomRouting[i]);
        }
        Assert.Equal(expectedHasCustomRouting, parameters.HasCustomRouting);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ItemUpdateParams
        {
            TenantID = "tenant_id",
            TopicID = "topic_id",
            Status = Status.OptedIn,
        };

        Assert.Null(parameters.CustomRouting);
        Assert.False(parameters.RawBodyData.ContainsKey("custom_routing"));
        Assert.Null(parameters.HasCustomRouting);
        Assert.False(parameters.RawBodyData.ContainsKey("has_custom_routing"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ItemUpdateParams
        {
            TenantID = "tenant_id",
            TopicID = "topic_id",
            Status = Status.OptedIn,

            CustomRouting = null,
            HasCustomRouting = null,
        };

        Assert.Null(parameters.CustomRouting);
        Assert.True(parameters.RawBodyData.ContainsKey("custom_routing"));
        Assert.Null(parameters.HasCustomRouting);
        Assert.True(parameters.RawBodyData.ContainsKey("has_custom_routing"));
    }

    [Fact]
    public void Url_Works()
    {
        ItemUpdateParams parameters = new()
        {
            TenantID = "tenant_id",
            TopicID = "topic_id",
            Status = Status.OptedIn,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.courier.com/tenants/tenant_id/default_preferences/items/topic_id"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ItemUpdateParams
        {
            TenantID = "tenant_id",
            TopicID = "topic_id",
            Status = Status.OptedIn,
            CustomRouting = [ChannelClassification.Inbox],
            HasCustomRouting = true,
        };

        ItemUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.OptedOut)]
    [InlineData(Status.OptedIn)]
    [InlineData(Status.Required)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.OptedOut)]
    [InlineData(Status.OptedIn)]
    [InlineData(Status.Required)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
