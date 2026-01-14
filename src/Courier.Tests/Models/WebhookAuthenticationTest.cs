using System.Text.Json;
using Courier.Core;
using Courier.Models;

namespace Courier.Tests.Models;

public class WebhookAuthenticationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookAuthentication
        {
            Mode = WebhookAuthMode.None,
            Token = "token",
            Password = "password",
            Username = "username",
        };

        ApiEnum<string, WebhookAuthMode> expectedMode = WebhookAuthMode.None;
        string expectedToken = "token";
        string expectedPassword = "password";
        string expectedUsername = "username";

        Assert.Equal(expectedMode, model.Mode);
        Assert.Equal(expectedToken, model.Token);
        Assert.Equal(expectedPassword, model.Password);
        Assert.Equal(expectedUsername, model.Username);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookAuthentication
        {
            Mode = WebhookAuthMode.None,
            Token = "token",
            Password = "password",
            Username = "username",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookAuthentication>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookAuthentication
        {
            Mode = WebhookAuthMode.None,
            Token = "token",
            Password = "password",
            Username = "username",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookAuthentication>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, WebhookAuthMode> expectedMode = WebhookAuthMode.None;
        string expectedToken = "token";
        string expectedPassword = "password";
        string expectedUsername = "username";

        Assert.Equal(expectedMode, deserialized.Mode);
        Assert.Equal(expectedToken, deserialized.Token);
        Assert.Equal(expectedPassword, deserialized.Password);
        Assert.Equal(expectedUsername, deserialized.Username);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookAuthentication
        {
            Mode = WebhookAuthMode.None,
            Token = "token",
            Password = "password",
            Username = "username",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebhookAuthentication { Mode = WebhookAuthMode.None };

        Assert.Null(model.Token);
        Assert.False(model.RawData.ContainsKey("token"));
        Assert.Null(model.Password);
        Assert.False(model.RawData.ContainsKey("password"));
        Assert.Null(model.Username);
        Assert.False(model.RawData.ContainsKey("username"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebhookAuthentication { Mode = WebhookAuthMode.None };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WebhookAuthentication
        {
            Mode = WebhookAuthMode.None,

            Token = null,
            Password = null,
            Username = null,
        };

        Assert.Null(model.Token);
        Assert.True(model.RawData.ContainsKey("token"));
        Assert.Null(model.Password);
        Assert.True(model.RawData.ContainsKey("password"));
        Assert.Null(model.Username);
        Assert.True(model.RawData.ContainsKey("username"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebhookAuthentication
        {
            Mode = WebhookAuthMode.None,

            Token = null,
            Password = null,
            Username = null,
        };

        model.Validate();
    }
}
