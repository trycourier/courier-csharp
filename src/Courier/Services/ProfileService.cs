using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Profiles;
using Profiles = Courier.Services.Profiles;

namespace Courier.Services;

public sealed class ProfileService : IProfileService
{
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

    public async Task<ProfileCreateResponse> Create(
        ProfileCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
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

    public async Task<ProfileRetrieveResponse> Retrieve(
        ProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
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

    public async Task Update(
        ProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ProfileUpdateParams> request = new()
        {
            Method = HttpMethod.Patch,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task Delete(
        ProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ProfileDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task<ProfileReplaceResponse> Replace(
        ProfileReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
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
}
