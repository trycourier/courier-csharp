using System.Net.Http;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Automations;
using Courier.Models.Automations.Invoke;

namespace Courier.Services.Automations.Invoke;

public sealed class InvokeService : IInvokeService
{
    readonly ICourierClient _client;

    public InvokeService(ICourierClient client)
    {
        _client = client;
    }

    public async Task<AutomationInvokeResponse> InvokeAdHoc(InvokeInvokeAdHocParams parameters)
    {
        HttpRequest<InvokeInvokeAdHocParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var automationInvokeResponse = await response
            .Deserialize<AutomationInvokeResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            automationInvokeResponse.Validate();
        }
        return automationInvokeResponse;
    }

    public async Task<AutomationInvokeResponse> InvokeByTemplate(
        InvokeInvokeByTemplateParams parameters
    )
    {
        HttpRequest<InvokeInvokeByTemplateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var automationInvokeResponse = await response
            .Deserialize<AutomationInvokeResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            automationInvokeResponse.Validate();
        }
        return automationInvokeResponse;
    }
}
