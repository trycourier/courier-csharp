using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Profiles.Lists;

namespace Courier.Tests.Models.Profiles.Lists;

public class ListSubscribeResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ListSubscribeResponse { Status = ListSubscribeResponseStatus.Success };

        ApiEnum<string, ListSubscribeResponseStatus> expectedStatus =
            ListSubscribeResponseStatus.Success;

        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ListSubscribeResponse { Status = ListSubscribeResponseStatus.Success };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ListSubscribeResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ListSubscribeResponse { Status = ListSubscribeResponseStatus.Success };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ListSubscribeResponse>(element);
        Assert.NotNull(deserialized);

        ApiEnum<string, ListSubscribeResponseStatus> expectedStatus =
            ListSubscribeResponseStatus.Success;

        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ListSubscribeResponse { Status = ListSubscribeResponseStatus.Success };

        model.Validate();
    }
}

public class ListSubscribeResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(ListSubscribeResponseStatus.Success)]
    public void Validation_Works(ListSubscribeResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ListSubscribeResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ListSubscribeResponseStatus>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ListSubscribeResponseStatus.Success)]
    public void SerializationRoundtrip_Works(ListSubscribeResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ListSubscribeResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ListSubscribeResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ListSubscribeResponseStatus>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ListSubscribeResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
