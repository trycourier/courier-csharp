using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models;

namespace Courier.Tests.Models;

public class WebhookProfileTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookProfile
        {
            Url = "url",
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

        string expectedUrl = "url";
        WebhookAuthentication expectedAuthentication = new()
        {
            Mode = WebhookAuthMode.None,
            Token = "token",
            Password = "password",
            Username = "username",
        };
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        ApiEnum<string, WebhookMethod> expectedMethod = WebhookMethod.Post;
        ApiEnum<string, WebhookProfileType> expectedProfile = WebhookProfileType.Limited;

        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedAuthentication, model.Authentication);
        Assert.NotNull(model.Headers);
        Assert.Equal(expectedHeaders.Count, model.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(model.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Headers[item.Key]);
        }
        Assert.Equal(expectedMethod, model.Method);
        Assert.Equal(expectedProfile, model.Profile);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookProfile
        {
            Url = "url",
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<WebhookProfile>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookProfile
        {
            Url = "url",
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

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<WebhookProfile>(element);
        Assert.NotNull(deserialized);

        string expectedUrl = "url";
        WebhookAuthentication expectedAuthentication = new()
        {
            Mode = WebhookAuthMode.None,
            Token = "token",
            Password = "password",
            Username = "username",
        };
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        ApiEnum<string, WebhookMethod> expectedMethod = WebhookMethod.Post;
        ApiEnum<string, WebhookProfileType> expectedProfile = WebhookProfileType.Limited;

        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedAuthentication, deserialized.Authentication);
        Assert.NotNull(deserialized.Headers);
        Assert.Equal(expectedHeaders.Count, deserialized.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(deserialized.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Headers[item.Key]);
        }
        Assert.Equal(expectedMethod, deserialized.Method);
        Assert.Equal(expectedProfile, deserialized.Profile);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookProfile
        {
            Url = "url",
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebhookProfile { Url = "url" };

        Assert.Null(model.Authentication);
        Assert.False(model.RawData.ContainsKey("authentication"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
        Assert.Null(model.Method);
        Assert.False(model.RawData.ContainsKey("method"));
        Assert.Null(model.Profile);
        Assert.False(model.RawData.ContainsKey("profile"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebhookProfile { Url = "url" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WebhookProfile
        {
            Url = "url",

            Authentication = null,
            Headers = null,
            Method = null,
            Profile = null,
        };

        Assert.Null(model.Authentication);
        Assert.True(model.RawData.ContainsKey("authentication"));
        Assert.Null(model.Headers);
        Assert.True(model.RawData.ContainsKey("headers"));
        Assert.Null(model.Method);
        Assert.True(model.RawData.ContainsKey("method"));
        Assert.Null(model.Profile);
        Assert.True(model.RawData.ContainsKey("profile"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebhookProfile
        {
            Url = "url",

            Authentication = null,
            Headers = null,
            Method = null,
            Profile = null,
        };

        model.Validate();
    }
}
