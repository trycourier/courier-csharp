using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models;

namespace TryCourier.Tests.Models;

public class MessageProvidersTypeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageProvidersType
        {
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
            Timeouts = 0,
        };

        string expectedIf = "if";
        Metadata expectedMetadata = new()
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
        long expectedTimeouts = 0;

        Assert.Equal(expectedIf, model.If);
        Assert.Equal(expectedMetadata, model.Metadata);
        Assert.NotNull(model.Override);
        Assert.Equal(expectedOverride.Count, model.Override.Count);
        foreach (var item in expectedOverride)
        {
            Assert.True(model.Override.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Override[item.Key]));
        }
        Assert.Equal(expectedTimeouts, model.Timeouts);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MessageProvidersType
        {
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
            Timeouts = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageProvidersType>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MessageProvidersType
        {
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
            Timeouts = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageProvidersType>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedIf = "if";
        Metadata expectedMetadata = new()
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
        long expectedTimeouts = 0;

        Assert.Equal(expectedIf, deserialized.If);
        Assert.Equal(expectedMetadata, deserialized.Metadata);
        Assert.NotNull(deserialized.Override);
        Assert.Equal(expectedOverride.Count, deserialized.Override.Count);
        foreach (var item in expectedOverride)
        {
            Assert.True(deserialized.Override.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Override[item.Key]));
        }
        Assert.Equal(expectedTimeouts, deserialized.Timeouts);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MessageProvidersType
        {
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
            Timeouts = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MessageProvidersType { };

        Assert.Null(model.If);
        Assert.False(model.RawData.ContainsKey("if"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Override);
        Assert.False(model.RawData.ContainsKey("override"));
        Assert.Null(model.Timeouts);
        Assert.False(model.RawData.ContainsKey("timeouts"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new MessageProvidersType { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new MessageProvidersType
        {
            If = null,
            Metadata = null,
            Override = null,
            Timeouts = null,
        };

        Assert.Null(model.If);
        Assert.True(model.RawData.ContainsKey("if"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Override);
        Assert.True(model.RawData.ContainsKey("override"));
        Assert.Null(model.Timeouts);
        Assert.True(model.RawData.ContainsKey("timeouts"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MessageProvidersType
        {
            If = null,
            Metadata = null,
            Override = null,
            Timeouts = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MessageProvidersType
        {
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
            Timeouts = 0,
        };

        MessageProvidersType copied = new(model);

        Assert.Equal(model, copied);
    }
}
