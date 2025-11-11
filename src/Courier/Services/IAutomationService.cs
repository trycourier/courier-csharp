using System;
using Courier.Core;
using Courier.Services.Automations;

namespace Courier.Services;

public interface IAutomationService
{
    IAutomationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IInvokeService Invoke { get; }
}
