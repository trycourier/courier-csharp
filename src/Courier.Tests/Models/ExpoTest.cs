using System.Text.Json;
using Courier.Core;
using Courier.Models;

namespace Courier.Tests.Models;

public class ExpoTest : TestBase
{
    [Fact]
    public void TokenValidationWorks()
    {
        Expo value = new Token("token");
        value.Validate();
    }

    [Fact]
    public void MultipleTokensValidationWorks()
    {
        Expo value = new MultipleTokens([new("token")]);
        value.Validate();
    }

    [Fact]
    public void TokenSerializationRoundtripWorks()
    {
        Expo value = new Token("token");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Expo>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MultipleTokensSerializationRoundtripWorks()
    {
        Expo value = new MultipleTokens([new("token")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Expo>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
