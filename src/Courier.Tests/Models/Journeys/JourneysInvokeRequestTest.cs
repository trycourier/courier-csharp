using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models.Journeys;

namespace Courier.Tests.Models.Journeys;

public class JourneysInvokeRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JourneysInvokeRequest
        {
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Profile = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            UserID = "user_id",
        };

        Dictionary<string, JsonElement> expectedData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        Dictionary<string, JsonElement> expectedProfile = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedUserID = "user_id";

        Assert.NotNull(model.Data);
        Assert.Equal(expectedData.Count, model.Data.Count);
        foreach (var item in expectedData)
        {
            Assert.True(model.Data.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Data[item.Key]));
        }
        Assert.NotNull(model.Profile);
        Assert.Equal(expectedProfile.Count, model.Profile.Count);
        foreach (var item in expectedProfile)
        {
            Assert.True(model.Profile.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Profile[item.Key]));
        }
        Assert.Equal(expectedUserID, model.UserID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JourneysInvokeRequest
        {
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Profile = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            UserID = "user_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneysInvokeRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JourneysInvokeRequest
        {
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Profile = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            UserID = "user_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneysInvokeRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Dictionary<string, JsonElement> expectedData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        Dictionary<string, JsonElement> expectedProfile = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedUserID = "user_id";

        Assert.NotNull(deserialized.Data);
        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        foreach (var item in expectedData)
        {
            Assert.True(deserialized.Data.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Data[item.Key]));
        }
        Assert.NotNull(deserialized.Profile);
        Assert.Equal(expectedProfile.Count, deserialized.Profile.Count);
        foreach (var item in expectedProfile)
        {
            Assert.True(deserialized.Profile.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Profile[item.Key]));
        }
        Assert.Equal(expectedUserID, deserialized.UserID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JourneysInvokeRequest
        {
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Profile = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            UserID = "user_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JourneysInvokeRequest { };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Profile);
        Assert.False(model.RawData.ContainsKey("profile"));
        Assert.Null(model.UserID);
        Assert.False(model.RawData.ContainsKey("user_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new JourneysInvokeRequest { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new JourneysInvokeRequest
        {
            // Null should be interpreted as omitted for these properties
            Data = null,
            Profile = null,
            UserID = null,
        };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Profile);
        Assert.False(model.RawData.ContainsKey("profile"));
        Assert.Null(model.UserID);
        Assert.False(model.RawData.ContainsKey("user_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new JourneysInvokeRequest
        {
            // Null should be interpreted as omitted for these properties
            Data = null,
            Profile = null,
            UserID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JourneysInvokeRequest
        {
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Profile = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            UserID = "user_id",
        };

        JourneysInvokeRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}
