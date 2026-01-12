using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Automations;
using Courier.Services.Automations;

namespace Courier.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAutomationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAutomationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAutomationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IInvokeService Invoke { get; }

    /// <summary>
    /// Get the list of automations.
    /// </summary>
    Task<AutomationTemplateListResponse> List(
        AutomationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAutomationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAutomationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAutomationServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IInvokeServiceWithRawResponse Invoke { get; }

    /// <summary>
    /// Returns a raw HTTP response for `get /automations`, but is otherwise the
    /// same as <see cref="IAutomationService.List(AutomationListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AutomationTemplateListResponse>> List(
        AutomationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
