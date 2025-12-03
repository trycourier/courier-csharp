using System.Text.Json;
using Courier.Core;
using Courier.Models.Notifications;

namespace Courier.Tests.Models.Notifications;

public class CheckTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Check
        {
            ID = "id",
            Status = Status.Resolved,
            Type = Type.Custom,
            Updated = 0,
        };

        string expectedID = "id";
        ApiEnum<string, Status> expectedStatus = Status.Resolved;
        ApiEnum<string, Type> expectedType = Type.Custom;
        long expectedUpdated = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUpdated, model.Updated);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Check
        {
            ID = "id",
            Status = Status.Resolved,
            Type = Type.Custom,
            Updated = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Check>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Check
        {
            ID = "id",
            Status = Status.Resolved,
            Type = Type.Custom,
            Updated = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Check>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, Status> expectedStatus = Status.Resolved;
        ApiEnum<string, Type> expectedType = Type.Custom;
        long expectedUpdated = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUpdated, deserialized.Updated);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Check
        {
            ID = "id",
            Status = Status.Resolved,
            Type = Type.Custom,
            Updated = 0,
        };

        model.Validate();
    }
}

public class IntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntersectionMember1 { Updated = 0 };

        long expectedUpdated = 0;

        Assert.Equal(expectedUpdated, model.Updated);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new IntersectionMember1 { Updated = 0 };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<IntersectionMember1>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntersectionMember1 { Updated = 0 };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<IntersectionMember1>(json);
        Assert.NotNull(deserialized);

        long expectedUpdated = 0;

        Assert.Equal(expectedUpdated, deserialized.Updated);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new IntersectionMember1 { Updated = 0 };

        model.Validate();
    }
}
