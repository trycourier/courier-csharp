using System;
using Courier.Core;
using Courier.Services.Automations;

namespace Courier.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAutomationService
{
    IAutomationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IInvokeService Invoke { get; }
}
