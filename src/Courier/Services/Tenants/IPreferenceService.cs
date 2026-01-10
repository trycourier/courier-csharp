using System;
using Courier.Core;
using Courier.Services.Tenants.Preferences;

namespace Courier.Services.Tenants;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPreferenceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPreferenceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPreferenceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IItemService Items { get; }
}

/// <summary>
/// A view of <see cref="IPreferenceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPreferenceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPreferenceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IItemServiceWithRawResponse Items { get; }
}
