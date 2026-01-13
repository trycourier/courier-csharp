using System;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Automations = Courier.Models.Automations;

namespace Courier.Tests.Models.Automations;

public class AutomationListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Automations::AutomationListParams
        {
            Cursor = "cursor",
            Version = Automations::Version.Published,
        };

        string expectedCursor = "cursor";
        ApiEnum<string, Automations::Version> expectedVersion = Automations::Version.Published;

        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedVersion, parameters.Version);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Automations::AutomationListParams { };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Version);
        Assert.False(parameters.RawQueryData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Automations::AutomationListParams
        {
            // Null should be interpreted as omitted for these properties
            Cursor = null,
            Version = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Version);
        Assert.False(parameters.RawQueryData.ContainsKey("version"));
    }

    [Fact]
    public void Url_Works()
    {
        Automations::AutomationListParams parameters = new()
        {
            Cursor = "cursor",
            Version = Automations::Version.Published,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.courier.com/automations?cursor=cursor&version=published"),
            url
        );
    }
}

public class VersionTest : TestBase
{
    [Theory]
    [InlineData(Automations::Version.Published)]
    [InlineData(Automations::Version.Draft)]
    public void Validation_Works(Automations::Version rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Automations::Version> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Automations::Version>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Automations::Version.Published)]
    [InlineData(Automations::Version.Draft)]
    public void SerializationRoundtrip_Works(Automations::Version rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Automations::Version> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Automations::Version>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Automations::Version>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Automations::Version>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
