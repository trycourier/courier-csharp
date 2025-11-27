using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Notifications.Checks;

namespace Courier.Services.Notifications;

/// <inheritdoc />
public sealed class CheckService : ICheckService
{
    /// <inheritdoc/>
    public ICheckService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CheckService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public CheckService(ICourierClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<CheckUpdateResponse> Update(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var check = await response
            .Deserialize<CheckUpdateResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            check.Validate();
        }
        return check;
    }

    /// <inheritdoc/>
    public async Task<CheckUpdateResponse> Update(
        string submissionID,
        CheckUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.Update(
            parameters with
            {
                SubmissionID = submissionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<CheckListResponse> List(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var checks = await response
            .Deserialize<CheckListResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            checks.Validate();
        }
        return checks;
    }

    /// <inheritdoc/>
    public async Task<CheckListResponse> List(
        string submissionID,
        CheckListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.List(parameters with { SubmissionID = submissionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string submissionID,
        CheckDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Delete(parameters with { SubmissionID = submissionID }, cancellationToken);
    }
}
