using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Journeys;

namespace TryCourier.Tests.Models.Journeys;

public class JourneyAINodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JourneyAINode
        {
            OutputSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Type = Type.AI,
            ID = "x",
            Conditions = new(["string", "string"]),
            Model = "x",
            UserPrompt = "user_prompt",
            WebSearch = true,
        };

        Dictionary<string, JsonElement> expectedOutputSchema = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        ApiEnum<string, Type> expectedType = Type.AI;
        string expectedID = "x";
        JourneyConditionsField expectedConditions = new(["string", "string"]);
        string expectedModel = "x";
        string expectedUserPrompt = "user_prompt";
        bool expectedWebSearch = true;

        Assert.Equal(expectedOutputSchema.Count, model.OutputSchema.Count);
        foreach (var item in expectedOutputSchema)
        {
            Assert.True(model.OutputSchema.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.OutputSchema[item.Key]));
        }
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedConditions, model.Conditions);
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedUserPrompt, model.UserPrompt);
        Assert.Equal(expectedWebSearch, model.WebSearch);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JourneyAINode
        {
            OutputSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Type = Type.AI,
            ID = "x",
            Conditions = new(["string", "string"]),
            Model = "x",
            UserPrompt = "user_prompt",
            WebSearch = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyAINode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JourneyAINode
        {
            OutputSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Type = Type.AI,
            ID = "x",
            Conditions = new(["string", "string"]),
            Model = "x",
            UserPrompt = "user_prompt",
            WebSearch = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyAINode>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Dictionary<string, JsonElement> expectedOutputSchema = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        ApiEnum<string, Type> expectedType = Type.AI;
        string expectedID = "x";
        JourneyConditionsField expectedConditions = new(["string", "string"]);
        string expectedModel = "x";
        string expectedUserPrompt = "user_prompt";
        bool expectedWebSearch = true;

        Assert.Equal(expectedOutputSchema.Count, deserialized.OutputSchema.Count);
        foreach (var item in expectedOutputSchema)
        {
            Assert.True(deserialized.OutputSchema.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.OutputSchema[item.Key]));
        }
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedConditions, deserialized.Conditions);
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedUserPrompt, deserialized.UserPrompt);
        Assert.Equal(expectedWebSearch, deserialized.WebSearch);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JourneyAINode
        {
            OutputSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Type = Type.AI,
            ID = "x",
            Conditions = new(["string", "string"]),
            Model = "x",
            UserPrompt = "user_prompt",
            WebSearch = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JourneyAINode
        {
            OutputSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Type = Type.AI,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Conditions);
        Assert.False(model.RawData.ContainsKey("conditions"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.UserPrompt);
        Assert.False(model.RawData.ContainsKey("user_prompt"));
        Assert.Null(model.WebSearch);
        Assert.False(model.RawData.ContainsKey("web_search"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new JourneyAINode
        {
            OutputSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Type = Type.AI,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new JourneyAINode
        {
            OutputSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Type = Type.AI,

            // Null should be interpreted as omitted for these properties
            ID = null,
            Conditions = null,
            Model = null,
            UserPrompt = null,
            WebSearch = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Conditions);
        Assert.False(model.RawData.ContainsKey("conditions"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.UserPrompt);
        Assert.False(model.RawData.ContainsKey("user_prompt"));
        Assert.Null(model.WebSearch);
        Assert.False(model.RawData.ContainsKey("web_search"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new JourneyAINode
        {
            OutputSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Type = Type.AI,

            // Null should be interpreted as omitted for these properties
            ID = null,
            Conditions = null,
            Model = null,
            UserPrompt = null,
            WebSearch = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JourneyAINode
        {
            OutputSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Type = Type.AI,
            ID = "x",
            Conditions = new(["string", "string"]),
            Model = "x",
            UserPrompt = "user_prompt",
            WebSearch = true,
        };

        JourneyAINode copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Type.AI)]
    public void Validation_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Type.AI)]
    public void SerializationRoundtrip_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
