using System;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Models.Automations;
using TryCourier.Models.Automations.Runs;

namespace TryCourier.Services.Automations;

/// <summary>
/// Invoke a stored automation template or an ad hoc automation defined in the request.
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
    /// List runs of the workspace's v2 Automations, newest first, filtered by status,
    /// Template, or date range and paged by cursor. Journey (v3) runs are listed by
    /// `GET /journeys/runs` instead — the two surfaces never return each other's runs.
    /// Runs are retained for 95 days.
    /// </summary>
    Task<AutomationRunListResponse> List(
        RunListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List the per-step state of one Automation run, in full — this endpoint is not
    /// paginated. `message_id` is present on send steps that produced a message; follow
    /// it to `GET /messages/{message_id}` for delivery status. A send to a List or an
    /// Audience yields one `message_id` for the request, not one per recipient.
    /// </summary>
    Task<AutomationRunStepsResponse> ListSteps(
        RunListStepsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListSteps(RunListStepsParams, CancellationToken)"/>
    Task<AutomationRunStepsResponse> ListSteps(
        string id,
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
    /// Returns a raw HTTP response for <c>get /automations/runs</c>, but is otherwise the
    /// same as <see cref="IRunService.List(RunListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AutomationRunListResponse>> List(
        RunListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /automations/runs/{id}/steps</c>, but is otherwise the
    /// same as <see cref="IRunService.ListSteps(RunListStepsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AutomationRunStepsResponse>> ListSteps(
        RunListStepsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListSteps(RunListStepsParams, CancellationToken)"/>
    Task<HttpResponse<AutomationRunStepsResponse>> ListSteps(
        string id,
        RunListStepsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
