using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Requests;

namespace Courier.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IRequestService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRequestService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Archive message
    /// </summary>
    Task Archive(RequestArchiveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Archive(RequestArchiveParams, CancellationToken)"/>
    Task Archive(
        string requestID,
        RequestArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
