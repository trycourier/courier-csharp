using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models;

namespace Courier.Tests.Models;

public class ChannelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Channel
        {
            BrandID = "brand_id",
            If = "if",
            Metadata = new()
            {
                Utm = new()
                {
                    Campaign = "campaign",
                    Content = "content",
                    Medium = "medium",
                    Source = "source",
                    Term = "term",
                },
            },
            Override = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Providers = ["string"],
            RoutingMethod = RoutingMethod.All,
            Timeouts = new() { Channel = 0, Provider = 0 },
        };

        string expectedBrandID = "brand_id";
        string expectedIf = "if";
        ChannelMetadata expectedMetadata = new()
        {
            Utm = new()
            {
                Campaign = "campaign",
                Content = "content",
                Medium = "medium",
                Source = "source",
                Term = "term",
            },
        };
        Dictionary<string, JsonElement> expectedOverride = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        List<string> expectedProviders = ["string"];
        ApiEnum<string, RoutingMethod> expectedRoutingMethod = RoutingMethod.All;
        Timeouts expectedTimeouts = new() { Channel = 0, Provider = 0 };

        Assert.Equal(expectedBrandID, model.BrandID);
        Assert.Equal(expectedIf, model.If);
        Assert.Equal(expectedMetadata, model.Metadata);
        Assert.NotNull(model.Override);
        Assert.Equal(expectedOverride.Count, model.Override.Count);
        foreach (var item in expectedOverride)
        {
            Assert.True(model.Override.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Override[item.Key]));
        }
        Assert.NotNull(model.Providers);
        Assert.Equal(expectedProviders.Count, model.Providers.Count);
        for (int i = 0; i < expectedProviders.Count; i++)
        {
            Assert.Equal(expectedProviders[i], model.Providers[i]);
        }
        Assert.Equal(expectedRoutingMethod, model.RoutingMethod);
        Assert.Equal(expectedTimeouts, model.Timeouts);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Channel
        {
            BrandID = "brand_id",
            If = "if",
            Metadata = new()
            {
                Utm = new()
                {
                    Campaign = "campaign",
                    Content = "content",
                    Medium = "medium",
                    Source = "source",
                    Term = "term",
                },
            },
            Override = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Providers = ["string"],
            RoutingMethod = RoutingMethod.All,
            Timeouts = new() { Channel = 0, Provider = 0 },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Channel>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Channel
        {
            BrandID = "brand_id",
            If = "if",
            Metadata = new()
            {
                Utm = new()
                {
                    Campaign = "campaign",
                    Content = "content",
                    Medium = "medium",
                    Source = "source",
                    Term = "term",
                },
            },
            Override = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Providers = ["string"],
            RoutingMethod = RoutingMethod.All,
            Timeouts = new() { Channel = 0, Provider = 0 },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Channel>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBrandID = "brand_id";
        string expectedIf = "if";
        ChannelMetadata expectedMetadata = new()
        {
            Utm = new()
            {
                Campaign = "campaign",
                Content = "content",
                Medium = "medium",
                Source = "source",
                Term = "term",
            },
        };
        Dictionary<string, JsonElement> expectedOverride = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        List<string> expectedProviders = ["string"];
        ApiEnum<string, RoutingMethod> expectedRoutingMethod = RoutingMethod.All;
        Timeouts expectedTimeouts = new() { Channel = 0, Provider = 0 };

        Assert.Equal(expectedBrandID, deserialized.BrandID);
        Assert.Equal(expectedIf, deserialized.If);
        Assert.Equal(expectedMetadata, deserialized.Metadata);
        Assert.NotNull(deserialized.Override);
        Assert.Equal(expectedOverride.Count, deserialized.Override.Count);
        foreach (var item in expectedOverride)
        {
            Assert.True(deserialized.Override.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Override[item.Key]));
        }
        Assert.NotNull(deserialized.Providers);
        Assert.Equal(expectedProviders.Count, deserialized.Providers.Count);
        for (int i = 0; i < expectedProviders.Count; i++)
        {
            Assert.Equal(expectedProviders[i], deserialized.Providers[i]);
        }
        Assert.Equal(expectedRoutingMethod, deserialized.RoutingMethod);
        Assert.Equal(expectedTimeouts, deserialized.Timeouts);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Channel
        {
            BrandID = "brand_id",
            If = "if",
            Metadata = new()
            {
                Utm = new()
                {
                    Campaign = "campaign",
                    Content = "content",
                    Medium = "medium",
                    Source = "source",
                    Term = "term",
                },
            },
            Override = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Providers = ["string"],
            RoutingMethod = RoutingMethod.All,
            Timeouts = new() { Channel = 0, Provider = 0 },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Channel { };

        Assert.Null(model.BrandID);
        Assert.False(model.RawData.ContainsKey("brand_id"));
        Assert.Null(model.If);
        Assert.False(model.RawData.ContainsKey("if"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Override);
        Assert.False(model.RawData.ContainsKey("override"));
        Assert.Null(model.Providers);
        Assert.False(model.RawData.ContainsKey("providers"));
        Assert.Null(model.RoutingMethod);
        Assert.False(model.RawData.ContainsKey("routing_method"));
        Assert.Null(model.Timeouts);
        Assert.False(model.RawData.ContainsKey("timeouts"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Channel { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Channel
        {
            BrandID = null,
            If = null,
            Metadata = null,
            Override = null,
            Providers = null,
            RoutingMethod = null,
            Timeouts = null,
        };

        Assert.Null(model.BrandID);
        Assert.True(model.RawData.ContainsKey("brand_id"));
        Assert.Null(model.If);
        Assert.True(model.RawData.ContainsKey("if"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Override);
        Assert.True(model.RawData.ContainsKey("override"));
        Assert.Null(model.Providers);
        Assert.True(model.RawData.ContainsKey("providers"));
        Assert.Null(model.RoutingMethod);
        Assert.True(model.RawData.ContainsKey("routing_method"));
        Assert.Null(model.Timeouts);
        Assert.True(model.RawData.ContainsKey("timeouts"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Channel
        {
            BrandID = null,
            If = null,
            Metadata = null,
            Override = null,
            Providers = null,
            RoutingMethod = null,
            Timeouts = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Channel
        {
            BrandID = "brand_id",
            If = "if",
            Metadata = new()
            {
                Utm = new()
                {
                    Campaign = "campaign",
                    Content = "content",
                    Medium = "medium",
                    Source = "source",
                    Term = "term",
                },
            },
            Override = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Providers = ["string"],
            RoutingMethod = RoutingMethod.All,
            Timeouts = new() { Channel = 0, Provider = 0 },
        };

        Channel copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RoutingMethodTest : TestBase
{
    [Theory]
    [InlineData(RoutingMethod.All)]
    [InlineData(RoutingMethod.Single)]
    public void Validation_Works(RoutingMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RoutingMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RoutingMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RoutingMethod.All)]
    [InlineData(RoutingMethod.Single)]
    public void SerializationRoundtrip_Works(RoutingMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RoutingMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RoutingMethod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RoutingMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RoutingMethod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
