using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Journeys;
using TryCourier.Models.Journeys.Templates;
using TryCourier.Models.Notifications;

namespace TryCourier.Services.Journeys;

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
    public async Task<JourneyTemplateGetResponse> Create(
        TemplateCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<JourneyTemplateGetResponse> Create(
        string templateID,
        TemplateCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { TemplateID = templateID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<JourneyTemplateGetResponse> Retrieve(
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
    public Task<JourneyTemplateGetResponse> Retrieve(
        string notificationID,
        TemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(
            parameters with
            {
                NotificationID = notificationID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<JourneyTemplateListResponse> List(
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
    public Task<JourneyTemplateListResponse> List(
        string templateID,
        TemplateListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { TemplateID = templateID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Archive(
        TemplateArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Archive(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Archive(
        string notificationID,
        TemplateArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Archive(parameters with { NotificationID = notificationID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<NotificationTemplateVersionListResponse> ListVersions(
        TemplateListVersionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListVersions(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<NotificationTemplateVersionListResponse> ListVersions(
        string notificationID,
        TemplateListVersionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ListVersions(
            parameters with
            {
                NotificationID = notificationID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public Task Publish(
        TemplatePublishParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Publish(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Publish(
        string notificationID,
        TemplatePublishParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Publish(parameters with { NotificationID = notificationID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<JourneyTemplateGetResponse> Replace(
        TemplateReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Replace(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<JourneyTemplateGetResponse> Replace(
        string notificationID,
        TemplateReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Replace(parameters with { NotificationID = notificationID }, cancellationToken);
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
    public async Task<HttpResponse<JourneyTemplateGetResponse>> Create(
        TemplateCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TemplateID == null)
        {
            throw new CourierInvalidDataException("'parameters.TemplateID' cannot be null");
        }

        HttpRequest<TemplateCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var journeyTemplateGetResponse = await response
                    .Deserialize<JourneyTemplateGetResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    journeyTemplateGetResponse.Validate();
                }
                return journeyTemplateGetResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<JourneyTemplateGetResponse>> Create(
        string templateID,
        TemplateCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { TemplateID = templateID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JourneyTemplateGetResponse>> Retrieve(
        TemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.NotificationID == null)
        {
            throw new CourierInvalidDataException("'parameters.NotificationID' cannot be null");
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
                var journeyTemplateGetResponse = await response
                    .Deserialize<JourneyTemplateGetResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    journeyTemplateGetResponse.Validate();
                }
                return journeyTemplateGetResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<JourneyTemplateGetResponse>> Retrieve(
        string notificationID,
        TemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(
            parameters with
            {
                NotificationID = notificationID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JourneyTemplateListResponse>> List(
        TemplateListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TemplateID == null)
        {
            throw new CourierInvalidDataException("'parameters.TemplateID' cannot be null");
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
                var journeyTemplateListResponse = await response
                    .Deserialize<JourneyTemplateListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    journeyTemplateListResponse.Validate();
                }
                return journeyTemplateListResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<JourneyTemplateListResponse>> List(
        string templateID,
        TemplateListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { TemplateID = templateID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Archive(
        TemplateArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.NotificationID == null)
        {
            throw new CourierInvalidDataException("'parameters.NotificationID' cannot be null");
        }

        HttpRequest<TemplateArchiveParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Archive(
        string notificationID,
        TemplateArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Archive(parameters with { NotificationID = notificationID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NotificationTemplateVersionListResponse>> ListVersions(
        TemplateListVersionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.NotificationID == null)
        {
            throw new CourierInvalidDataException("'parameters.NotificationID' cannot be null");
        }

        HttpRequest<TemplateListVersionsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var notificationTemplateVersionListResponse = await response
                    .Deserialize<NotificationTemplateVersionListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    notificationTemplateVersionListResponse.Validate();
                }
                return notificationTemplateVersionListResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<NotificationTemplateVersionListResponse>> ListVersions(
        string notificationID,
        TemplateListVersionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ListVersions(
            parameters with
            {
                NotificationID = notificationID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Publish(
        TemplatePublishParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.NotificationID == null)
        {
            throw new CourierInvalidDataException("'parameters.NotificationID' cannot be null");
        }

        HttpRequest<TemplatePublishParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Publish(
        string notificationID,
        TemplatePublishParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Publish(parameters with { NotificationID = notificationID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JourneyTemplateGetResponse>> Replace(
        TemplateReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.NotificationID == null)
        {
            throw new CourierInvalidDataException("'parameters.NotificationID' cannot be null");
        }

        HttpRequest<TemplateReplaceParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var journeyTemplateGetResponse = await response
                    .Deserialize<JourneyTemplateGetResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    journeyTemplateGetResponse.Validate();
                }
                return journeyTemplateGetResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<JourneyTemplateGetResponse>> Replace(
        string notificationID,
        TemplateReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Replace(parameters with { NotificationID = notificationID }, cancellationToken);
    }
}
