using System;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Models.AuditEvents;

namespace TryCourier.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAuditEventService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAuditEventServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAuditEventService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns one audit event by id, including the actor who performed it, the target
    /// they changed, the source, the event type, and a timestamp.
    /// </summary>
    Task<AuditEvent> Retrieve(
        AuditEventRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AuditEventRetrieveParams, CancellationToken)"/>
    Task<AuditEvent> Retrieve(
        string auditEventID,
        AuditEventRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the workspace's audit event log with cursor paging. Each event records
    /// the actor, target, source, type, and timestamp of a change.
    /// </summary>
    Task<AuditEventListResponse> List(
        AuditEventListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAuditEventService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAuditEventServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAuditEventServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /audit-events/{audit-event-id}</c>, but is otherwise the
    /// same as <see cref="IAuditEventService.Retrieve(AuditEventRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AuditEvent>> Retrieve(
        AuditEventRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AuditEventRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<AuditEvent>> Retrieve(
        string auditEventID,
        AuditEventRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /audit-events</c>, but is otherwise the
    /// same as <see cref="IAuditEventService.List(AuditEventListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AuditEventListResponse>> List(
        AuditEventListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
