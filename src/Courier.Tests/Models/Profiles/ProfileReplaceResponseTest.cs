using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Profiles;

namespace Courier.Tests.Models.Profiles;

public class ProfileReplaceResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProfileReplaceResponse { Status = ProfileReplaceResponseStatus.Success };

        ApiEnum<string, ProfileReplaceResponseStatus> expectedStatus =
            ProfileReplaceResponseStatus.Success;

        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ProfileReplaceResponse { Status = ProfileReplaceResponseStatus.Success };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ProfileReplaceResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProfileReplaceResponse { Status = ProfileReplaceResponseStatus.Success };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ProfileReplaceResponse>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, ProfileReplaceResponseStatus> expectedStatus =
            ProfileReplaceResponseStatus.Success;

        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ProfileReplaceResponse { Status = ProfileReplaceResponseStatus.Success };

        model.Validate();
    }
}

public class ProfileReplaceResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(ProfileReplaceResponseStatus.Success)]
    public void Validation_Works(ProfileReplaceResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProfileReplaceResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ProfileReplaceResponseStatus>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProfileReplaceResponseStatus.Success)]
    public void SerializationRoundtrip_Works(ProfileReplaceResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProfileReplaceResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProfileReplaceResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ProfileReplaceResponseStatus>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProfileReplaceResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
