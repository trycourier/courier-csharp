using System.Threading.Tasks;
using Courier.Models.AuditEvents;

namespace Courier.Services.AuditEvents;

public interface IAuditEventService
{
    /// <summary>
    /// Fetch a specific audit event by ID.
    /// </summary>
    Task<AuditEvent> Retrieve(AuditEventRetrieveParams parameters);

    /// <summary>
    /// Fetch the list of audit events
    /// </summary>
    Task<AuditEventListResponse> List(AuditEventListParams? parameters = null);
}
