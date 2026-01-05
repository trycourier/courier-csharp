using Courier.Models.AuditEvents;

namespace Courier.Tests.Models.AuditEvents;

public class AuditEventRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AuditEventRetrieveParams { AuditEventID = "audit-event-id" };

        string expectedAuditEventID = "audit-event-id";

        Assert.Equal(expectedAuditEventID, parameters.AuditEventID);
    }
}
