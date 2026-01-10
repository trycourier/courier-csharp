using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Tenants.Preferences.Items;

namespace Courier.Services.Tenants.Preferences;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IItemService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IItemServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IItemService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create or Replace Default Preferences For Topic
    /// </summary>
    Task Update(ItemUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Update(ItemUpdateParams, CancellationToken)"/>
    Task Update(
        string topicID,
        ItemUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove Default Preferences For Topic
    /// </summary>
    Task Delete(ItemDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(ItemDeleteParams, CancellationToken)"/>
    Task Delete(
        string topicID,
        ItemDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IItemService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IItemServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IItemServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `put /tenants/{tenant_id}/default_preferences/items/{topic_id}`, but is otherwise the
    /// same as <see cref="IItemService.Update(ItemUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Update(
        ItemUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ItemUpdateParams, CancellationToken)"/>
    Task<HttpResponse> Update(
        string topicID,
        ItemUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /tenants/{tenant_id}/default_preferences/items/{topic_id}`, but is otherwise the
    /// same as <see cref="IItemService.Delete(ItemDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        ItemDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ItemDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string topicID,
        ItemDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}
