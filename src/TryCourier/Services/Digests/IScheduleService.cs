using System;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Models.Digests;
using TryCourier.Models.Digests.Schedules;

namespace TryCourier.Services.Digests;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IScheduleService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IScheduleServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IScheduleService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// List the digest instances for a schedule. Each instance represents the events
    /// accumulated for a single user against the schedule, and can be used to monitor
    /// digest accumulation before the digest is released.
    /// </summary>
    Task<DigestInstanceListResponse> ListInstances(
        ScheduleListInstancesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListInstances(ScheduleListInstancesParams, CancellationToken)"/>
    Task<DigestInstanceListResponse> ListInstances(
        string scheduleID,
        ScheduleListInstancesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Send a digest now instead of waiting for its scheduled time, so your users get
    /// what they have collected so far right away.
    /// </summary>
    Task Release(ScheduleReleaseParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Release(ScheduleReleaseParams, CancellationToken)"/>
    Task Release(
        string scheduleID,
        ScheduleReleaseParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IScheduleService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IScheduleServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IScheduleServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /digests/schedules/{schedule_id}/instances</c>, but is otherwise the
    /// same as <see cref="IScheduleService.ListInstances(ScheduleListInstancesParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DigestInstanceListResponse>> ListInstances(
        ScheduleListInstancesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListInstances(ScheduleListInstancesParams, CancellationToken)"/>
    Task<HttpResponse<DigestInstanceListResponse>> ListInstances(
        string scheduleID,
        ScheduleListInstancesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /digests/schedules/{schedule_id}/trigger</c>, but is otherwise the
    /// same as <see cref="IScheduleService.Release(ScheduleReleaseParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Release(
        ScheduleReleaseParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Release(ScheduleReleaseParams, CancellationToken)"/>
    Task<HttpResponse> Release(
        string scheduleID,
        ScheduleReleaseParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
