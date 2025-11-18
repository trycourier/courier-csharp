using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Automations;
using Courier.Models.Automations.Invoke;

namespace Courier.Services.Automations;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IInvokeService
{
    IInvokeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Invoke an ad hoc automation run. This endpoint accepts a JSON payload with
    /// a series of automation steps. For information about what steps are available,
    /// checkout the ad hoc automation guide [here](https://www.courier.com/docs/automations/steps/).
    /// </summary>
    Task<AutomationInvokeResponse> InvokeAdHoc(
        InvokeInvokeAdHocParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Invoke an automation run from an automation template.
    /// </summary>
    Task<AutomationInvokeResponse> InvokeByTemplate(
        InvokeInvokeByTemplateParams parameters,
        CancellationToken cancellationToken = default
    );
}
