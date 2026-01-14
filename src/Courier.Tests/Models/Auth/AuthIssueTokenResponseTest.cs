using System.Text.Json;
using Courier.Core;
using Courier.Models.Auth;

namespace Courier.Tests.Models.Auth;

public class AuthIssueTokenResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AuthIssueTokenResponse { Token = "token" };

        string expectedToken = "token";

        Assert.Equal(expectedToken, model.Token);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AuthIssueTokenResponse { Token = "token" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AuthIssueTokenResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AuthIssueTokenResponse { Token = "token" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AuthIssueTokenResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedToken = "token";

        Assert.Equal(expectedToken, deserialized.Token);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AuthIssueTokenResponse { Token = "token" };

        model.Validate();
    }
}
