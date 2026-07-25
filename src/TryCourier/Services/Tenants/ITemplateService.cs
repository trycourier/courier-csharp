using System;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Models.Tenants;
using TryCourier.Models.Tenants.Templates;
using TryCourier.Services.Tenants.Templates;

namespace TryCourier.Services.Tenants;

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
    /// Returns a tenant's notification template with its content, version, and created,
    /// updated, and published timestamps.
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
    /// Lists a tenant's notification templates, each carrying its version and published
    /// timestamp. Paged.
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
    /// Deletes a tenant's notification template by id. Sends for that tenant then use
    /// the workspace template registered under the same id.
    /// </summary>
    Task Delete(TemplateDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(TemplateDeleteParams, CancellationToken)"/>
    Task Delete(
        string templateID,
        TemplateDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Publishes a version of a tenant's notification template, making it the content
    /// that tenant's sends render from until you publish another.
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
    /// Creates or updates a notification template scoped to one tenant, letting a
    /// tenant override the content the workspace template would send.
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
    /// Returns a raw HTTP response for <c>get /tenants/{tenant_id}/templates/{template_id}</c>, but is otherwise the
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
    /// Returns a raw HTTP response for <c>get /tenants/{tenant_id}/templates</c>, but is otherwise the
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
    /// Returns a raw HTTP response for <c>delete /tenants/{tenant_id}/templates/{template_id}</c>, but is otherwise the
    /// same as <see cref="ITemplateService.Delete(TemplateDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        TemplateDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(TemplateDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string templateID,
        TemplateDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /tenants/{tenant_id}/templates/{template_id}/publish</c>, but is otherwise the
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
    /// Returns a raw HTTP response for <c>put /tenants/{tenant_id}/templates/{template_id}</c>, but is otherwise the
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
