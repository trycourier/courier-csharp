using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Bulk;

namespace Courier.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IBulkService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBulkService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Ingest user data into a Bulk Job.
    ///
    /// <para>**Important**: For email-based bulk jobs, each user must include `profile.email`
    ///  for provider routing to work correctly. The `to.email` field is not sufficient
    ///  for email provider routing.</para>
    /// </summary>
    Task AddUsers(BulkAddUsersParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="AddUsers(BulkAddUsersParams, CancellationToken)"/>
    Task AddUsers(
        string jobID,
        BulkAddUsersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a new bulk job for sending messages to multiple recipients.
    ///
    /// <para>**Required**: `message.event` (event ID or notification ID)</para>
    ///
    /// <para>**Optional (V2 format)**: `message.template` (notification ID) or `message.content`
    /// (Elemental content)  can be provided to override the notification associated
    /// with the event.</para>
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

    /// <inheritdoc cref="ListUsers(BulkListUsersParams, CancellationToken)"/>
    Task<BulkListUsersResponse> ListUsers(
        string jobID,
        BulkListUsersParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a bulk job
    /// </summary>
    Task<BulkRetrieveJobResponse> RetrieveJob(
        BulkRetrieveJobParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveJob(BulkRetrieveJobParams, CancellationToken)"/>
    Task<BulkRetrieveJobResponse> RetrieveJob(
        string jobID,
        BulkRetrieveJobParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Run a bulk job
    /// </summary>
    Task RunJob(BulkRunJobParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="RunJob(BulkRunJobParams, CancellationToken)"/>
    Task RunJob(
        string jobID,
        BulkRunJobParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
