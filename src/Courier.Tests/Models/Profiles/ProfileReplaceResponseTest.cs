using System.Text.Json;
using Courier.Core;
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
