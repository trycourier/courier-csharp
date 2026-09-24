using System;
using TryCourier.Core;
using TryCourier.Services.Notifications.Previews;

namespace TryCourier.Services.Notifications;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPreviewService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPreviewServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPreviewService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IRunService Runs { get; }
}

/// <summary>
/// A view of <see cref="IPreviewService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPreviewServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPreviewServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IRunServiceWithRawResponse Runs { get; }
}
