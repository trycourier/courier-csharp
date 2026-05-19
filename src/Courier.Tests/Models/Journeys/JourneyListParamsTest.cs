using System;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Journeys = Courier.Models.Journeys;

namespace Courier.Tests.Models.Journeys;

public class JourneyListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Journeys::JourneyListParams
        {
            Cursor = "cursor",
            Version = Journeys::Version.Published,
        };

        string expectedCursor = "cursor";
        ApiEnum<string, Journeys::Version> expectedVersion = Journeys::Version.Published;

        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedVersion, parameters.Version);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Journeys::JourneyListParams { };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Version);
        Assert.False(parameters.RawQueryData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Journeys::JourneyListParams
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
        Journeys::JourneyListParams parameters = new()
        {
            Cursor = "cursor",
            Version = Journeys::Version.Published,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.courier.com/journeys?cursor=cursor&version=published"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Journeys::JourneyListParams
        {
            Cursor = "cursor",
            Version = Journeys::Version.Published,
        };

        Journeys::JourneyListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class VersionTest : TestBase
{
    [Theory]
    [InlineData(Journeys::Version.Published)]
    [InlineData(Journeys::Version.Draft)]
    public void Validation_Works(Journeys::Version rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Journeys::Version> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Journeys::Version>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Journeys::Version.Published)]
    [InlineData(Journeys::Version.Draft)]
    public void SerializationRoundtrip_Works(Journeys::Version rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Journeys::Version> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Journeys::Version>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Journeys::Version>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Journeys::Version>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
