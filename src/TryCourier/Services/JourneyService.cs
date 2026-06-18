using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Journeys;
using TryCourier.Services.Journeys;

namespace TryCourier.Services;

/// <inheritdoc/>
public sealed class JourneyService : IJourneyService
{
    readonly Lazy<IJourneyServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IJourneyServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public IJourneyService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new JourneyService(this._client.WithOptions(modifier));
    }

    public JourneyService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() => new JourneyServiceWithRawResponse(client.WithRawResponse));
        _templates = new(() => new TemplateService(client));
    }

    readonly Lazy<ITemplateService> _templates;
    public ITemplateService Templates
    {
        get { return _templates.Value; }
    }

    /// <inheritdoc/>
    public async Task<JourneyResponse> Create(
        JourneyCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<JourneyResponse> Retrieve(
        JourneyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<JourneyResponse> Retrieve(
        string templateID,
        JourneyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { TemplateID = templateID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<JourneysListResponse> List(
        JourneyListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Archive(
        JourneyArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Archive(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Archive(
        string templateID,
        JourneyArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Archive(parameters with { TemplateID = templateID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<JourneysInvokeResponse> Invoke(
        JourneyInvokeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Invoke(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<JourneysInvokeResponse> Invoke(
        string templateID,
        JourneyInvokeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Invoke(parameters with { TemplateID = templateID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<JourneyVersionsListResponse> ListVersions(
        JourneyListVersionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListVersions(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<JourneyVersionsListResponse> ListVersions(
        string templateID,
        JourneyListVersionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListVersions(parameters with { TemplateID = templateID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<JourneyResponse> Publish(
        JourneyPublishParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Publish(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<JourneyResponse> Publish(
        string templateID,
        JourneyPublishParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Publish(parameters with { TemplateID = templateID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<JourneyResponse> Replace(
        JourneyReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Replace(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<JourneyResponse> Replace(
        string templateID,
        JourneyReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Replace(parameters with { TemplateID = templateID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class JourneyServiceWithRawResponse : IJourneyServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public IJourneyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new JourneyServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public JourneyServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;

        _templates = new(() => new TemplateServiceWithRawResponse(client));
    }

    readonly Lazy<ITemplateServiceWithRawResponse> _templates;
    public ITemplateServiceWithRawResponse Templates
    {
        get { return _templates.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JourneyResponse>> Create(
        JourneyCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<JourneyCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var journeyResponse = await response
                    .Deserialize<JourneyResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    journeyResponse.Validate();
                }
                return journeyResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JourneyResponse>> Retrieve(
        JourneyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TemplateID == null)
        {
            throw new CourierInvalidDataException("'parameters.TemplateID' cannot be null");
        }

        HttpRequest<JourneyRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var journeyResponse = await response
                    .Deserialize<JourneyResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    journeyResponse.Validate();
                }
                return journeyResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<JourneyResponse>> Retrieve(
        string templateID,
        JourneyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { TemplateID = templateID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JourneysListResponse>> List(
        JourneyListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<JourneyListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var journeysListResponse = await response
                    .Deserialize<JourneysListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    journeysListResponse.Validate();
                }
                return journeysListResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Archive(
        JourneyArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TemplateID == null)
        {
            throw new CourierInvalidDataException("'parameters.TemplateID' cannot be null");
        }

        HttpRequest<JourneyArchiveParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Archive(
        string templateID,
        JourneyArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { TemplateID = templateID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JourneysInvokeResponse>> Invoke(
        JourneyInvokeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TemplateID == null)
        {
            throw new CourierInvalidDataException("'parameters.TemplateID' cannot be null");
        }

        HttpRequest<JourneyInvokeParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var journeysInvokeResponse = await response
                    .Deserialize<JourneysInvokeResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    journeysInvokeResponse.Validate();
                }
                return journeysInvokeResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<JourneysInvokeResponse>> Invoke(
        string templateID,
        JourneyInvokeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Invoke(parameters with { TemplateID = templateID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JourneyVersionsListResponse>> ListVersions(
        JourneyListVersionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TemplateID == null)
        {
            throw new CourierInvalidDataException("'parameters.TemplateID' cannot be null");
        }

        HttpRequest<JourneyListVersionsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var journeyVersionsListResponse = await response
                    .Deserialize<JourneyVersionsListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    journeyVersionsListResponse.Validate();
                }
                return journeyVersionsListResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<JourneyVersionsListResponse>> ListVersions(
        string templateID,
        JourneyListVersionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListVersions(parameters with { TemplateID = templateID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JourneyResponse>> Publish(
        JourneyPublishParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TemplateID == null)
        {
            throw new CourierInvalidDataException("'parameters.TemplateID' cannot be null");
        }

        HttpRequest<JourneyPublishParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var journeyResponse = await response
                    .Deserialize<JourneyResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    journeyResponse.Validate();
                }
                return journeyResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<JourneyResponse>> Publish(
        string templateID,
        JourneyPublishParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Publish(parameters with { TemplateID = templateID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JourneyResponse>> Replace(
        JourneyReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TemplateID == null)
        {
            throw new CourierInvalidDataException("'parameters.TemplateID' cannot be null");
        }

        HttpRequest<JourneyReplaceParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var journeyResponse = await response
                    .Deserialize<JourneyResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    journeyResponse.Validate();
                }
                return journeyResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<JourneyResponse>> Replace(
        string templateID,
        JourneyReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Replace(parameters with { TemplateID = templateID }, cancellationToken);
    }
}
