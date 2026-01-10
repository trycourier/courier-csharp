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
    readonly Lazy<IInvokeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInvokeServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public IInvokeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InvokeService(this._client.WithOptions(modifier));
    }

    public InvokeService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() => new InvokeServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<AutomationInvokeResponse> InvokeAdHoc(
        InvokeInvokeAdHocParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.InvokeAdHoc(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AutomationInvokeResponse> InvokeByTemplate(
        InvokeInvokeByTemplateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.InvokeByTemplate(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AutomationInvokeResponse> InvokeByTemplate(
        string templateID,
        InvokeInvokeByTemplateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.InvokeByTemplate(
            parameters with
            {
                TemplateID = templateID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class InvokeServiceWithRawResponse : IInvokeServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInvokeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InvokeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InvokeServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AutomationInvokeResponse>> InvokeAdHoc(
        InvokeInvokeAdHocParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<InvokeInvokeAdHocParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var automationInvokeResponse = await response
                    .Deserialize<AutomationInvokeResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    automationInvokeResponse.Validate();
                }
                return automationInvokeResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AutomationInvokeResponse>> InvokeByTemplate(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var automationInvokeResponse = await response
                    .Deserialize<AutomationInvokeResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    automationInvokeResponse.Validate();
                }
                return automationInvokeResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AutomationInvokeResponse>> InvokeByTemplate(
        string templateID,
        InvokeInvokeByTemplateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.InvokeByTemplate(
            parameters with
            {
                TemplateID = templateID,
            },
            cancellationToken
        );
    }
}
