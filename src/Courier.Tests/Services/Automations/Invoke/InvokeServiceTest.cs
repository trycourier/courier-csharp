using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Courier.Models.Automations.Invoke;

namespace Courier.Tests.Services.Automations.Invoke;

public class InvokeServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task InvokeAdHoc_Works()
    {
        var automationInvokeResponse = await this.client.Automations.Invoke.InvokeAdHoc(
            new()
            {
                Automation = new()
                {
                    Steps =
                    [
                        new AutomationDelayStep()
                        {
                            Action = Action.Delay,
                            Duration = "duration",
                            Until = "20240408T080910.123",
                        },
                        new AutomationSendStep()
                        {
                            Action = ActionModel.Send,
                            Brand = "brand",
                            Data = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Profile = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Recipient = "recipient",
                            Template = "64TP5HKPFTM8VTK1Y75SJDQX9JK0",
                        },
                    ],
                    CancelationToken = "delay-send--user-yes--abc-123",
                },
            }
        );
        automationInvokeResponse.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task InvokeByTemplate_Works()
    {
        var automationInvokeResponse = await this.client.Automations.Invoke.InvokeByTemplate(
            new() { TemplateID = "templateId", Recipient = "recipient" }
        );
        automationInvokeResponse.Validate();
    }
}
