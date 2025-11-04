using System.Net.Http;
using System.Threading.Tasks;
using Courier.Core;
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
        var audience = await response.Deserialize<Audience>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            audience.Validate();
        }
        return audience;
    }

    public async Task<AudienceUpdateResponse> Update(AudienceUpdateParams parameters)
    {
        HttpRequest<AudienceUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var audience = await response.Deserialize<AudienceUpdateResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            audience.Validate();
        }
        return audience;
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
        var audiences = await response.Deserialize<AudienceListResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            audiences.Validate();
        }
        return audiences;
    }

    public async Task Delete(AudienceDeleteParams parameters)
    {
        HttpRequest<AudienceDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
    }

    public async Task<AudienceListMembersResponse> ListMembers(AudienceListMembersParams parameters)
    {
        HttpRequest<AudienceListMembersParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<AudienceListMembersResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
