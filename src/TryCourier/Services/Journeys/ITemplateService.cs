using System;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Models.Journeys;
using TryCourier.Models.Journeys.Templates;
using TryCourier.Models.Notifications;

namespace TryCourier.Services.Journeys;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ITemplateService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITemplateServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITemplateService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a notification template scoped to this journey. Defaults to `DRAFT`
    /// state; pass `state: "PUBLISHED"` to publish on create.
    /// </summary>
    Task<JourneyTemplateGetResponse> Create(
        TemplateCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(TemplateCreateParams, CancellationToken)"/>
    Task<JourneyTemplateGetResponse> Create(
        string templateID,
        TemplateCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Fetch a journey-scoped notification template by id. Pass `?version=draft`
    /// (default `published`) to retrieve the working draft, or `?version=vN` for a
    /// historical version.
    /// </summary>
    Task<JourneyTemplateGetResponse> Retrieve(
        TemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TemplateRetrieveParams, CancellationToken)"/>
    Task<JourneyTemplateGetResponse> Retrieve(
        string notificationID,
        TemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List notification templates scoped to this journey. Journey-scoped notification
    /// templates can only be referenced from `send` nodes within the same journey.
    /// </summary>
    Task<JourneyTemplateListResponse> List(
        TemplateListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(TemplateListParams, CancellationToken)"/>
    Task<JourneyTemplateListResponse> List(
        string templateID,
        TemplateListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Archive the journey-scoped notification template. Archived templates cannot be
    /// sent.
    /// </summary>
    Task Archive(TemplateArchiveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Archive(TemplateArchiveParams, CancellationToken)"/>
    Task Archive(
        string notificationID,
        TemplateArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List published versions of the journey-scoped notification template, ordered
    /// most recent first.
    /// </summary>
    Task<NotificationTemplateVersionListResponse> ListVersions(
        TemplateListVersionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListVersions(TemplateListVersionsParams, CancellationToken)"/>
    Task<NotificationTemplateVersionListResponse> ListVersions(
        string notificationID,
        TemplateListVersionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Publish the current draft of the journey-scoped notification template as a new
    /// version. Optionally roll back to a prior version by passing `{ "version": "vN"
    /// }`.
    /// </summary>
    Task Publish(TemplatePublishParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Publish(TemplatePublishParams, CancellationToken)"/>
    Task Publish(
        string notificationID,
        TemplatePublishParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Replace the elemental content of a journey-scoped notification template.
    /// Overwrites all elements in the template draft with the provided content.
    /// </summary>
    Task<NotificationContentMutationResponse> PutContent(
        TemplatePutContentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="PutContent(TemplatePutContentParams, CancellationToken)"/>
    Task<NotificationContentMutationResponse> PutContent(
        string notificationID,
        TemplatePutContentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Set locale-specific content overrides for a journey-scoped notification
    /// template. Each element override must reference an existing element by ID.
    /// </summary>
    Task<NotificationContentMutationResponse> PutLocale(
        TemplatePutLocaleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="PutLocale(TemplatePutLocaleParams, CancellationToken)"/>
    Task<NotificationContentMutationResponse> PutLocale(
        string localeID,
        TemplatePutLocaleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Replace the journey-scoped notification template draft.
    /// </summary>
    Task<JourneyTemplateGetResponse> Replace(
        TemplateReplaceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Replace(TemplateReplaceParams, CancellationToken)"/>
    Task<JourneyTemplateGetResponse> Replace(
        string notificationID,
        TemplateReplaceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve the elemental content of a journey-scoped notification template. The
    /// response contains the versioned elements with their content checksums. Pass
    /// `?version=draft` (default `published`) to retrieve the working draft, or
    /// `?version=vN` for a historical version.
    /// </summary>
    Task<NotificationContentGetResponse> RetrieveContent(
        TemplateRetrieveContentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveContent(TemplateRetrieveContentParams, CancellationToken)"/>
    Task<NotificationContentGetResponse> RetrieveContent(
        string notificationID,
        TemplateRetrieveContentParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITemplateService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITemplateServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITemplateServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /journeys/{templateId}/templates</c>, but is otherwise the
    /// same as <see cref="ITemplateService.Create(TemplateCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<JourneyTemplateGetResponse>> Create(
        TemplateCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(TemplateCreateParams, CancellationToken)"/>
    Task<HttpResponse<JourneyTemplateGetResponse>> Create(
        string templateID,
        TemplateCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /journeys/{templateId}/templates/{notificationId}</c>, but is otherwise the
    /// same as <see cref="ITemplateService.Retrieve(TemplateRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<JourneyTemplateGetResponse>> Retrieve(
        TemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TemplateRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<JourneyTemplateGetResponse>> Retrieve(
        string notificationID,
        TemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /journeys/{templateId}/templates</c>, but is otherwise the
    /// same as <see cref="ITemplateService.List(TemplateListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<JourneyTemplateListResponse>> List(
        TemplateListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(TemplateListParams, CancellationToken)"/>
    Task<HttpResponse<JourneyTemplateListResponse>> List(
        string templateID,
        TemplateListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /journeys/{templateId}/templates/{notificationId}</c>, but is otherwise the
    /// same as <see cref="ITemplateService.Archive(TemplateArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Archive(
        TemplateArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(TemplateArchiveParams, CancellationToken)"/>
    Task<HttpResponse> Archive(
        string notificationID,
        TemplateArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /journeys/{templateId}/templates/{notificationId}/versions</c>, but is otherwise the
    /// same as <see cref="ITemplateService.ListVersions(TemplateListVersionsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<NotificationTemplateVersionListResponse>> ListVersions(
        TemplateListVersionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListVersions(TemplateListVersionsParams, CancellationToken)"/>
    Task<HttpResponse<NotificationTemplateVersionListResponse>> ListVersions(
        string notificationID,
        TemplateListVersionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /journeys/{templateId}/templates/{notificationId}/publish</c>, but is otherwise the
    /// same as <see cref="ITemplateService.Publish(TemplatePublishParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Publish(
        TemplatePublishParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Publish(TemplatePublishParams, CancellationToken)"/>
    Task<HttpResponse> Publish(
        string notificationID,
        TemplatePublishParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /journeys/{templateId}/templates/{notificationId}/content</c>, but is otherwise the
    /// same as <see cref="ITemplateService.PutContent(TemplatePutContentParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<NotificationContentMutationResponse>> PutContent(
        TemplatePutContentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="PutContent(TemplatePutContentParams, CancellationToken)"/>
    Task<HttpResponse<NotificationContentMutationResponse>> PutContent(
        string notificationID,
        TemplatePutContentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /journeys/{templateId}/templates/{notificationId}/locales/{localeId}</c>, but is otherwise the
    /// same as <see cref="ITemplateService.PutLocale(TemplatePutLocaleParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<NotificationContentMutationResponse>> PutLocale(
        TemplatePutLocaleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="PutLocale(TemplatePutLocaleParams, CancellationToken)"/>
    Task<HttpResponse<NotificationContentMutationResponse>> PutLocale(
        string localeID,
        TemplatePutLocaleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /journeys/{templateId}/templates/{notificationId}</c>, but is otherwise the
    /// same as <see cref="ITemplateService.Replace(TemplateReplaceParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<JourneyTemplateGetResponse>> Replace(
        TemplateReplaceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Replace(TemplateReplaceParams, CancellationToken)"/>
    Task<HttpResponse<JourneyTemplateGetResponse>> Replace(
        string notificationID,
        TemplateReplaceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /journeys/{templateId}/templates/{notificationId}/content</c>, but is otherwise the
    /// same as <see cref="ITemplateService.RetrieveContent(TemplateRetrieveContentParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<NotificationContentGetResponse>> RetrieveContent(
        TemplateRetrieveContentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveContent(TemplateRetrieveContentParams, CancellationToken)"/>
    Task<HttpResponse<NotificationContentGetResponse>> RetrieveContent(
        string notificationID,
        TemplateRetrieveContentParams parameters,
        CancellationToken cancellationToken = default
    );
}
