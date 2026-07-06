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
    /// Create a journey. Defaults to `DRAFT` state; pass `state: "PUBLISHED"` to
    /// publish on create. Send nodes are not allowed on `POST`. The standard flow is:
    /// create the journey shell here, add notification templates with `POST
    /// /journeys/{templateId}/templates`, then wire them into the journey with `PUT
    /// /journeys/{templateId}`. Call `POST /journeys/{templateId}/publish` to publish a
    /// draft after the fact.
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
    /// Get the list of journeys.
    /// </summary>
    Task<JourneysListResponse> List(
        JourneyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Archive a journey. Archived journeys cannot be invoked. Existing journey runs
    /// continue to completion.
    /// </summary>
    Task Archive(JourneyArchiveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Archive(JourneyArchiveParams, CancellationToken)"/>
    Task Archive(
        string templateID,
        JourneyArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancel journey runs. The request body must include EXACTLY ONE of
    /// `cancelation_token` (cancels every run associated with the token) or `run_id`
    /// (cancels a single tenant-scoped run). Supplying both or neither returns a `400`.
    /// A `run_id` that does not match a run for the tenant returns `404`. Cancelation
    /// is idempotent: a run that has already finished (`PROCESSED`/`ERROR`) or was
    /// already `CANCELED` is left unchanged and its current status is returned.
    /// </summary>
    Task<CancelJourneyResponse> Cancel(
        JourneyCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Invoke a journey by id or alias to start a new run. The response includes a
    /// `runId` identifying the run.
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
    /// List published versions of a journey, ordered most recent first.
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
    /// Publish the current draft as a new version. Body is optional; pass `{ "version":
    /// "vN" }` to roll back to a prior version instead. Returns 404 if the journey has
    /// no draft to publish.
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
    /// Replace the journey draft. Updates the working draft only; call `POST
    /// /journeys/{templateId}/publish` to make it live, or pass `state: "PUBLISHED"` in
    /// this request to publish immediately. Send-node `template` ids must already exist
    /// and be scoped to this journey, and node ids must not be claimed by another
    /// journey.
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
