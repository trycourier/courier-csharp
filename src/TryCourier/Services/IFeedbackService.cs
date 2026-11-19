using System;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Models.Feedback;

namespace TryCourier.Services;

/// <summary>
/// Report suspected bugs, confusing behavior and missing features in Courier, from
/// an AI agent, a developer tool or by hand.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IFeedbackService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IFeedbackServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFeedbackService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Reports a suspected bug, confusing behavior or a missing feature in Courier. It
    /// is built for AI agents and developer tools to call when Courier does something
    /// unexpected, and people can call it too.
    ///
    /// <para>A report is not a support ticket. A `201` means Courier stored the report;
    /// it does not promise a reply or a fix. For help with your account, contact
    /// Courier support.</para>
    ///
    /// <para>Never include secrets, API keys or customer data such as recipient names,
    /// email addresses or message content.</para>
    ///
    /// <para>Requires an API key with no scope restrictions; a JWT or a scoped API key
    /// is refused. Each workspace can submit 200 reports per UTC day, and requests that
    /// fail validation count toward that limit.</para>
    /// </summary>
    Task<FeedbackCreateResponse> Create(
        FeedbackCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IFeedbackService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IFeedbackServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFeedbackServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /feedback</c>, but is otherwise the
    /// same as <see cref="IFeedbackService.Create(FeedbackCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FeedbackCreateResponse>> Create(
        FeedbackCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
