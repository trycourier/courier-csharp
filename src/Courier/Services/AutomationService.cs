using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Automations;
using Courier.Services.Automations;

namespace Courier.Services;

/// <inheritdoc/>
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

    /// <inheritdoc/>
    public async Task<AutomationTemplateListResponse> List(
        AutomationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AutomationListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var automationTemplateListResponse = await response
            .Deserialize<AutomationTemplateListResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            automationTemplateListResponse.Validate();
        }
        return automationTemplateListResponse;
    }
}
