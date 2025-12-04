using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Automations;
using Courier.Models.Automations.Invoke;

namespace Courier.Services.Automations;

/// <inheritdoc/>
public sealed class InvokeService : IInvokeService
{
    /// <inheritdoc/>
    public IInvokeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InvokeService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public InvokeService(ICourierClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<AutomationInvokeResponse> InvokeAdHoc(
        InvokeInvokeAdHocParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<InvokeInvokeAdHocParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var automationInvokeResponse = await response
            .Deserialize<AutomationInvokeResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            automationInvokeResponse.Validate();
        }
        return automationInvokeResponse;
    }

    /// <inheritdoc/>
    public async Task<AutomationInvokeResponse> InvokeByTemplate(
        InvokeInvokeByTemplateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TemplateID == null)
        {
            throw new CourierInvalidDataException("'parameters.TemplateID' cannot be null");
        }

        HttpRequest<InvokeInvokeByTemplateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var automationInvokeResponse = await response
            .Deserialize<AutomationInvokeResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            automationInvokeResponse.Validate();
        }
        return automationInvokeResponse;
    }

    /// <inheritdoc/>
    public async Task<AutomationInvokeResponse> InvokeByTemplate(
        string templateID,
        InvokeInvokeByTemplateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.InvokeByTemplate(
            parameters with
            {
                TemplateID = templateID,
            },
            cancellationToken
        );
    }
}
