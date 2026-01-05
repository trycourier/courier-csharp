using System.Text.Json;
using Courier.Models;

namespace Courier.Tests.Models;

public class ExpoTest : TestBase
{
    [Fact]
    public void TokenValidationWorks()
    {
        Expo value = new(new Token("token"));
        value.Validate();
    }

    [Fact]
    public void MultipleTokensValidationWorks()
    {
        Expo value = new(new MultipleTokens([new("token")]));
        value.Validate();
    }

    [Fact]
    public void TokenSerializationRoundtripWorks()
    {
        Expo value = new(new Token("token"));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Expo>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MultipleTokensSerializationRoundtripWorks()
    {
        Expo value = new(new MultipleTokens([new("token")]));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Expo>(element);

        Assert.Equal(value, deserialized);
    }
}
