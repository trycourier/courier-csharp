using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.RoutingStrategies;

namespace Courier.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IRoutingStrategyService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRoutingStrategyServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRoutingStrategyService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a routing strategy. Requires a name and routing configuration at minimum.
    /// Channels and providers default to empty if omitted.
    /// </summary>
    Task<RoutingStrategyGetResponse> Create(
        RoutingStrategyCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a routing strategy by ID. Returns the full entity including routing
    /// content and metadata.
    /// </summary>
    Task<RoutingStrategyGetResponse> Retrieve(
        RoutingStrategyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(RoutingStrategyRetrieveParams, CancellationToken)"/>
    Task<RoutingStrategyGetResponse> Retrieve(
        string id,
        RoutingStrategyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List routing strategies in your workspace. Returns metadata only (no
    /// routing/channels/providers content). Use GET /routing-strategies/{id} for full
    /// details.
    /// </summary>
    Task<RoutingStrategyListResponse> List(
        RoutingStrategyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Archive a routing strategy. The strategy must not have associated notification
    /// templates. Unlink all templates before archiving.
    /// </summary>
    Task Archive(
        RoutingStrategyArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(RoutingStrategyArchiveParams, CancellationToken)"/>
    Task Archive(
        string id,
        RoutingStrategyArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List notification templates associated with a routing strategy. Includes
    /// template metadata only, not full content.
    /// </summary>
    Task<AssociatedNotificationListResponse> ListNotifications(
        RoutingStrategyListNotificationsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListNotifications(RoutingStrategyListNotificationsParams, CancellationToken)"/>
    Task<AssociatedNotificationListResponse> ListNotifications(
        string id,
        RoutingStrategyListNotificationsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Replace a routing strategy. Full document replacement; the caller must send the
    /// complete desired state. Missing optional fields are cleared.
    /// </summary>
    Task<RoutingStrategyGetResponse> Replace(
        RoutingStrategyReplaceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Replace(RoutingStrategyReplaceParams, CancellationToken)"/>
    Task<RoutingStrategyGetResponse> Replace(
        string id,
        RoutingStrategyReplaceParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IRoutingStrategyService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRoutingStrategyServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRoutingStrategyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /routing-strategies</c>, but is otherwise the
    /// same as <see cref="IRoutingStrategyService.Create(RoutingStrategyCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RoutingStrategyGetResponse>> Create(
        RoutingStrategyCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /routing-strategies/{id}</c>, but is otherwise the
    /// same as <see cref="IRoutingStrategyService.Retrieve(RoutingStrategyRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RoutingStrategyGetResponse>> Retrieve(
        RoutingStrategyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(RoutingStrategyRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<RoutingStrategyGetResponse>> Retrieve(
        string id,
        RoutingStrategyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /routing-strategies</c>, but is otherwise the
    /// same as <see cref="IRoutingStrategyService.List(RoutingStrategyListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RoutingStrategyListResponse>> List(
        RoutingStrategyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /routing-strategies/{id}</c>, but is otherwise the
    /// same as <see cref="IRoutingStrategyService.Archive(RoutingStrategyArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Archive(
        RoutingStrategyArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(RoutingStrategyArchiveParams, CancellationToken)"/>
    Task<HttpResponse> Archive(
        string id,
        RoutingStrategyArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /routing-strategies/{id}/notifications</c>, but is otherwise the
    /// same as <see cref="IRoutingStrategyService.ListNotifications(RoutingStrategyListNotificationsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AssociatedNotificationListResponse>> ListNotifications(
        RoutingStrategyListNotificationsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListNotifications(RoutingStrategyListNotificationsParams, CancellationToken)"/>
    Task<HttpResponse<AssociatedNotificationListResponse>> ListNotifications(
        string id,
        RoutingStrategyListNotificationsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /routing-strategies/{id}</c>, but is otherwise the
    /// same as <see cref="IRoutingStrategyService.Replace(RoutingStrategyReplaceParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RoutingStrategyGetResponse>> Replace(
        RoutingStrategyReplaceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Replace(RoutingStrategyReplaceParams, CancellationToken)"/>
    Task<HttpResponse<RoutingStrategyGetResponse>> Replace(
        string id,
        RoutingStrategyReplaceParams parameters,
        CancellationToken cancellationToken = default
    );
}
