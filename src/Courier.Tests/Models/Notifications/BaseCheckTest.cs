using System.Text.Json;
using Courier.Core;
using Courier.Models.Notifications;

namespace Courier.Tests.Models.Notifications;

public class BaseCheckTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BaseCheck
        {
            ID = "id",
            Status = Status.Resolved,
            Type = Type.Custom,
        };

        string expectedID = "id";
        ApiEnum<string, Status> expectedStatus = Status.Resolved;
        ApiEnum<string, Type> expectedType = Type.Custom;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BaseCheck
        {
            ID = "id",
            Status = Status.Resolved,
            Type = Type.Custom,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BaseCheck>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BaseCheck
        {
            ID = "id",
            Status = Status.Resolved,
            Type = Type.Custom,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BaseCheck>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, Status> expectedStatus = Status.Resolved;
        ApiEnum<string, Type> expectedType = Type.Custom;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BaseCheck
        {
            ID = "id",
            Status = Status.Resolved,
            Type = Type.Custom,
        };

        model.Validate();
    }
}
