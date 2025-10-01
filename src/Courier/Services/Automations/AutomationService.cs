using System;
using System.Net.Http;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Automations;
using Courier.Models.Automations.Invoke;
using Courier.Services.Automations.Invoke;

namespace Courier.Services.Automations;

public sealed class AutomationService : IAutomationService
{
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

    public async Task<AutomationInvokeResponse> InvokeAdHoc(AutomationInvokeAdHocParams parameters)
    {
        HttpRequest<AutomationInvokeAdHocParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<AutomationInvokeResponse>().ConfigureAwait(false);
    }

    public async Task<AutomationInvokeResponse> InvokeByTemplate(
        AutomationInvokeByTemplateParams parameters
    )
    {
        HttpRequest<AutomationInvokeByTemplateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<AutomationInvokeResponse>().ConfigureAwait(false);
    }
}
