using System;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Models.Notifications;
using TryCourier.Services.Notifications;

namespace TryCourier.Services;

/// <summary>
/// Create, update, version, publish, and localize notification templates and their content.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
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
    /// Lists the workspace's notification templates. Each carries a name, tags, brand,
    /// routing, and its draft or published state.
    /// </summary>
    Task<NotificationListResponse> List(
        NotificationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Archives a notification template, preventing new sends from referencing it. The
    /// template stays retrievable for its version history.
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
    /// Copies a notification template within the same workspace and environment,
    /// appending " COPY" to the title. The copy is standalone and independently
    /// editable.
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
    /// Returns a notification template's published versions, most recent first, for
    /// comparison or rollback. Paged.
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
    /// Replaces all Elemental content in a template, overwriting every existing
    /// element. Supported for V2 templates only, not V1 blocks and channels.
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
    /// Replaces one Elemental element in a template, addressed by its element id.
    /// Supported for V2 templates only, not V1 blocks and channels.
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
    /// Sets locale-specific content overrides for a template. Each override must
    /// reference an element that already exists in the default content.
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
    /// Replaces a notification template in full, so send every field rather than only
    /// the ones you want changed. Publish separately to make it live.
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
    /// Returns a template's content and checksum. V2 templates return Elemental
    /// elements, while V1 templates return blocks and channels instead.
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
