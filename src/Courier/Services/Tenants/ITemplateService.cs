using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Tenants;
using Courier.Models.Tenants.Templates;
using Courier.Services.Tenants.Templates;

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

    IVersionService Versions { get; }

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

    /// <summary>
    /// Publishes a specific version of a notification template for a tenant.
    ///
    /// <para>The template must already exist in the tenant's notification map. If
    /// no version is specified, defaults to publishing the "latest" version.</para>
    /// </summary>
    Task<PostTenantTemplatePublishResponse> Publish(
        TemplatePublishParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Publish(TemplatePublishParams, CancellationToken)"/>
    Task<PostTenantTemplatePublishResponse> Publish(
        string templateID,
        TemplatePublishParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates or updates a notification template for a tenant.
    ///
    /// <para>If the template already exists for the tenant, it will be updated (200).
    /// Otherwise, a new template is created (201).</para>
    ///
    /// <para>Optionally publishes the template immediately if the `published` flag
    /// is set to true.</para>
    /// </summary>
    Task<PutTenantTemplateResponse> Replace(
        TemplateReplaceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Replace(TemplateReplaceParams, CancellationToken)"/>
    Task<PutTenantTemplateResponse> Replace(
        string templateID,
        TemplateReplaceParams parameters,
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

    IVersionServiceWithRawResponse Versions { get; }

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

    /// <summary>
    /// Returns a raw HTTP response for `post /tenants/{tenant_id}/templates/{template_id}/publish`, but is otherwise the
    /// same as <see cref="ITemplateService.Publish(TemplatePublishParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PostTenantTemplatePublishResponse>> Publish(
        TemplatePublishParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Publish(TemplatePublishParams, CancellationToken)"/>
    Task<HttpResponse<PostTenantTemplatePublishResponse>> Publish(
        string templateID,
        TemplatePublishParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `put /tenants/{tenant_id}/templates/{template_id}`, but is otherwise the
    /// same as <see cref="ITemplateService.Replace(TemplateReplaceParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PutTenantTemplateResponse>> Replace(
        TemplateReplaceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Replace(TemplateReplaceParams, CancellationToken)"/>
    Task<HttpResponse<PutTenantTemplateResponse>> Replace(
        string templateID,
        TemplateReplaceParams parameters,
        CancellationToken cancellationToken = default
    );
}
