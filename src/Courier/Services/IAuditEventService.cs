using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.AuditEvents;

namespace Courier.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAuditEventService
{
    IAuditEventService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Fetch a specific audit event by ID.
    /// </summary>
    Task<AuditEvent> Retrieve(
        AuditEventRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Fetch the list of audit events
    /// </summary>
    Task<AuditEventListResponse> List(
        AuditEventListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
