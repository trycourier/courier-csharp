using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models;

namespace TryCourier.Tests.Models;

public class ApnTest : TestBase
{
    [Fact]
    public void TokenValidationWorks()
    {
        Apn value = new Token("token");
        value.Validate();
    }

    [Fact]
    public void MultipleTokensValidationWorks()
    {
        Apn value = new MultipleTokens(new Tokens("string"));
        value.Validate();
    }

    [Fact]
    public void TokenSerializationRoundtripWorks()
    {
        Apn value = new Token("token");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Apn>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MultipleTokensSerializationRoundtripWorks()
    {
        Apn value = new MultipleTokens(new Tokens("string"));
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Apn>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
