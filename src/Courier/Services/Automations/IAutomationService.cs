using System;
using Courier.Core;
using Courier.Services.Automations.Invoke;

namespace Courier.Services.Automations;

public interface IAutomationService
{
    IAutomationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IInvokeService Invoke { get; }
}
