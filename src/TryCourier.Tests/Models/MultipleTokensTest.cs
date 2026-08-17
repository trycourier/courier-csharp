using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models;

namespace TryCourier.Tests.Models;

public class MultipleTokensTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MultipleTokens { Tokens = "string" };

        Tokens expectedTokens = "string";

        Assert.Equal(expectedTokens, model.Tokens);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MultipleTokens { Tokens = "string" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MultipleTokens>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MultipleTokens { Tokens = "string" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MultipleTokens>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Tokens expectedTokens = "string";

        Assert.Equal(expectedTokens, deserialized.Tokens);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MultipleTokens { Tokens = "string" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MultipleTokens { Tokens = "string" };

        MultipleTokens copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TokensTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Tokens value = "string";
        value.Validate();
    }

    [Fact]
    public void StringsValidationWorks()
    {
        Tokens value = new(["string"]);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Tokens value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tokens>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringsSerializationRoundtripWorks()
    {
        Tokens value = new(["string"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tokens>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
