using System;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Models.Notifications.Previews.Runs;

namespace TryCourier.Services.Notifications.Previews;

/// <summary>
/// Render a template's email content on real email clients and read back the screenshots,
/// so you can check how it looks before you send it.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IRunService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRunServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRunService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Render this template's email content on each of the requested devices.
    ///
    /// <para>Returns as soon as the run exists and its render is queued — the
    /// screenshots are produced asynchronously. Poll `GET
    /// /notifications/{id}/previews/runs/{previewRunId}` until every result reaches a
    /// terminal status.</para>
    ///
    /// <para>Name the devices either with `device_set_id`, for a saved set, or with
    /// `device_ids`, for a one-off list. Exactly one of the two is required. Inline
    /// `device_ids` must be ids listed by `GET /previews/devices`; any other id is a
    /// 422, refused before the run exists or is billed.</para>
    ///
    /// <para>A template that does not exist is a 404. One that exists but cannot be
    /// previewed — not a Design Studio template, no email channel, or no such
    /// `template_version` — is a 422, also refused before the run exists or is billed.</para>
    ///
    /// <para>Preview runs are a metered add-on. A workspace without it, or with its
    /// billing suspended, receives a 402.</para>
    /// </summary>
    Task<PreviewRun> Create(
        RunCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(RunCreateParams, CancellationToken)"/>
    Task<PreviewRun> Create(
        string id,
        RunCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve one of this template's preview runs together with its per-device
    /// results.
    ///
    /// <para>A run is only readable under the template it previewed: under any other
    /// template it is a 404, the same as a run that does not exist.</para>
    ///
    /// <para>`thumbnail_url` and `screenshot_url` are short-lived signed URLs,
    /// re-signed on every read. Fetch them now rather than storing them. Both are null
    /// until Courier's own copy of the image exists, which is what `status: COMPLETED`
    /// on a result means.</para>
    /// </summary>
    Task<PreviewRunDetail> Retrieve(
        RunRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(RunRetrieveParams, CancellationToken)"/>
    Task<PreviewRunDetail> Retrieve(
        string previewRunID,
        RunRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List this template's preview runs, newest first. Cursor-paginated.
    ///
    /// <para>A template that does not exist is a 404, the same as every other
    /// `/notifications/{id}` route.</para>
    /// </summary>
    Task<PreviewRunListResponse> List(
        RunListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(RunListParams, CancellationToken)"/>
    Task<PreviewRunListResponse> List(
        string id,
        RunListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IRunService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRunServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRunServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /notifications/{id}/previews/runs</c>, but is otherwise the
    /// same as <see cref="IRunService.Create(RunCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PreviewRun>> Create(
        RunCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(RunCreateParams, CancellationToken)"/>
    Task<HttpResponse<PreviewRun>> Create(
        string id,
        RunCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /notifications/{id}/previews/runs/{previewRunId}</c>, but is otherwise the
    /// same as <see cref="IRunService.Retrieve(RunRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PreviewRunDetail>> Retrieve(
        RunRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(RunRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<PreviewRunDetail>> Retrieve(
        string previewRunID,
        RunRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /notifications/{id}/previews/runs</c>, but is otherwise the
    /// same as <see cref="IRunService.List(RunListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PreviewRunListResponse>> List(
        RunListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(RunListParams, CancellationToken)"/>
    Task<HttpResponse<PreviewRunListResponse>> List(
        string id,
        RunListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
