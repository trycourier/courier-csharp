using System;
using Courier.Services.Automations.Invoke;

namespace Courier.Services.Automations;

public sealed class AutomationService : IAutomationService
{
    public AutomationService(ICourierClient client)
    {
        _invoke = new(() => new InvokeService(client));
    }

    readonly Lazy<IInvokeService> _invoke;
    public IInvokeService Invoke
    {
        get { return _invoke.Value; }
    }
}
