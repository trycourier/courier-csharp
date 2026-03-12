using System.Threading.Tasks;

namespace Courier.Tests.Services;

public class AuditEventServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var auditEvent = await this.client.AuditEvents.Retrieve(
            "audit-event-id",
            new(),
            TestContext.Current.CancellationToken
        );
        auditEvent.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var auditEvents = await this.client.AuditEvents.List(
            new(),
            TestContext.Current.CancellationToken
        );
        auditEvents.Validate();
    }
}
