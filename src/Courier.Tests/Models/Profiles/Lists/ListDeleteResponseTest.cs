using System.Text.Json;
using Courier.Core;
using Courier.Models.Profiles.Lists;

namespace Courier.Tests.Models.Profiles.Lists;

public class ListDeleteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ListDeleteResponse { Status = Status.Success };

        ApiEnum<string, Status> expectedStatus = Status.Success;

        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ListDeleteResponse { Status = Status.Success };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ListDeleteResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ListDeleteResponse { Status = Status.Success };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ListDeleteResponse>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, Status> expectedStatus = Status.Success;

        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ListDeleteResponse { Status = Status.Success };

        model.Validate();
    }
}
