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
    IPreferenceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IItemService Items { get; }
}
