using System.Text.Json;
using Courier.Models;

namespace Courier.Tests.Models;

public class TokenTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Token { TokenValue = "token" };

        string expectedTokenValue = "token";

        Assert.Equal(expectedTokenValue, model.TokenValue);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Token { TokenValue = "token" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Token>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Token { TokenValue = "token" };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Token>(element);
        Assert.NotNull(deserialized);

        string expectedTokenValue = "token";

        Assert.Equal(expectedTokenValue, deserialized.TokenValue);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Token { TokenValue = "token" };

        model.Validate();
    }
}
