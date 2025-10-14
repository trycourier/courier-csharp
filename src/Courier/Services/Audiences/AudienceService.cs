using System.Net.Http;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models;
using Courier.Models.Audiences;

namespace Courier.Services.Audiences;

public sealed class AudienceService : IAudienceService
{
    readonly ICourierClient _client;

    public AudienceService(ICourierClient client)
    {
        _client = client;
    }

    public async Task<Audience> Retrieve(AudienceRetrieveParams parameters)
    {
        HttpRequest<AudienceRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Audience>().ConfigureAwait(false);
    }

    public async Task<AudienceUpdateResponse> Update(AudienceUpdateParams parameters)
    {
        HttpRequest<AudienceUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<AudienceUpdateResponse>().ConfigureAwait(false);
    }

    public async Task<AudienceListResponse> List(AudienceListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<AudienceListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<AudienceListResponse>().ConfigureAwait(false);
    }

    public async Task Delete(AudienceDeleteParams parameters)
    {
        HttpRequest<AudienceDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }

    public async Task<AudienceListMembersResponse> ListMembers(AudienceListMembersParams parameters)
    {
        HttpRequest<AudienceListMembersParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<AudienceListMembersResponse>().ConfigureAwait(false);
    }
}
