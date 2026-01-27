using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models;
using Courier.Models.Tenants;

namespace Courier.Tests.Models.Tenants;

public class SubscriptionTopicNewTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionTopicNew
        {
            Status = Status.OptedOut,
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
        };

        ApiEnum<string, Status> expectedStatus = Status.OptedOut;
        List<ApiEnum<string, ChannelClassification>> expectedCustomRouting =
        [
            ChannelClassification.DirectMessage,
        ];
        bool expectedHasCustomRouting = true;

        Assert.Equal(expectedStatus, model.Status);
        Assert.NotNull(model.CustomRouting);
        Assert.Equal(expectedCustomRouting.Count, model.CustomRouting.Count);
        for (int i = 0; i < expectedCustomRouting.Count; i++)
        {
            Assert.Equal(expectedCustomRouting[i], model.CustomRouting[i]);
        }
        Assert.Equal(expectedHasCustomRouting, model.HasCustomRouting);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionTopicNew
        {
            Status = Status.OptedOut,
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionTopicNew>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionTopicNew
        {
            Status = Status.OptedOut,
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionTopicNew>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Status> expectedStatus = Status.OptedOut;
        List<ApiEnum<string, ChannelClassification>> expectedCustomRouting =
        [
            ChannelClassification.DirectMessage,
        ];
        bool expectedHasCustomRouting = true;

        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.NotNull(deserialized.CustomRouting);
        Assert.Equal(expectedCustomRouting.Count, deserialized.CustomRouting.Count);
        for (int i = 0; i < expectedCustomRouting.Count; i++)
        {
            Assert.Equal(expectedCustomRouting[i], deserialized.CustomRouting[i]);
        }
        Assert.Equal(expectedHasCustomRouting, deserialized.HasCustomRouting);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionTopicNew
        {
            Status = Status.OptedOut,
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionTopicNew { Status = Status.OptedOut };

        Assert.Null(model.CustomRouting);
        Assert.False(model.RawData.ContainsKey("custom_routing"));
        Assert.Null(model.HasCustomRouting);
        Assert.False(model.RawData.ContainsKey("has_custom_routing"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionTopicNew { Status = Status.OptedOut };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SubscriptionTopicNew
        {
            Status = Status.OptedOut,

            CustomRouting = null,
            HasCustomRouting = null,
        };

        Assert.Null(model.CustomRouting);
        Assert.True(model.RawData.ContainsKey("custom_routing"));
        Assert.Null(model.HasCustomRouting);
        Assert.True(model.RawData.ContainsKey("has_custom_routing"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionTopicNew
        {
            Status = Status.OptedOut,

            CustomRouting = null,
            HasCustomRouting = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionTopicNew
        {
            Status = Status.OptedOut,
            CustomRouting = [ChannelClassification.DirectMessage],
            HasCustomRouting = true,
        };

        SubscriptionTopicNew copied = new(model);

        Assert.Equal(model, copied);
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
