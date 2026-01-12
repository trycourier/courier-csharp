using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Notifications;
using Courier.Models.Notifications.Draft;

namespace Courier.Services.Notifications;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IDraftService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDraftServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDraftService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Sends a request to <c>get /notifications/{id}/draft/content<c/>.
    /// </summary>
    Task<NotificationGetContent> RetrieveContent(
        DraftRetrieveContentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveContent(DraftRetrieveContentParams, CancellationToken)"/>
    Task<NotificationGetContent> RetrieveContent(
        string id,
        DraftRetrieveContentParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IDraftService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDraftServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDraftServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /notifications/{id}/draft/content`, but is otherwise the
    /// same as <see cref="IDraftService.RetrieveContent(DraftRetrieveContentParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<NotificationGetContent>> RetrieveContent(
        DraftRetrieveContentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveContent(DraftRetrieveContentParams, CancellationToken)"/>
    Task<HttpResponse<NotificationGetContent>> RetrieveContent(
        string id,
        DraftRetrieveContentParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
