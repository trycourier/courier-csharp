using System.Net.Http;
using System.Text.Json;
using Courier.Client;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public class AutomationsClient
{
    private RawClient _client;

    public AutomationsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Invoke an automation run from an automation template.
    /// </summary>
    public async Task<AutomationInvokeResponse> InvokeAutomationTemplateAsync(
        string templateId,
        AutomationInvokeParams request
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Post,
                Path = $"/automations/{templateId}/invoke",
                Body = request
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<AutomationInvokeResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }

    /// <summary>
    /// Invoke an ad hoc automation run. This endpoint accepts a JSON payload with a series of automation steps. For information about what steps are available, checkout the ad hoc automation guide [here](https://www.courier.com/docs/automations/steps/).
    /// </summary>
    public async Task<AutomationInvokeResponse> InvokeAdHocAutomationAsync(
        AutomationAdHocInvokeParams request
    )
    {
        var response = await _client.MakeRequestAsync(
            new RawClient.JsonApiRequest
            {
                Method = HttpMethod.Post,
                Path = "/automations/invoke",
                Body = request
            }
        );
        var responseBody = await response.Raw.Content.ReadAsStringAsync();
        if (response.StatusCode is >= 200 and < 400)
        {
            return JsonSerializer.Deserialize<AutomationInvokeResponse>(responseBody)!;
        }
        throw new Exception(responseBody);
    }
}
