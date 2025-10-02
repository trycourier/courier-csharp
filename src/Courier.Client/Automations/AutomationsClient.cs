using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Courier.Client.Core;

namespace Courier.Client;

public partial class AutomationsClient
{
    private RawClient _client;

    internal AutomationsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Invoke an automation run from an automation template.
    /// </summary>
    /// <example><code>
    /// await client.Automations.InvokeAutomationTemplateAsync(
    ///     "templateId",
    ///     new AutomationInvokeParams
    ///     {
    ///         Brand = null,
    ///         Data = null,
    ///         Profile = null,
    ///         Recipient = null,
    ///         Template = null,
    ///     }
    /// );
    /// </code></example>
    public async Task<AutomationInvokeResponse> InvokeAutomationTemplateAsync(
        string templateId,
        AutomationInvokeParams request,
        IdempotentRequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "/automations/{0}/invoke",
                        ValueConvert.ToPathParameterString(templateId)
                    ),
                    Body = request,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<AutomationInvokeResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new CourierException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new CourierApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Invoke an ad hoc automation run. This endpoint accepts a JSON payload with a series of automation steps. For information about what steps are available, checkout the ad hoc automation guide [here](https://www.courier.com/docs/automations/steps/).
    /// </summary>
    /// <example><code>
    /// await client.Automations.InvokeAdHocAutomationAsync(
    ///     new AutomationAdHocInvokeParams
    ///     {
    ///         Data = new Dictionary&lt;string, object&gt;() { { "name", "Foo" } },
    ///         Profile = new Dictionary&lt;object, object?&gt;() { { "tenant_id", "abc-123" } },
    ///         Recipient = "user-yes",
    ///         Automation = new Automation
    ///         {
    ///             CancelationToken = "delay-send--user-yes--abc-123",
    ///             Steps = new List&lt;
    ///                 OneOf&lt;
    ///                     AutomationAddToDigestStep,
    ///                     AutomationAddToBatchStep,
    ///                     AutomationThrottleStep,
    ///                     AutomationCancelStep,
    ///                     AutomationDelayStep,
    ///                     AutomationFetchDataStep,
    ///                     AutomationInvokeStep,
    ///                     AutomationSendStep,
    ///                     AutomationV2SendStep,
    ///                     AutomationSendListStep,
    ///                     AutomationUpdateProfileStep
    ///                 &gt;
    ///             &gt;()
    ///             {
    ///                 new AutomationDelayStep { Action = "delay", Until = "20240408T080910.123" },
    ///                 new AutomationSendStep
    ///                 {
    ///                     Action = "send",
    ///                     Template = "64TP5HKPFTM8VTK1Y75SJDQX9JK0",
    ///                 },
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<AutomationInvokeResponse> InvokeAdHocAutomationAsync(
        AutomationAdHocInvokeParams request,
        IdempotentRequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "/automations/invoke",
                    Body = request,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<AutomationInvokeResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new CourierException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new CourierApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }
}
