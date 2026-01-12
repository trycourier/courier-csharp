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
    readonly Lazy<IAutomationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAutomationServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public IAutomationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AutomationService(this._client.WithOptions(modifier));
    }

    public AutomationService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AutomationServiceWithRawResponse(client.WithRawResponse));
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
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class AutomationServiceWithRawResponse : IAutomationServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAutomationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AutomationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AutomationServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;

        _invoke = new(() => new InvokeServiceWithRawResponse(client));
    }

    readonly Lazy<IInvokeServiceWithRawResponse> _invoke;
    public IInvokeServiceWithRawResponse Invoke
    {
        get { return _invoke.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AutomationTemplateListResponse>> List(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var automationTemplateListResponse = await response
                    .Deserialize<AutomationTemplateListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    automationTemplateListResponse.Validate();
                }
                return automationTemplateListResponse;
            }
        );
    }
}
