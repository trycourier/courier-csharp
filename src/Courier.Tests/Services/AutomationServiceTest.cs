using System.Threading.Tasks;

namespace Courier.Tests.Services;

public class AutomationServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var automationTemplateListResponse = await this.client.Automations.List(
            new(),
            TestContext.Current.CancellationToken
        );
        automationTemplateListResponse.Validate();
    }
}
