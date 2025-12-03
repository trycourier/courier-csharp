using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Users.Preferences;

namespace Courier.Services.Users;

/// <inheritdoc />
public sealed class PreferenceService : IPreferenceService
{
    /// <inheritdoc/>
    public IPreferenceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PreferenceService(this._client.WithOptions(modifier));
    }

    readonly ICourierClient _client;

    public PreferenceService(ICourierClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<PreferenceRetrieveResponse> Retrieve(
        PreferenceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserID == null)
        {
            throw new CourierInvalidDataException("'parameters.UserID' cannot be null");
        }

        HttpRequest<PreferenceRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var preference = await response
            .Deserialize<PreferenceRetrieveResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            preference.Validate();
        }
        return preference;
    }

    /// <inheritdoc/>
    public async Task<PreferenceRetrieveResponse> Retrieve(
        string userID,
        PreferenceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PreferenceRetrieveTopicResponse> RetrieveTopic(
        PreferenceRetrieveTopicParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TopicID == null)
        {
            throw new CourierInvalidDataException("'parameters.TopicID' cannot be null");
        }

        HttpRequest<PreferenceRetrieveTopicParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<PreferenceRetrieveTopicResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<PreferenceRetrieveTopicResponse> RetrieveTopic(
        string topicID,
        PreferenceRetrieveTopicParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.RetrieveTopic(parameters with { TopicID = topicID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PreferenceUpdateOrCreateTopicResponse> UpdateOrCreateTopic(
        PreferenceUpdateOrCreateTopicParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TopicID == null)
        {
            throw new CourierInvalidDataException("'parameters.TopicID' cannot be null");
        }

        HttpRequest<PreferenceUpdateOrCreateTopicParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<PreferenceUpdateOrCreateTopicResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<PreferenceUpdateOrCreateTopicResponse> UpdateOrCreateTopic(
        string topicID,
        PreferenceUpdateOrCreateTopicParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.UpdateOrCreateTopic(
            parameters with
            {
                TopicID = topicID,
            },
            cancellationToken
        );
    }
}
