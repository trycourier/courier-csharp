using System;
using System.Net.Http;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Profiles;
using Courier.Services.Profiles.Lists;

namespace Courier.Services.Profiles;

public sealed class ProfileService : IProfileService
{
    readonly ICourierClient _client;

    public ProfileService(ICourierClient client)
    {
        _client = client;
        _lists = new(() => new ListService(client));
    }

    readonly Lazy<IListService> _lists;
    public IListService Lists
    {
        get { return _lists.Value; }
    }

    public async Task<ProfileCreateResponse> Create(ProfileCreateParams parameters)
    {
        HttpRequest<ProfileCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<ProfileCreateResponse>().ConfigureAwait(false);
    }

    public async Task<ProfileRetrieveResponse> Retrieve(ProfileRetrieveParams parameters)
    {
        HttpRequest<ProfileRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<ProfileRetrieveResponse>().ConfigureAwait(false);
    }

    public async Task Update(ProfileUpdateParams parameters)
    {
        HttpRequest<ProfileUpdateParams> request = new()
        {
            Method = HttpMethod.Patch,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }

    public async Task Delete(ProfileDeleteParams parameters)
    {
        HttpRequest<ProfileDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }

    public async Task<ProfileReplaceResponse> Replace(ProfileReplaceParams parameters)
    {
        HttpRequest<ProfileReplaceParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<ProfileReplaceResponse>().ConfigureAwait(false);
    }
}
