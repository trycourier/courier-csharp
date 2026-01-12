using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Notifications;
using Courier.Services.Notifications;

namespace Courier.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface INotificationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    INotificationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INotificationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IDraftService Draft { get; }

    ICheckService Checks { get; }

    /// <summary>
    /// Sends a request to <c>get /notifications<c/>.
    /// </summary>
    Task<NotificationListResponse> List(
        NotificationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to <c>get /notifications/{id}/content<c/>.
    /// </summary>
    Task<NotificationGetContent> RetrieveContent(
        NotificationRetrieveContentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveContent(NotificationRetrieveContentParams, CancellationToken)"/>
    Task<NotificationGetContent> RetrieveContent(
        string id,
        NotificationRetrieveContentParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="INotificationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface INotificationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    INotificationServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IDraftServiceWithRawResponse Draft { get; }

    ICheckServiceWithRawResponse Checks { get; }

    /// <summary>
    /// Returns a raw HTTP response for `get /notifications`, but is otherwise the
    /// same as <see cref="INotificationService.List(NotificationListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<NotificationListResponse>> List(
        NotificationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /notifications/{id}/content`, but is otherwise the
    /// same as <see cref="INotificationService.RetrieveContent(NotificationRetrieveContentParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<NotificationGetContent>> RetrieveContent(
        NotificationRetrieveContentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveContent(NotificationRetrieveContentParams, CancellationToken)"/>
    Task<HttpResponse<NotificationGetContent>> RetrieveContent(
        string id,
        NotificationRetrieveContentParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
