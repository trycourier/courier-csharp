using System;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Models.Broadcasts;
using TryCourier.Models.Notifications;

namespace TryCourier.Services;

/// <summary>
/// Create a one-off send to a list or audience, author its content, then send it
/// immediately or schedule it for later.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IBroadcastService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBroadcastServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBroadcastService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a broadcast. Provisions a private notification template for the broadcast
    /// and returns the new broadcast in the draft state. Exactly one channel is
    /// required.
    /// </summary>
    Task<Broadcast> Create(
        BroadcastCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a broadcast by ID. Archived broadcasts return 404.
    /// </summary>
    Task<Broadcast> Retrieve(
        BroadcastRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(BroadcastRetrieveParams, CancellationToken)"/>
    Task<Broadcast> Retrieve(
        string broadcastID,
        BroadcastRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a broadcast's name. Content is edited via the broadcast's notification
    /// template, not this endpoint.
    /// </summary>
    Task<Broadcast> Update(
        BroadcastUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(BroadcastUpdateParams, CancellationToken)"/>
    Task<Broadcast> Update(
        string broadcastID,
        BroadcastUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List broadcasts in your workspace. Cursor-paginated; returns broadcasts
    /// newest-first.
    /// </summary>
    Task<BroadcastListResponse> List(
        BroadcastListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Archive a broadcast. This is a soft delete — the archived broadcast is returned
    /// and no longer appears in list results.
    /// </summary>
    Task<Broadcast> Archive(
        BroadcastArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(BroadcastArchiveParams, CancellationToken)"/>
    Task<Broadcast> Archive(
        string broadcastID,
        BroadcastArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancel a broadcast's pending schedule, returning it to the draft state. Only
    /// valid for a scheduled broadcast.
    /// </summary>
    Task<Broadcast> Cancel(
        BroadcastCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(BroadcastCancelParams, CancellationToken)"/>
    Task<Broadcast> Cancel(
        string broadcastID,
        BroadcastCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Duplicate a broadcast (and its template) into a new draft named "{source name}
    /// (copy)".
    /// </summary>
    Task<Broadcast> Duplicate(
        BroadcastDuplicateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Duplicate(BroadcastDuplicateParams, CancellationToken)"/>
    Task<Broadcast> Duplicate(
        string broadcastID,
        BroadcastDuplicateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Author the broadcast's content by replacing the draft elemental content of its
    /// private notification template. The draft is published automatically when the
    /// broadcast is sent or scheduled.
    /// </summary>
    Task<NotificationContentMutationResponse> PutContent(
        BroadcastPutContentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="PutContent(BroadcastPutContentParams, CancellationToken)"/>
    Task<NotificationContentMutationResponse> PutContent(
        string broadcastID,
        BroadcastPutContentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve the broadcast's content — the elemental content of its private
    /// notification template. Defaults to the working draft, since broadcast content is
    /// authored as a draft until the broadcast is sent.
    /// </summary>
    Task<NotificationContentGetResponse> RetrieveContent(
        BroadcastRetrieveContentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveContent(BroadcastRetrieveContentParams, CancellationToken)"/>
    Task<NotificationContentGetResponse> RetrieveContent(
        string broadcastID,
        BroadcastRetrieveContentParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Schedule a broadcast for a future send to a list or audience. Publishes the
    /// broadcast template first. Not allowed once the broadcast is sending or sent. For
    /// an immediate send use POST /broadcasts/{broadcastId}/send.
    /// </summary>
    Task<Broadcast> Schedule(
        BroadcastScheduleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Schedule(BroadcastScheduleParams, CancellationToken)"/>
    Task<Broadcast> Schedule(
        string broadcastID,
        BroadcastScheduleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Send a broadcast immediately to a list or audience. Publishes the broadcast
    /// template first. Not allowed once the broadcast is sending or sent.
    /// </summary>
    Task<Broadcast> Send(
        BroadcastSendParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Send(BroadcastSendParams, CancellationToken)"/>
    Task<Broadcast> Send(
        string broadcastID,
        BroadcastSendParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IBroadcastService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBroadcastServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBroadcastServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /broadcasts</c>, but is otherwise the
    /// same as <see cref="IBroadcastService.Create(BroadcastCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Broadcast>> Create(
        BroadcastCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /broadcasts/{broadcastId}</c>, but is otherwise the
    /// same as <see cref="IBroadcastService.Retrieve(BroadcastRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Broadcast>> Retrieve(
        BroadcastRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(BroadcastRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Broadcast>> Retrieve(
        string broadcastID,
        BroadcastRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /broadcasts/{broadcastId}</c>, but is otherwise the
    /// same as <see cref="IBroadcastService.Update(BroadcastUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Broadcast>> Update(
        BroadcastUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(BroadcastUpdateParams, CancellationToken)"/>
    Task<HttpResponse<Broadcast>> Update(
        string broadcastID,
        BroadcastUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /broadcasts</c>, but is otherwise the
    /// same as <see cref="IBroadcastService.List(BroadcastListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BroadcastListResponse>> List(
        BroadcastListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /broadcasts/{broadcastId}</c>, but is otherwise the
    /// same as <see cref="IBroadcastService.Archive(BroadcastArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Broadcast>> Archive(
        BroadcastArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(BroadcastArchiveParams, CancellationToken)"/>
    Task<HttpResponse<Broadcast>> Archive(
        string broadcastID,
        BroadcastArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /broadcasts/{broadcastId}/cancel</c>, but is otherwise the
    /// same as <see cref="IBroadcastService.Cancel(BroadcastCancelParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Broadcast>> Cancel(
        BroadcastCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(BroadcastCancelParams, CancellationToken)"/>
    Task<HttpResponse<Broadcast>> Cancel(
        string broadcastID,
        BroadcastCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /broadcasts/{broadcastId}/duplicate</c>, but is otherwise the
    /// same as <see cref="IBroadcastService.Duplicate(BroadcastDuplicateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Broadcast>> Duplicate(
        BroadcastDuplicateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Duplicate(BroadcastDuplicateParams, CancellationToken)"/>
    Task<HttpResponse<Broadcast>> Duplicate(
        string broadcastID,
        BroadcastDuplicateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /broadcasts/{broadcastId}/content</c>, but is otherwise the
    /// same as <see cref="IBroadcastService.PutContent(BroadcastPutContentParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<NotificationContentMutationResponse>> PutContent(
        BroadcastPutContentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="PutContent(BroadcastPutContentParams, CancellationToken)"/>
    Task<HttpResponse<NotificationContentMutationResponse>> PutContent(
        string broadcastID,
        BroadcastPutContentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /broadcasts/{broadcastId}/content</c>, but is otherwise the
    /// same as <see cref="IBroadcastService.RetrieveContent(BroadcastRetrieveContentParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<NotificationContentGetResponse>> RetrieveContent(
        BroadcastRetrieveContentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveContent(BroadcastRetrieveContentParams, CancellationToken)"/>
    Task<HttpResponse<NotificationContentGetResponse>> RetrieveContent(
        string broadcastID,
        BroadcastRetrieveContentParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /broadcasts/{broadcastId}/schedule</c>, but is otherwise the
    /// same as <see cref="IBroadcastService.Schedule(BroadcastScheduleParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Broadcast>> Schedule(
        BroadcastScheduleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Schedule(BroadcastScheduleParams, CancellationToken)"/>
    Task<HttpResponse<Broadcast>> Schedule(
        string broadcastID,
        BroadcastScheduleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /broadcasts/{broadcastId}/send</c>, but is otherwise the
    /// same as <see cref="IBroadcastService.Send(BroadcastSendParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Broadcast>> Send(
        BroadcastSendParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Send(BroadcastSendParams, CancellationToken)"/>
    Task<HttpResponse<Broadcast>> Send(
        string broadcastID,
        BroadcastSendParams parameters,
        CancellationToken cancellationToken = default
    );
}
