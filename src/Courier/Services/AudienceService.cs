using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Audiences;

namespace Courier.Services;

/// <inheritdoc/>
public sealed class AudienceService : IAudienceService
{
    /// <inheritdoc/>
    public IAudienceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AudienceService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public AudienceService(ICourierClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<Audience> Retrieve(
        AudienceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AudienceID == null)
        {
            throw new CourierInvalidDataException("'parameters.AudienceID' cannot be null");
        }

        HttpRequest<AudienceRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var audience = await response
            .Deserialize<Audience>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            audience.Validate();
        }
        return audience;
    }

    /// <inheritdoc/>
    public async Task<Audience> Retrieve(
        string audienceID,
        AudienceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(parameters with { AudienceID = audienceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AudienceUpdateResponse> Update(
        AudienceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AudienceID == null)
        {
            throw new CourierInvalidDataException("'parameters.AudienceID' cannot be null");
        }

        HttpRequest<AudienceUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var audience = await response
            .Deserialize<AudienceUpdateResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            audience.Validate();
        }
        return audience;
    }

    /// <inheritdoc/>
    public async Task<AudienceUpdateResponse> Update(
        string audienceID,
        AudienceUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Update(parameters with { AudienceID = audienceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AudienceListResponse> List(
        AudienceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AudienceListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var audiences = await response
            .Deserialize<AudienceListResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            audiences.Validate();
        }
        return audiences;
    }

    /// <inheritdoc/>
    public async Task Delete(
        AudienceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AudienceID == null)
        {
            throw new CourierInvalidDataException("'parameters.AudienceID' cannot be null");
        }

        HttpRequest<AudienceDeleteParams> request = new()
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
        string audienceID,
        AudienceDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { AudienceID = audienceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AudienceListMembersResponse> ListMembers(
        AudienceListMembersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AudienceID == null)
        {
            throw new CourierInvalidDataException("'parameters.AudienceID' cannot be null");
        }

        HttpRequest<AudienceListMembersParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<AudienceListMembersResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<AudienceListMembersResponse> ListMembers(
        string audienceID,
        AudienceListMembersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.ListMembers(
            parameters with
            {
                AudienceID = audienceID,
            },
            cancellationToken
        );
    }
}
