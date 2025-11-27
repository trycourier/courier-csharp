using System;
using Courier.Core;
using Courier.Services.Automations;

namespace Courier.Services;

/// <inheritdoc />
public sealed class AutomationService : IAutomationService
{
    /// <inheritdoc/>
    public IAutomationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AutomationService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public AutomationService(ICourierClient client)
    {
        _client = client;
        _invoke = new(() => new InvokeService(client));
    }

    readonly Lazy<IInvokeService> _invoke;
    public IInvokeService Invoke
    {
        get { return _invoke.Value; }
    }
}
