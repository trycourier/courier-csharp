using System.Text.Json;
using Courier.Core;
using Courier.Models;

namespace Courier.Tests.Models;

public class UserProfileFirebaseTokenTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        UserProfileFirebaseToken value = "string";
        value.Validate();
    }

    [Fact]
    public void StringsValidationWorks()
    {
        UserProfileFirebaseToken value = new(["string"]);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        UserProfileFirebaseToken value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserProfileFirebaseToken>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringsSerializationRoundtripWorks()
    {
        UserProfileFirebaseToken value = new(["string"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserProfileFirebaseToken>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
