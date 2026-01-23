using System.Text.Json;
using Courier.Core;
using Courier.Models.AuditEvents;

namespace Courier.Tests.Models.AuditEvents;

public class AuditEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AuditEvent
        {
            Actor = new() { ID = "id", Email = "email" },
            AuditEventID = "auditEventId",
            Source = "source",
            Target = "target",
            Timestamp = "timestamp",
            Type = "type",
        };

        Actor expectedActor = new() { ID = "id", Email = "email" };
        string expectedAuditEventID = "auditEventId";
        string expectedSource = "source";
        string expectedTarget = "target";
        string expectedTimestamp = "timestamp";
        string expectedType = "type";

        Assert.Equal(expectedActor, model.Actor);
        Assert.Equal(expectedAuditEventID, model.AuditEventID);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedTarget, model.Target);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AuditEvent
        {
            Actor = new() { ID = "id", Email = "email" },
            AuditEventID = "auditEventId",
            Source = "source",
            Target = "target",
            Timestamp = "timestamp",
            Type = "type",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AuditEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AuditEvent
        {
            Actor = new() { ID = "id", Email = "email" },
            AuditEventID = "auditEventId",
            Source = "source",
            Target = "target",
            Timestamp = "timestamp",
            Type = "type",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AuditEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Actor expectedActor = new() { ID = "id", Email = "email" };
        string expectedAuditEventID = "auditEventId";
        string expectedSource = "source";
        string expectedTarget = "target";
        string expectedTimestamp = "timestamp";
        string expectedType = "type";

        Assert.Equal(expectedActor, deserialized.Actor);
        Assert.Equal(expectedAuditEventID, deserialized.AuditEventID);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedTarget, deserialized.Target);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AuditEvent
        {
            Actor = new() { ID = "id", Email = "email" },
            AuditEventID = "auditEventId",
            Source = "source",
            Target = "target",
            Timestamp = "timestamp",
            Type = "type",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AuditEvent
        {
            Actor = new() { ID = "id", Email = "email" },
            AuditEventID = "auditEventId",
            Source = "source",
            Target = "target",
            Timestamp = "timestamp",
            Type = "type",
        };

        AuditEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ActorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Actor { ID = "id", Email = "email" };

        string expectedID = "id";
        string expectedEmail = "email";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedEmail, model.Email);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Actor { ID = "id", Email = "email" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Actor>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Actor { ID = "id", Email = "email" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Actor>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedEmail = "email";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedEmail, deserialized.Email);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Actor { ID = "id", Email = "email" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Actor { ID = "id" };

        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Actor { ID = "id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Actor
        {
            ID = "id",

            Email = null,
        };

        Assert.Null(model.Email);
        Assert.True(model.RawData.ContainsKey("email"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Actor
        {
            ID = "id",

            Email = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Actor { ID = "id", Email = "email" };

        Actor copied = new(model);

        Assert.Equal(model, copied);
    }
}
