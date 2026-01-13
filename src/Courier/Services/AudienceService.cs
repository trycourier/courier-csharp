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
    readonly Lazy<IAudienceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAudienceServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public IAudienceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AudienceService(this._client.WithOptions(modifier));
    }

    public AudienceService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AudienceServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Audience> Retrieve(
        AudienceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Audience> Retrieve(
        string audienceID,
        AudienceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { AudienceID = audienceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AudienceUpdateResponse> Update(
        AudienceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AudienceUpdateResponse> Update(
        string audienceID,
        AudienceUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { AudienceID = audienceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AudienceListResponse> List(
        AudienceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        AudienceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string audienceID,
        AudienceDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { AudienceID = audienceID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AudienceListMembersResponse> ListMembers(
        AudienceListMembersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListMembers(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AudienceListMembersResponse> ListMembers(
        string audienceID,
        AudienceListMembersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListMembers(parameters with { AudienceID = audienceID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class AudienceServiceWithRawResponse : IAudienceServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAudienceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AudienceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AudienceServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Audience>> Retrieve(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var audience = await response.Deserialize<Audience>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    audience.Validate();
                }
                return audience;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Audience>> Retrieve(
        string audienceID,
        AudienceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { AudienceID = audienceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AudienceUpdateResponse>> Update(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var audience = await response
                    .Deserialize<AudienceUpdateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    audience.Validate();
                }
                return audience;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AudienceUpdateResponse>> Update(
        string audienceID,
        AudienceUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { AudienceID = audienceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AudienceListResponse>> List(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var audiences = await response
                    .Deserialize<AudienceListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    audiences.Validate();
                }
                return audiences;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
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
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string audienceID,
        AudienceDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { AudienceID = audienceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AudienceListMembersResponse>> ListMembers(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<AudienceListMembersResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AudienceListMembersResponse>> ListMembers(
        string audienceID,
        AudienceListMembersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListMembers(parameters with { AudienceID = audienceID }, cancellationToken);
    }
}
