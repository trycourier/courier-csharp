using System.Text.Json;
using Courier.Core;
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ListSubscribeResponse>(json);
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
