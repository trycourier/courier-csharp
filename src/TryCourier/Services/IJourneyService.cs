using System;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Models.Journeys;
using TryCourier.Services.Journeys;

namespace TryCourier.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IJourneyService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IJourneyServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IJourneyService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ITemplateService Templates { get; }

    /// <summary>
    /// Creates a journey from a set of nodes, in draft state unless you pass a
    /// published state. Send nodes cannot be included until their templates exist.
    /// </summary>
    Task<JourneyResponse> Create(
        JourneyCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Fetch a journey by id. Pass `?version=draft` (default `published`) to retrieve
    /// the working draft, or `?version=vN` to retrieve a historical version.
    /// </summary>
    Task<JourneyResponse> Retrieve(
        JourneyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(JourneyRetrieveParams, CancellationToken)"/>
    Task<JourneyResponse> Retrieve(
        string templateID,
        JourneyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists the workspace's journeys, each carrying a name, state, and enabled flag.
    /// Paged by cursor.
    /// </summary>
    Task<JourneysListResponse> List(
        JourneyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Archives a journey so it can no longer be invoked. Runs already in flight
    /// continue to completion, so archiving never strands a user mid-sequence.
    /// </summary>
    Task Archive(JourneyArchiveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Archive(JourneyArchiveParams, CancellationToken)"/>
    Task Archive(
        string templateID,
        JourneyArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancels in-flight journey runs, either every run sharing a cancelation token or
    /// one run by id. Use it to stop a sequence when the event resolves.
    /// </summary>
    Task<CancelJourneyResponse> Cancel(
        JourneyCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Starts a journey run for one user and returns a runId. Runs execute
    /// asynchronously, so the response arrives before any message is sent.
    /// </summary>
    Task<JourneysInvokeResponse> Invoke(
        JourneyInvokeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Invoke(JourneyInvokeParams, CancellationToken)"/>
    Task<JourneysInvokeResponse> Invoke(
        string templateID,
        JourneyInvokeParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists a journey's published versions, most recent first, so you have a version
    /// id to roll back to. Paged by cursor.
    /// </summary>
    Task<JourneyVersionsListResponse> ListVersions(
        JourneyListVersionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListVersions(JourneyListVersionsParams, CancellationToken)"/>
    Task<JourneyVersionsListResponse> ListVersions(
        string templateID,
        JourneyListVersionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Publishes a journey's current draft as a new version, making it live for new
    /// runs. Pass a version instead to roll back to an earlier one.
    /// </summary>
    Task<JourneyResponse> Publish(
        JourneyPublishParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Publish(JourneyPublishParams, CancellationToken)"/>
    Task<JourneyResponse> Publish(
        string templateID,
        JourneyPublishParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Replaces a journey's working draft, leaving the published version live until you
    /// publish. Reach for this when editing a journey already running.
    /// </summary>
    Task<JourneyResponse> Replace(
        JourneyReplaceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Replace(JourneyReplaceParams, CancellationToken)"/>
    Task<JourneyResponse> Replace(
        string templateID,
        JourneyReplaceParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IJourneyService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IJourneyServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IJourneyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ITemplateServiceWithRawResponse Templates { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /journeys</c>, but is otherwise the
    /// same as <see cref="IJourneyService.Create(JourneyCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<JourneyResponse>> Create(
        JourneyCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /journeys/{templateId}</c>, but is otherwise the
    /// same as <see cref="IJourneyService.Retrieve(JourneyRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<JourneyResponse>> Retrieve(
        JourneyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(JourneyRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<JourneyResponse>> Retrieve(
        string templateID,
        JourneyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /journeys</c>, but is otherwise the
    /// same as <see cref="IJourneyService.List(JourneyListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<JourneysListResponse>> List(
        JourneyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /journeys/{templateId}</c>, but is otherwise the
    /// same as <see cref="IJourneyService.Archive(JourneyArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Archive(
        JourneyArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(JourneyArchiveParams, CancellationToken)"/>
    Task<HttpResponse> Archive(
        string templateID,
        JourneyArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /journeys/cancel</c>, but is otherwise the
    /// same as <see cref="IJourneyService.Cancel(JourneyCancelParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CancelJourneyResponse>> Cancel(
        JourneyCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /journeys/{templateId}/invoke</c>, but is otherwise the
    /// same as <see cref="IJourneyService.Invoke(JourneyInvokeParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<JourneysInvokeResponse>> Invoke(
        JourneyInvokeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Invoke(JourneyInvokeParams, CancellationToken)"/>
    Task<HttpResponse<JourneysInvokeResponse>> Invoke(
        string templateID,
        JourneyInvokeParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /journeys/{templateId}/versions</c>, but is otherwise the
    /// same as <see cref="IJourneyService.ListVersions(JourneyListVersionsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<JourneyVersionsListResponse>> ListVersions(
        JourneyListVersionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListVersions(JourneyListVersionsParams, CancellationToken)"/>
    Task<HttpResponse<JourneyVersionsListResponse>> ListVersions(
        string templateID,
        JourneyListVersionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /journeys/{templateId}/publish</c>, but is otherwise the
    /// same as <see cref="IJourneyService.Publish(JourneyPublishParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<JourneyResponse>> Publish(
        JourneyPublishParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Publish(JourneyPublishParams, CancellationToken)"/>
    Task<HttpResponse<JourneyResponse>> Publish(
        string templateID,
        JourneyPublishParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /journeys/{templateId}</c>, but is otherwise the
    /// same as <see cref="IJourneyService.Replace(JourneyReplaceParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<JourneyResponse>> Replace(
        JourneyReplaceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Replace(JourneyReplaceParams, CancellationToken)"/>
    Task<HttpResponse<JourneyResponse>> Replace(
        string templateID,
        JourneyReplaceParams parameters,
        CancellationToken cancellationToken = default
    );
}
