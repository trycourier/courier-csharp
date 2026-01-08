using System;
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

    [Fact]
    public void Url_Works()
    {
        AuditEventRetrieveParams parameters = new() { AuditEventID = "audit-event-id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/audit-events/audit-event-id"), url);
    }
}
