using System.Collections.Generic;
using System.Text.Json;
using Courier.Models;

namespace Courier.Tests.Models;

public class WebhookRecipientTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookRecipient
        {
            Webhook = new()
            {
                URL = "url",
                Authentication = new()
                {
                    Mode = WebhookAuthMode.None,
                    Token = "token",
                    Password = "password",
                    Username = "username",
                },
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                Method = WebhookMethod.Post,
                Profile = WebhookProfileType.Limited,
            },
        };

        WebhookProfile expectedWebhook = new()
        {
            URL = "url",
            Authentication = new()
            {
                Mode = WebhookAuthMode.None,
                Token = "token",
                Password = "password",
                Username = "username",
            },
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Method = WebhookMethod.Post,
            Profile = WebhookProfileType.Limited,
        };

        Assert.Equal(expectedWebhook, model.Webhook);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookRecipient
        {
            Webhook = new()
            {
                URL = "url",
                Authentication = new()
                {
                    Mode = WebhookAuthMode.None,
                    Token = "token",
                    Password = "password",
                    Username = "username",
                },
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                Method = WebhookMethod.Post,
                Profile = WebhookProfileType.Limited,
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<WebhookRecipient>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookRecipient
        {
            Webhook = new()
            {
                URL = "url",
                Authentication = new()
                {
                    Mode = WebhookAuthMode.None,
                    Token = "token",
                    Password = "password",
                    Username = "username",
                },
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                Method = WebhookMethod.Post,
                Profile = WebhookProfileType.Limited,
            },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<WebhookRecipient>(element);
        Assert.NotNull(deserialized);

        WebhookProfile expectedWebhook = new()
        {
            URL = "url",
            Authentication = new()
            {
                Mode = WebhookAuthMode.None,
                Token = "token",
                Password = "password",
                Username = "username",
            },
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Method = WebhookMethod.Post,
            Profile = WebhookProfileType.Limited,
        };

        Assert.Equal(expectedWebhook, deserialized.Webhook);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookRecipient
        {
            Webhook = new()
            {
                URL = "url",
                Authentication = new()
                {
                    Mode = WebhookAuthMode.None,
                    Token = "token",
                    Password = "password",
                    Username = "username",
                },
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                Method = WebhookMethod.Post,
                Profile = WebhookProfileType.Limited,
            },
        };

        model.Validate();
    }
}
