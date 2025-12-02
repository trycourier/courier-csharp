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
}
