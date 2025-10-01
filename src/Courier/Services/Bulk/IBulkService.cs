using System.Threading.Tasks;
using Courier.Models.Bulk;

namespace Courier.Services.Bulk;

public interface IBulkService
{
    /// <summary>
    /// Ingest user data into a Bulk Job
    /// </summary>
    Task AddUsers(BulkAddUsersParams parameters);

    /// <summary>
    /// Create a bulk job
    /// </summary>
    Task<BulkCreateJobResponse> CreateJob(BulkCreateJobParams parameters);

    /// <summary>
    /// Get Bulk Job Users
    /// </summary>
    Task<BulkListUsersResponse> ListUsers(BulkListUsersParams parameters);

    /// <summary>
    /// Get a bulk job
    /// </summary>
    Task<BulkRetrieveJobResponse> RetrieveJob(BulkRetrieveJobParams parameters);

    /// <summary>
    /// Run a bulk job
    /// </summary>
    Task RunJob(BulkRunJobParams parameters);
}
