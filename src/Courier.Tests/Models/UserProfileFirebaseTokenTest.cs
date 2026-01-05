using System.Text.Json;
using Courier.Models;

namespace Courier.Tests.Models;

public class UserProfileFirebaseTokenTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        UserProfileFirebaseToken value = new("string");
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
        UserProfileFirebaseToken value = new("string");
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<UserProfileFirebaseToken>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringsSerializationRoundtripWorks()
    {
        UserProfileFirebaseToken value = new(["string"]);
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<UserProfileFirebaseToken>(element);

        Assert.Equal(value, deserialized);
    }
}
