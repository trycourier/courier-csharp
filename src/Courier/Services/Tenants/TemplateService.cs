using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Tenants;
using Courier.Models.Tenants.Templates;

namespace Courier.Services.Tenants;

/// <inheritdoc/>
public sealed class TemplateService : ITemplateService
{
    readonly Lazy<ITemplateServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITemplateServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public ITemplateService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TemplateService(this._client.WithOptions(modifier));
    }

    public TemplateService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() => new TemplateServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<BaseTemplateTenantAssociation> Retrieve(
        TemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BaseTemplateTenantAssociation> Retrieve(
        string templateID,
        TemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { TemplateID = templateID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TemplateListResponse> List(
        TemplateListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TemplateListResponse> List(
        string tenantID,
        TemplateListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { TenantID = tenantID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class TemplateServiceWithRawResponse : ITemplateServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITemplateServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TemplateServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TemplateServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BaseTemplateTenantAssociation>> Retrieve(
        TemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TemplateID == null)
        {
            throw new CourierInvalidDataException("'parameters.TemplateID' cannot be null");
        }

        HttpRequest<TemplateRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var baseTemplateTenantAssociation = await response
                    .Deserialize<BaseTemplateTenantAssociation>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    baseTemplateTenantAssociation.Validate();
                }
                return baseTemplateTenantAssociation;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BaseTemplateTenantAssociation>> Retrieve(
        string templateID,
        TemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { TemplateID = templateID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TemplateListResponse>> List(
        TemplateListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TenantID == null)
        {
            throw new CourierInvalidDataException("'parameters.TenantID' cannot be null");
        }

        HttpRequest<TemplateListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var templates = await response
                    .Deserialize<TemplateListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    templates.Validate();
                }
                return templates;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<TemplateListResponse>> List(
        string tenantID,
        TemplateListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { TenantID = tenantID }, cancellationToken);
    }
}
