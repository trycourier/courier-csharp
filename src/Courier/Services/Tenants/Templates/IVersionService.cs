using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Tenants;
using Courier.Models.Tenants.Templates.Versions;

namespace Courier.Services.Tenants.Templates;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IVersionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IVersionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVersionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Fetches a specific version of a tenant template.
    ///
    /// <para>Supports the following version formats: - `latest` - The most recent
    /// version of the template - `published` - The currently published version -
    /// `v{version}` - A specific version (e.g., "v1", "v2", "v1.0.0")</para>
    /// </summary>
    Task<BaseTemplateTenantAssociation> Retrieve(
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(VersionRetrieveParams, CancellationToken)"/>
    Task<BaseTemplateTenantAssociation> Retrieve(
        string version,
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IVersionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IVersionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVersionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /tenants/{tenant_id}/templates/{template_id}/versions/{version}`, but is otherwise the
    /// same as <see cref="IVersionService.Retrieve(VersionRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BaseTemplateTenantAssociation>> Retrieve(
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(VersionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BaseTemplateTenantAssociation>> Retrieve(
        string version,
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );
}
