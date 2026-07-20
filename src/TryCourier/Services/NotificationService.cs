using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Notifications;
using TryCourier.Services.Notifications;

namespace TryCourier.Services;

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
        _checks = new(() => new CheckService(client));
    }

    readonly Lazy<ICheckService> _checks;
    public ICheckService Checks
    {
        get { return _checks.Value; }
    }

    /// <inheritdoc/>
    public async Task<NotificationTemplateResponse> Create(
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
    public async Task<NotificationTemplateResponse> Retrieve(
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
    public Task<NotificationTemplateResponse> Retrieve(
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
    public async Task<NotificationTemplateResponse> Duplicate(
        NotificationDuplicateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Duplicate(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<NotificationTemplateResponse> Duplicate(
        string id,
        NotificationDuplicateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Duplicate(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<NotificationTemplateVersionListResponse> ListVersions(
        NotificationListVersionsParams parameters,
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
        string id,
        NotificationListVersionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListVersions(parameters with { ID = id }, cancellationToken);
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
    public async Task<NotificationContentMutationResponse> PutContent(
        NotificationPutContentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.PutContent(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<NotificationContentMutationResponse> PutContent(
        string id,
        NotificationPutContentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.PutContent(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<NotificationContentMutationResponse> PutElement(
        NotificationPutElementParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.PutElement(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<NotificationContentMutationResponse> PutElement(
        string elementID,
        NotificationPutElementParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.PutElement(parameters with { ElementID = elementID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<NotificationContentMutationResponse> PutLocale(
        NotificationPutLocaleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.PutLocale(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<NotificationContentMutationResponse> PutLocale(
        string localeID,
        NotificationPutLocaleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.PutLocale(parameters with { LocaleID = localeID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<NotificationTemplateResponse> Replace(
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
    public Task<NotificationTemplateResponse> Replace(
        string id,
        NotificationReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Replace(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<NotificationRetrieveContentResponse> RetrieveContent(
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
    public Task<NotificationRetrieveContentResponse> RetrieveContent(
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

        _checks = new(() => new CheckServiceWithRawResponse(client));
    }

    readonly Lazy<ICheckServiceWithRawResponse> _checks;
    public ICheckServiceWithRawResponse Checks
    {
        get { return _checks.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NotificationTemplateResponse>> Create(
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
                var notificationTemplateResponse = await response
                    .Deserialize<NotificationTemplateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    notificationTemplateResponse.Validate();
                }
                return notificationTemplateResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NotificationTemplateResponse>> Retrieve(
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
                var notificationTemplateResponse = await response
                    .Deserialize<NotificationTemplateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    notificationTemplateResponse.Validate();
                }
                return notificationTemplateResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<NotificationTemplateResponse>> Retrieve(
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
    public async Task<HttpResponse<NotificationTemplateResponse>> Duplicate(
        NotificationDuplicateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CourierInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<NotificationDuplicateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var notificationTemplateResponse = await response
                    .Deserialize<NotificationTemplateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    notificationTemplateResponse.Validate();
                }
                return notificationTemplateResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<NotificationTemplateResponse>> Duplicate(
        string id,
        NotificationDuplicateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Duplicate(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NotificationTemplateVersionListResponse>> ListVersions(
        NotificationListVersionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CourierInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<NotificationListVersionsParams> request = new()
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
        string id,
        NotificationListVersionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListVersions(parameters with { ID = id }, cancellationToken);
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
    public async Task<HttpResponse<NotificationContentMutationResponse>> PutContent(
        NotificationPutContentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new CourierInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<NotificationPutContentParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var notificationContentMutationResponse = await response
                    .Deserialize<NotificationContentMutationResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    notificationContentMutationResponse.Validate();
                }
                return notificationContentMutationResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<NotificationContentMutationResponse>> PutContent(
        string id,
        NotificationPutContentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.PutContent(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NotificationContentMutationResponse>> PutElement(
        NotificationPutElementParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ElementID == null)
        {
            throw new CourierInvalidDataException("'parameters.ElementID' cannot be null");
        }

        HttpRequest<NotificationPutElementParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var notificationContentMutationResponse = await response
                    .Deserialize<NotificationContentMutationResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    notificationContentMutationResponse.Validate();
                }
                return notificationContentMutationResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<NotificationContentMutationResponse>> PutElement(
        string elementID,
        NotificationPutElementParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.PutElement(parameters with { ElementID = elementID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NotificationContentMutationResponse>> PutLocale(
        NotificationPutLocaleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.LocaleID == null)
        {
            throw new CourierInvalidDataException("'parameters.LocaleID' cannot be null");
        }

        HttpRequest<NotificationPutLocaleParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var notificationContentMutationResponse = await response
                    .Deserialize<NotificationContentMutationResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    notificationContentMutationResponse.Validate();
                }
                return notificationContentMutationResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<NotificationContentMutationResponse>> PutLocale(
        string localeID,
        NotificationPutLocaleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.PutLocale(parameters with { LocaleID = localeID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NotificationTemplateResponse>> Replace(
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
                var notificationTemplateResponse = await response
                    .Deserialize<NotificationTemplateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    notificationTemplateResponse.Validate();
                }
                return notificationTemplateResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<NotificationTemplateResponse>> Replace(
        string id,
        NotificationReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Replace(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NotificationRetrieveContentResponse>> RetrieveContent(
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
                var deserializedResponse = await response
                    .Deserialize<NotificationRetrieveContentResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<NotificationRetrieveContentResponse>> RetrieveContent(
        string id,
        NotificationRetrieveContentParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveContent(parameters with { ID = id }, cancellationToken);
    }
}
