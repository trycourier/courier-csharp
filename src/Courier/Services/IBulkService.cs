using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Bulk;

namespace Courier.Services;

public interface IBulkService
{
    IBulkService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Ingest user data into a Bulk Job
    /// </summary>
    Task AddUsers(BulkAddUsersParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Create a bulk job
    /// </summary>
    Task<BulkCreateJobResponse> CreateJob(
        BulkCreateJobParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get Bulk Job Users
    /// </summary>
    Task<BulkListUsersResponse> ListUsers(
        BulkListUsersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a bulk job
    /// </summary>
    Task<BulkRetrieveJobResponse> RetrieveJob(
        BulkRetrieveJobParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Run a bulk job
    /// </summary>
    Task RunJob(BulkRunJobParams parameters, CancellationToken cancellationToken = default);
}
