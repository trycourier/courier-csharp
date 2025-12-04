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
    /// <inheritdoc/>
    public IProfileService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ProfileService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public ProfileService(ICourierClient client)
    {
        _client = client;
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
        if (parameters.UserID == null)
        {
            throw new CourierInvalidDataException("'parameters.UserID' cannot be null");
        }

        HttpRequest<ProfileCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var profile = await response
            .Deserialize<ProfileCreateResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            profile.Validate();
        }
        return profile;
    }

    /// <inheritdoc/>
    public async Task<ProfileCreateResponse> Create(
        string userID,
        ProfileCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.Create(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ProfileRetrieveResponse> Retrieve(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var profile = await response
            .Deserialize<ProfileRetrieveResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            profile.Validate();
        }
        return profile;
    }

    /// <inheritdoc/>
    public async Task<ProfileRetrieveResponse> Retrieve(
        string userID,
        ProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Update(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Update(
        string userID,
        ProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Update(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string userID,
        ProfileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ProfileReplaceResponse> Replace(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<ProfileReplaceResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<ProfileReplaceResponse> Replace(
        string userID,
        ProfileReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.Replace(parameters with { UserID = userID }, cancellationToken);
    }
}
