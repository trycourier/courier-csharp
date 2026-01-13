using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Profiles;
using Profiles = Courier.Services.Profiles;

namespace Courier.Services;

/// <inheritdoc/>
public sealed class ProfileService : IProfileService
{
    readonly Lazy<IProfileServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IProfileServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public IProfileService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ProfileService(this._client.WithOptions(modifier));
    }

    public ProfileService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ProfileServiceWithRawResponse(client.WithRawResponse));
        _lists = new(() => new Profiles::ListService(client));
    }

    readonly Lazy<Profiles::IListService> _lists;
    public Profiles::IListService Lists
    {
        get { return _lists.Value; }
    }

    /// <inheritdoc/>
    public async Task<ProfileCreateResponse> Create(
        ProfileCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ProfileCreateResponse> Create(
        string userID,
        ProfileCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ProfileRetrieveResponse> Retrieve(
        ProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ProfileRetrieveResponse> Retrieve(
        string userID,
        ProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Update(
        ProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Update(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Update(
        string userID,
        ProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Update(parameters with { UserID = userID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        ProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string userID,
        ProfileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { UserID = userID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ProfileReplaceResponse> Replace(
        ProfileReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Replace(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ProfileReplaceResponse> Replace(
        string userID,
        ProfileReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Replace(parameters with { UserID = userID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ProfileServiceWithRawResponse : IProfileServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public IProfileServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ProfileServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ProfileServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;

        _lists = new(() => new Profiles::ListServiceWithRawResponse(client));
    }

    readonly Lazy<Profiles::IListServiceWithRawResponse> _lists;
    public Profiles::IListServiceWithRawResponse Lists
    {
        get { return _lists.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ProfileCreateResponse>> Create(
        ProfileCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserID == null)
        {
            throw new CourierInvalidDataException("'parameters.UserID' cannot be null");
        }

        HttpRequest<ProfileCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var profile = await response
                    .Deserialize<ProfileCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    profile.Validate();
                }
                return profile;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ProfileCreateResponse>> Create(
        string userID,
        ProfileCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ProfileRetrieveResponse>> Retrieve(
        ProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserID == null)
        {
            throw new CourierInvalidDataException("'parameters.UserID' cannot be null");
        }

        HttpRequest<ProfileRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var profile = await response
                    .Deserialize<ProfileRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    profile.Validate();
                }
                return profile;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ProfileRetrieveResponse>> Retrieve(
        string userID,
        ProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        ProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserID == null)
        {
            throw new CourierInvalidDataException("'parameters.UserID' cannot be null");
        }

        HttpRequest<ProfileUpdateParams> request = new()
        {
            Method = CourierClient.PatchMethod,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        string userID,
        ProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        ProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserID == null)
        {
            throw new CourierInvalidDataException("'parameters.UserID' cannot be null");
        }

        HttpRequest<ProfileDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string userID,
        ProfileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ProfileReplaceResponse>> Replace(
        ProfileReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserID == null)
        {
            throw new CourierInvalidDataException("'parameters.UserID' cannot be null");
        }

        HttpRequest<ProfileReplaceParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<ProfileReplaceResponse>(token)
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
    public Task<HttpResponse<ProfileReplaceResponse>> Replace(
        string userID,
        ProfileReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Replace(parameters with { UserID = userID }, cancellationToken);
    }
}
