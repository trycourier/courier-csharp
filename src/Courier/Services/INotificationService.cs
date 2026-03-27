using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Notifications;
using Courier.Services.Notifications;

namespace Courier.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface INotificationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    INotificationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INotificationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IDraftService Draft { get; }

    ICheckService Checks { get; }

    /// <summary>
    /// Create a notification template. Requires all fields in the notification object.
    /// Templates are created in draft state by default.
    /// </summary>
    Task<NotificationTemplateMutationResponse> Create(
        NotificationCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a notification template by ID. Returns the published version by
    /// default. Pass version=draft to retrieve an unpublished template.
    /// </summary>
    Task<NotificationTemplateGetResponse> Retrieve(
        NotificationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(NotificationRetrieveParams, CancellationToken)"/>
    Task<NotificationTemplateGetResponse> Retrieve(
        string id,
        NotificationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List notification templates in your workspace.
    /// </summary>
    Task<NotificationListResponse> List(
        NotificationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Archive a notification template.
    /// </summary>
    Task Archive(
        NotificationArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(NotificationArchiveParams, CancellationToken)"/>
    Task Archive(
        string id,
        NotificationArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List versions of a notification template.
    /// </summary>
    Task<NotificationTemplateVersionListResponse> ListVersions(
        NotificationListVersionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListVersions(NotificationListVersionsParams, CancellationToken)"/>
    Task<NotificationTemplateVersionListResponse> ListVersions(
        string id,
        NotificationListVersionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Publish a notification template. Publishes the current draft by default. Pass a
    /// version in the request body to publish a specific historical version.
    /// </summary>
    Task Publish(
        NotificationPublishParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Publish(NotificationPublishParams, CancellationToken)"/>
    Task Publish(
        string id,
        NotificationPublishParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Replace a notification template. All fields are required.
    /// </summary>
    Task<NotificationTemplateMutationResponse> Replace(
        NotificationReplaceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Replace(NotificationReplaceParams, CancellationToken)"/>
    Task<NotificationTemplateMutationResponse> Replace(
        string id,
        NotificationReplaceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>get /notifications/{id}/content</c>.
    /// </summary>
    Task<NotificationGetContent> RetrieveContent(
        NotificationRetrieveContentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveContent(NotificationRetrieveContentParams, CancellationToken)"/>
    Task<NotificationGetContent> RetrieveContent(
        string id,
        NotificationRetrieveContentParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="INotificationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface INotificationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INotificationServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IDraftServiceWithRawResponse Draft { get; }

    ICheckServiceWithRawResponse Checks { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /notifications</c>, but is otherwise the
    /// same as <see cref="INotificationService.Create(NotificationCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<NotificationTemplateMutationResponse>> Create(
        NotificationCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /notifications/{id}</c>, but is otherwise the
    /// same as <see cref="INotificationService.Retrieve(NotificationRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<NotificationTemplateGetResponse>> Retrieve(
        NotificationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(NotificationRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<NotificationTemplateGetResponse>> Retrieve(
        string id,
        NotificationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /notifications</c>, but is otherwise the
    /// same as <see cref="INotificationService.List(NotificationListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<NotificationListResponse>> List(
        NotificationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /notifications/{id}</c>, but is otherwise the
    /// same as <see cref="INotificationService.Archive(NotificationArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Archive(
        NotificationArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(NotificationArchiveParams, CancellationToken)"/>
    Task<HttpResponse> Archive(
        string id,
        NotificationArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /notifications/{id}/versions</c>, but is otherwise the
    /// same as <see cref="INotificationService.ListVersions(NotificationListVersionsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<NotificationTemplateVersionListResponse>> ListVersions(
        NotificationListVersionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListVersions(NotificationListVersionsParams, CancellationToken)"/>
    Task<HttpResponse<NotificationTemplateVersionListResponse>> ListVersions(
        string id,
        NotificationListVersionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /notifications/{id}/publish</c>, but is otherwise the
    /// same as <see cref="INotificationService.Publish(NotificationPublishParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Publish(
        NotificationPublishParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Publish(NotificationPublishParams, CancellationToken)"/>
    Task<HttpResponse> Publish(
        string id,
        NotificationPublishParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /notifications/{id}</c>, but is otherwise the
    /// same as <see cref="INotificationService.Replace(NotificationReplaceParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<NotificationTemplateMutationResponse>> Replace(
        NotificationReplaceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Replace(NotificationReplaceParams, CancellationToken)"/>
    Task<HttpResponse<NotificationTemplateMutationResponse>> Replace(
        string id,
        NotificationReplaceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /notifications/{id}/content</c>, but is otherwise the
    /// same as <see cref="INotificationService.RetrieveContent(NotificationRetrieveContentParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<NotificationGetContent>> RetrieveContent(
        NotificationRetrieveContentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveContent(NotificationRetrieveContentParams, CancellationToken)"/>
    Task<HttpResponse<NotificationGetContent>> RetrieveContent(
        string id,
        NotificationRetrieveContentParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
