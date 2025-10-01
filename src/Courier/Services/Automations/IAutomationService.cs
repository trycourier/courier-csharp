using System.Threading.Tasks;
using Courier.Models.Automations;
using Courier.Models.Automations.Invoke;
using Courier.Services.Automations.Invoke;

namespace Courier.Services.Automations;

public interface IAutomationService
{
    IInvokeService Invoke { get; }

    /// <summary>
    /// Invoke an ad hoc automation run. This endpoint accepts a JSON payload with
    /// a series of automation steps. For information about what steps are available,
    /// checkout the ad hoc automation guide [here](https://www.courier.com/docs/automations/steps/).
    /// </summary>
    Task<AutomationInvokeResponse> InvokeAdHoc(AutomationInvokeAdHocParams parameters);

    /// <summary>
    /// Invoke an automation run from an automation template.
    /// </summary>
    Task<AutomationInvokeResponse> InvokeByTemplate(AutomationInvokeByTemplateParams parameters);
}
