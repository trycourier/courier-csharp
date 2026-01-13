using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Notifications.Checks;

namespace Courier.Services.Notifications;

/// <inheritdoc/>
public sealed class CheckService : ICheckService
{
    readonly Lazy<ICheckServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICheckServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public ICheckService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CheckService(this._client.WithOptions(modifier));
    }

    public CheckService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CheckServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<CheckUpdateResponse> Update(
        CheckUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CheckUpdateResponse> Update(
        string submissionID,
        CheckUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { SubmissionID = submissionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CheckListResponse> List(
        CheckListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CheckListResponse> List(
        string submissionID,
        CheckListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.List(parameters with { SubmissionID = submissionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Delete(CheckDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string submissionID,
        CheckDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Delete(parameters with { SubmissionID = submissionID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class CheckServiceWithRawResponse : ICheckServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICheckServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CheckServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CheckServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CheckUpdateResponse>> Update(
        CheckUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SubmissionID == null)
        {
            throw new CourierInvalidDataException("'parameters.SubmissionID' cannot be null");
        }

        HttpRequest<CheckUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var check = await response
                    .Deserialize<CheckUpdateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    check.Validate();
                }
                return check;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CheckUpdateResponse>> Update(
        string submissionID,
        CheckUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { SubmissionID = submissionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CheckListResponse>> List(
        CheckListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SubmissionID == null)
        {
            throw new CourierInvalidDataException("'parameters.SubmissionID' cannot be null");
        }

        HttpRequest<CheckListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var checks = await response
                    .Deserialize<CheckListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    checks.Validate();
                }
                return checks;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CheckListResponse>> List(
        string submissionID,
        CheckListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.List(parameters with { SubmissionID = submissionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        CheckDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SubmissionID == null)
        {
            throw new CourierInvalidDataException("'parameters.SubmissionID' cannot be null");
        }

        HttpRequest<CheckDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string submissionID,
        CheckDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { SubmissionID = submissionID }, cancellationToken);
    }
}
