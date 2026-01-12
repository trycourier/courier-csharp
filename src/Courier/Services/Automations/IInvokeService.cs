using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Automations;
using Courier.Models.Automations.Invoke;

namespace Courier.Services.Automations;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IInvokeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInvokeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInvokeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Invoke an ad hoc automation run. This endpoint accepts a JSON payload with
    /// a series of automation steps. For information about what steps are available,
    /// checkout the ad hoc automation guide [here](https://www.courier.com/docs/automations/steps/).
    /// </summary>
    Task<AutomationInvokeResponse> InvokeAdHoc(
        InvokeInvokeAdHocParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Invoke an automation run from an automation template.
    /// </summary>
    Task<AutomationInvokeResponse> InvokeByTemplate(
        InvokeInvokeByTemplateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="InvokeByTemplate(InvokeInvokeByTemplateParams, CancellationToken)"/>
    Task<AutomationInvokeResponse> InvokeByTemplate(
        string templateID,
        InvokeInvokeByTemplateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IInvokeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInvokeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInvokeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /automations/invoke`, but is otherwise the
    /// same as <see cref="IInvokeService.InvokeAdHoc(InvokeInvokeAdHocParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AutomationInvokeResponse>> InvokeAdHoc(
        InvokeInvokeAdHocParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /automations/{templateId}/invoke`, but is otherwise the
    /// same as <see cref="IInvokeService.InvokeByTemplate(InvokeInvokeByTemplateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AutomationInvokeResponse>> InvokeByTemplate(
        InvokeInvokeByTemplateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="InvokeByTemplate(InvokeInvokeByTemplateParams, CancellationToken)"/>
    Task<HttpResponse<AutomationInvokeResponse>> InvokeByTemplate(
        string templateID,
        InvokeInvokeByTemplateParams parameters,
        CancellationToken cancellationToken = default
    );
}
