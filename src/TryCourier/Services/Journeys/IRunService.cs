using System;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Models.Journeys;
using TryCourier.Models.Journeys.Runs;

namespace TryCourier.Services.Journeys;

/// <summary>
/// Build, version, publish, invoke, and cancel multi-step notification workflows,
/// along with the templates scoped to them.
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
    /// Fetch one Journey run by id. Returns `404` for an unknown run, a run belonging
    /// to another workspace, a run past the 95-day retention window, or an Automation
    /// run id — the same body in every case, so the response never reveals whether a
    /// run exists elsewhere.
    /// </summary>
    Task<JourneyRunResponse> Retrieve(
        RunRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(RunRetrieveParams, CancellationToken)"/>
    Task<JourneyRunResponse> Retrieve(
        string runID,
        RunRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List runs of the workspace's Journeys, newest first, filtered by status,
    /// Journey, or date range and paged by cursor. Runs of v2 Automations are listed by
    /// `GET /automations/runs` instead — the two surfaces never return each other's
    /// runs. Runs are retained for 95 days.
    /// </summary>
    Task<JourneyRunListResponse> List(
        RunListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List the per-node state of one Journey run, in full — this endpoint is not
    /// paginated. Each step's `node_id` is the id of the node in the published Journey,
    /// so a step maps directly onto the Journey graph. `message_id` is present on send
    /// steps that produced a message; follow it to `GET /messages/{message_id}` for
    /// delivery status.
    /// </summary>
    Task<JourneyRunStepsResponse> ListSteps(
        RunListStepsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListSteps(RunListStepsParams, CancellationToken)"/>
    Task<JourneyRunStepsResponse> ListSteps(
        string runID,
        RunListStepsParams? parameters = null,
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
    /// Returns a raw HTTP response for <c>get /journeys/runs/{run_id}</c>, but is otherwise the
    /// same as <see cref="IRunService.Retrieve(RunRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<JourneyRunResponse>> Retrieve(
        RunRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(RunRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<JourneyRunResponse>> Retrieve(
        string runID,
        RunRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /journeys/runs</c>, but is otherwise the
    /// same as <see cref="IRunService.List(RunListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<JourneyRunListResponse>> List(
        RunListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /journeys/runs/{run_id}/steps</c>, but is otherwise the
    /// same as <see cref="IRunService.ListSteps(RunListStepsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<JourneyRunStepsResponse>> ListSteps(
        RunListStepsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListSteps(RunListStepsParams, CancellationToken)"/>
    Task<HttpResponse<JourneyRunStepsResponse>> ListSteps(
        string runID,
        RunListStepsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
