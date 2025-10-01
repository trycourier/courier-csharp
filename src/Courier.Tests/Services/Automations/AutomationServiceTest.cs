using System.Threading.Tasks;
using Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepProperties;
using Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationAddToDigestStepProperties.IntersectionMember1Properties;

namespace Courier.Tests.Services.Automations;

public class AutomationServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task InvokeAdHoc_Works()
    {
        var automationInvokeResponse = await this.client.Automations.InvokeAdHoc(
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
        var automationInvokeResponse = await this.client.Automations.InvokeByTemplate(
            new() { TemplateID = "templateId" }
        );
        automationInvokeResponse.Validate();
    }
}
