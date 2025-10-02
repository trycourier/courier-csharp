using System.Threading.Tasks;
using Courier.Models.Automations.Invoke.InvokeInvokeAdHocParamsProperties.AutomationProperties.StepProperties;
using Courier.Models.Automations.Invoke.InvokeInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationAddToDigestStepProperties.IntersectionMember1Properties;

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
                        new AutomationAddToDigestStep()
                        {
                            If = "if",
                            Ref = "ref",
                            Action = Action.AddToDigest,
                            SubscriptionTopicID = "RAJE97CMT04KDJJ88ZDS2TP1690S",
                        },
                    ],
                    CancelationToken = "cancelation_token",
                },
            }
        );
        automationInvokeResponse.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task InvokeByTemplate_Works()
    {
        var automationInvokeResponse = await this.client.Automations.Invoke.InvokeByTemplate(
            new() { TemplateID = "templateId" }
        );
        automationInvokeResponse.Validate();
    }
}
