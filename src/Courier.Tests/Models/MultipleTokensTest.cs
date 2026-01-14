using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models;

namespace Courier.Tests.Models;

public class MultipleTokensTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MultipleTokens { Tokens = [new("token")] };

        List<Token> expectedTokens = [new("token")];

        Assert.Equal(expectedTokens.Count, model.Tokens.Count);
        for (int i = 0; i < expectedTokens.Count; i++)
        {
            Assert.Equal(expectedTokens[i], model.Tokens[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MultipleTokens { Tokens = [new("token")] };

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
        var model = new MultipleTokens { Tokens = [new("token")] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MultipleTokens>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Token> expectedTokens = [new("token")];

        Assert.Equal(expectedTokens.Count, deserialized.Tokens.Count);
        for (int i = 0; i < expectedTokens.Count; i++)
        {
            Assert.Equal(expectedTokens[i], deserialized.Tokens[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MultipleTokens { Tokens = [new("token")] };

        model.Validate();
    }
}
