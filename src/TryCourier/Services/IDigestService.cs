using System;
using TryCourier.Core;
using TryCourier.Services.Digests;

namespace TryCourier.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IDigestService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDigestServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDigestService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IScheduleService Schedules { get; }
}

/// <summary>
/// A view of <see cref="IDigestService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDigestServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDigestServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IScheduleServiceWithRawResponse Schedules { get; }
}
