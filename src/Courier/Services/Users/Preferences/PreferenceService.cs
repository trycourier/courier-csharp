using System;
using System.Net.Http;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Users.Preferences;

namespace Courier.Services.Users.Preferences;

public sealed class PreferenceService : IPreferenceService
{
    public IPreferenceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PreferenceService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public PreferenceService(ICourierClient client)
    {
        _client = client;
    }

    public async Task<PreferenceRetrieveResponse> Retrieve(PreferenceRetrieveParams parameters)
    {
        HttpRequest<PreferenceRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var preference = await response
            .Deserialize<PreferenceRetrieveResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            preference.Validate();
        }
        return preference;
    }

    public async Task<PreferenceRetrieveTopicResponse> RetrieveTopic(
        PreferenceRetrieveTopicParams parameters
    )
    {
        HttpRequest<PreferenceRetrieveTopicParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<PreferenceRetrieveTopicResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    public async Task<PreferenceUpdateOrCreateTopicResponse> UpdateOrCreateTopic(
        PreferenceUpdateOrCreateTopicParams parameters
    )
    {
        HttpRequest<PreferenceUpdateOrCreateTopicParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<PreferenceUpdateOrCreateTopicResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
