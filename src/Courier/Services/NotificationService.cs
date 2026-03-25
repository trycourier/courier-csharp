using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Notifications;
using Courier.Services.Notifications;

namespace Courier.Services;

/// <inheritdoc/>
public sealed class NotificationService : INotificationService
{
    readonly Lazy<INotificationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public INotificationServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public INotificationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new NotificationService(this._client.WithOptions(modifier));
    }

    public NotificationService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new NotificationServiceWithRawResponse(client.WithRawResponse)
        );
        _draft = new(() => new DraftService(client));
        _checks = new(() => new CheckService(client));
    }

    readonly Lazy<IDraftService> _draft;
    public IDraftService Draft
    {
        get { return _draft.Value; }
    }

    readonly Lazy<ICheckService> _checks;
    public ICheckService Checks
    {
        get { return _checks.Value; }
    }

    /// <inheritdoc/>
    public async Task<NotificationTemplateMutationResponse> Create(
        NotificationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<NotificationTemplateGetResponse> Retrieve(
        NotificationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<NotificationTemplateGetResponse> Retrieve(
        string id,
        NotificationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<NotificationListResponse> List(
        NotificationListParams? parameters = null,
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
        NotificationArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Archive(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Archive(
        string id,
        NotificationArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Archive(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Publish(
        NotificationPublishParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Publish(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Publish(
        string id,
        NotificationPublishParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Publish(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<NotificationTemplateMutationResponse> Replace(
        NotificationReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Replace(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<NotificationTemplateMutationResponse> Replace(
        string id,
        NotificationReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Replace(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<NotificationGetContent> RetrieveContent(
        NotificationRetrieveContentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveContent(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<NotificationGetContent> RetrieveContent(
        string id,
        NotificationRetrieveContentParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveContent(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class NotificationServiceWithRawResponse : INotificationServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public INotificationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new NotificationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public NotificationServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;

        _draft = new(() => new DraftServiceWithRawResponse(client));
        _checks = new(() => new CheckServiceWithRawResponse(client));
    }

    readonly Lazy<IDraftServiceWithRawResponse> _draft;
    public IDraftServiceWithRawResponse Draft
    {
        get { return _draft.Value; }
    }

    readonly Lazy<ICheckServiceWithRawResponse> _checks;
    public ICheckServiceWithRawResponse Checks
    {
        get { return _checks.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NotificationTemplateMutationResponse>> Create(
        NotificationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<NotificationCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var notificationTemplateMutationResponse = await response
                    .Deserialize<NotificationTemplateMutationResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    notificationTemplateMutationResponse.Validate();
                }
                return notificationTemplateMutationResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NotificationTemplateGetResponse>> Retrieve(
        NotificationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CourierInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<NotificationRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var notificationTemplateGetResponse = await response
                    .Deserialize<NotificationTemplateGetResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    notificationTemplateGetResponse.Validate();
                }
                return notificationTemplateGetResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<NotificationTemplateGetResponse>> Retrieve(
        string id,
        NotificationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NotificationListResponse>> List(
        NotificationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<NotificationListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var notifications = await response
                    .Deserialize<NotificationListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    notifications.Validate();
                }
                return notifications;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Archive(
        NotificationArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CourierInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<NotificationArchiveParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Archive(
        string id,
        NotificationArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Publish(
        NotificationPublishParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CourierInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<NotificationPublishParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Publish(
        string id,
        NotificationPublishParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Publish(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NotificationTemplateMutationResponse>> Replace(
        NotificationReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CourierInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<NotificationReplaceParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var notificationTemplateMutationResponse = await response
                    .Deserialize<NotificationTemplateMutationResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    notificationTemplateMutationResponse.Validate();
                }
                return notificationTemplateMutationResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<NotificationTemplateMutationResponse>> Replace(
        string id,
        NotificationReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Replace(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NotificationGetContent>> RetrieveContent(
        NotificationRetrieveContentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CourierInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<NotificationRetrieveContentParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var notificationGetContent = await response
                    .Deserialize<NotificationGetContent>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    notificationGetContent.Validate();
                }
                return notificationGetContent;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<NotificationGetContent>> RetrieveContent(
        string id,
        NotificationRetrieveContentParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveContent(parameters with { ID = id }, cancellationToken);
    }
}
