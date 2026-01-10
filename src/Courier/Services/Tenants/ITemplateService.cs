using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Tenants;
using Courier.Models.Tenants.Templates;

namespace Courier.Services.Tenants;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ITemplateService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITemplateServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITemplateService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get a Template in Tenant
    /// </summary>
    Task<BaseTemplateTenantAssociation> Retrieve(
        TemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TemplateRetrieveParams, CancellationToken)"/>
    Task<BaseTemplateTenantAssociation> Retrieve(
        string templateID,
        TemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Templates in Tenant
    /// </summary>
    Task<TemplateListResponse> List(
        TemplateListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(TemplateListParams, CancellationToken)"/>
    Task<TemplateListResponse> List(
        string tenantID,
        TemplateListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITemplateService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITemplateServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITemplateServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /tenants/{tenant_id}/templates/{template_id}`, but is otherwise the
    /// same as <see cref="ITemplateService.Retrieve(TemplateRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BaseTemplateTenantAssociation>> Retrieve(
        TemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TemplateRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BaseTemplateTenantAssociation>> Retrieve(
        string templateID,
        TemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /tenants/{tenant_id}/templates`, but is otherwise the
    /// same as <see cref="ITemplateService.List(TemplateListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TemplateListResponse>> List(
        TemplateListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(TemplateListParams, CancellationToken)"/>
    Task<HttpResponse<TemplateListResponse>> List(
        string tenantID,
        TemplateListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
