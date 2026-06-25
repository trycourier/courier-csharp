using System;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Models.Notifications.Checks;

namespace TryCourier.Services.Notifications;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICheckService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICheckServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICheckService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Replace the checks for a notification template submission.
    /// </summary>
    Task<CheckUpdateResponse> Update(
        CheckUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(CheckUpdateParams, CancellationToken)"/>
    Task<CheckUpdateResponse> Update(
        string submissionID,
        CheckUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve the submission checks for a notification template.
    /// </summary>
    Task<CheckListResponse> List(
        CheckListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(CheckListParams, CancellationToken)"/>
    Task<CheckListResponse> List(
        string submissionID,
        CheckListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancel a notification template submission.
    /// </summary>
    Task Delete(CheckDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(CheckDeleteParams, CancellationToken)"/>
    Task Delete(
        string submissionID,
        CheckDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICheckService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICheckServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICheckServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>put /notifications/{id}/{submissionId}/checks</c>, but is otherwise the
    /// same as <see cref="ICheckService.Update(CheckUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CheckUpdateResponse>> Update(
        CheckUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(CheckUpdateParams, CancellationToken)"/>
    Task<HttpResponse<CheckUpdateResponse>> Update(
        string submissionID,
        CheckUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /notifications/{id}/{submissionId}/checks</c>, but is otherwise the
    /// same as <see cref="ICheckService.List(CheckListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CheckListResponse>> List(
        CheckListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(CheckListParams, CancellationToken)"/>
    Task<HttpResponse<CheckListResponse>> List(
        string submissionID,
        CheckListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /notifications/{id}/{submissionId}/checks</c>, but is otherwise the
    /// same as <see cref="ICheckService.Delete(CheckDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        CheckDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(CheckDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string submissionID,
        CheckDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}
