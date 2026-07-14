using System;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Models.Notifications;
using TryCourier.Services.Notifications;

namespace TryCourier.Services;

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

    ICheckService Checks { get; }

    /// <summary>
    /// Create a notification template. Requires all fields in the notification object.
    /// Templates are created in draft state by default.
    /// </summary>
    Task<NotificationTemplateResponse> Create(
        NotificationCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a notification template by ID. Returns the published version by
    /// default. Pass version=draft to retrieve an unpublished template.
    /// </summary>
    Task<NotificationTemplateResponse> Retrieve(
        NotificationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(NotificationRetrieveParams, CancellationToken)"/>
    Task<NotificationTemplateResponse> Retrieve(
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
    /// Duplicate a notification template. Creates a standalone copy within the same
    /// workspace and environment, with " COPY" appended to the title. The copy clones
    /// the source draft's tags, brand, subscription topic, routing strategy, channels,
    /// and content, and is always created as a standalone template (it is not linked to
    /// any journey or broadcast, even if the source was). Templates that are scoped to
    /// a journey or a broadcast cannot be duplicated through this endpoint.
    /// </summary>
    Task<NotificationTemplateResponse> Duplicate(
        NotificationDuplicateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Duplicate(NotificationDuplicateParams, CancellationToken)"/>
    Task<NotificationTemplateResponse> Duplicate(
        string id,
        NotificationDuplicateParams? parameters = null,
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
    /// Replace the elemental content of a notification template. Overwrites all
    /// elements in the template with the provided content. Only supported for V2
    /// (elemental) templates.
    /// </summary>
    Task<NotificationContentMutationResponse> PutContent(
        NotificationPutContentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="PutContent(NotificationPutContentParams, CancellationToken)"/>
    Task<NotificationContentMutationResponse> PutContent(
        string id,
        NotificationPutContentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a single element within a notification template. Only supported for V2
    /// (elemental) templates.
    /// </summary>
    Task<NotificationContentMutationResponse> PutElement(
        NotificationPutElementParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="PutElement(NotificationPutElementParams, CancellationToken)"/>
    Task<NotificationContentMutationResponse> PutElement(
        string elementID,
        NotificationPutElementParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Set locale-specific content overrides for a notification template. Each element
    /// override must reference an existing element by ID. Only supported for V2
    /// (elemental) templates.
    /// </summary>
    Task<NotificationContentMutationResponse> PutLocale(
        NotificationPutLocaleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="PutLocale(NotificationPutLocaleParams, CancellationToken)"/>
    Task<NotificationContentMutationResponse> PutLocale(
        string localeID,
        NotificationPutLocaleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Replace a notification template. All fields are required.
    /// </summary>
    Task<NotificationTemplateResponse> Replace(
        NotificationReplaceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Replace(NotificationReplaceParams, CancellationToken)"/>
    Task<NotificationTemplateResponse> Replace(
        string id,
        NotificationReplaceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve the content of a notification template. The response shape depends on
    /// whether the template uses V1 (blocks/channels) or V2 (elemental) content. Use
    /// the `version` query parameter to select draft, published, or a specific
    /// historical version.
    /// </summary>
    Task<NotificationRetrieveContentResponse> RetrieveContent(
        NotificationRetrieveContentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveContent(NotificationRetrieveContentParams, CancellationToken)"/>
    Task<NotificationRetrieveContentResponse> RetrieveContent(
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

    ICheckServiceWithRawResponse Checks { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /notifications</c>, but is otherwise the
    /// same as <see cref="INotificationService.Create(NotificationCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<NotificationTemplateResponse>> Create(
        NotificationCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /notifications/{id}</c>, but is otherwise the
    /// same as <see cref="INotificationService.Retrieve(NotificationRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<NotificationTemplateResponse>> Retrieve(
        NotificationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(NotificationRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<NotificationTemplateResponse>> Retrieve(
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
    /// Returns a raw HTTP response for <c>post /notifications/{id}/duplicate</c>, but is otherwise the
    /// same as <see cref="INotificationService.Duplicate(NotificationDuplicateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<NotificationTemplateResponse>> Duplicate(
        NotificationDuplicateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Duplicate(NotificationDuplicateParams, CancellationToken)"/>
    Task<HttpResponse<NotificationTemplateResponse>> Duplicate(
        string id,
        NotificationDuplicateParams? parameters = null,
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
    /// Returns a raw HTTP response for <c>put /notifications/{id}/content</c>, but is otherwise the
    /// same as <see cref="INotificationService.PutContent(NotificationPutContentParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<NotificationContentMutationResponse>> PutContent(
        NotificationPutContentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="PutContent(NotificationPutContentParams, CancellationToken)"/>
    Task<HttpResponse<NotificationContentMutationResponse>> PutContent(
        string id,
        NotificationPutContentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /notifications/{id}/elements/{elementId}</c>, but is otherwise the
    /// same as <see cref="INotificationService.PutElement(NotificationPutElementParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<NotificationContentMutationResponse>> PutElement(
        NotificationPutElementParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="PutElement(NotificationPutElementParams, CancellationToken)"/>
    Task<HttpResponse<NotificationContentMutationResponse>> PutElement(
        string elementID,
        NotificationPutElementParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /notifications/{id}/locales/{localeId}</c>, but is otherwise the
    /// same as <see cref="INotificationService.PutLocale(NotificationPutLocaleParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<NotificationContentMutationResponse>> PutLocale(
        NotificationPutLocaleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="PutLocale(NotificationPutLocaleParams, CancellationToken)"/>
    Task<HttpResponse<NotificationContentMutationResponse>> PutLocale(
        string localeID,
        NotificationPutLocaleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /notifications/{id}</c>, but is otherwise the
    /// same as <see cref="INotificationService.Replace(NotificationReplaceParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<NotificationTemplateResponse>> Replace(
        NotificationReplaceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Replace(NotificationReplaceParams, CancellationToken)"/>
    Task<HttpResponse<NotificationTemplateResponse>> Replace(
        string id,
        NotificationReplaceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /notifications/{id}/content</c>, but is otherwise the
    /// same as <see cref="INotificationService.RetrieveContent(NotificationRetrieveContentParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<NotificationRetrieveContentResponse>> RetrieveContent(
        NotificationRetrieveContentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveContent(NotificationRetrieveContentParams, CancellationToken)"/>
    Task<HttpResponse<NotificationRetrieveContentResponse>> RetrieveContent(
        string id,
        NotificationRetrieveContentParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
