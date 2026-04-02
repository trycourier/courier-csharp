using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Journeys;

namespace Courier.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IJourneyService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IJourneyServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IJourneyService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get the list of journeys.
    /// </summary>
    Task<JourneysListResponse> List(
        JourneyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Invoke a journey run from a journey template.
    /// </summary>
    Task<JourneysInvokeResponse> Invoke(
        JourneyInvokeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Invoke(JourneyInvokeParams, CancellationToken)"/>
    Task<JourneysInvokeResponse> Invoke(
        string templateID,
        JourneyInvokeParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IJourneyService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IJourneyServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IJourneyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /journeys</c>, but is otherwise the
    /// same as <see cref="IJourneyService.List(JourneyListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<JourneysListResponse>> List(
        JourneyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /journeys/{templateId}/invoke</c>, but is otherwise the
    /// same as <see cref="IJourneyService.Invoke(JourneyInvokeParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<JourneysInvokeResponse>> Invoke(
        JourneyInvokeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Invoke(JourneyInvokeParams, CancellationToken)"/>
    Task<HttpResponse<JourneysInvokeResponse>> Invoke(
        string templateID,
        JourneyInvokeParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
