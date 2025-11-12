using System.Threading.Tasks;

namespace Courier.Tests.Services;

public class AuditEventServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var auditEvent = await this.client.AuditEvents.Retrieve(
            new() { AuditEventID = "audit-event-id" }
        );
        auditEvent.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var auditEvents = await this.client.AuditEvents.List();
        auditEvents.Validate();
    }
}
