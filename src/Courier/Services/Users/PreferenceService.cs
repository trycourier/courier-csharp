using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Users.Preferences;

namespace Courier.Services.Users;

/// <inheritdoc/>
public sealed class PreferenceService : IPreferenceService
{
    readonly Lazy<IPreferenceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPreferenceServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public IPreferenceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PreferenceService(this._client.WithOptions(modifier));
    }

    public PreferenceService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() => new PreferenceServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<PreferenceRetrieveResponse> Retrieve(
        PreferenceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PreferenceRetrieveResponse> Retrieve(
        string userID,
        PreferenceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PreferenceRetrieveTopicResponse> RetrieveTopic(
        PreferenceRetrieveTopicParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveTopic(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PreferenceRetrieveTopicResponse> RetrieveTopic(
        string topicID,
        PreferenceRetrieveTopicParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveTopic(parameters with { TopicID = topicID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PreferenceUpdateOrCreateTopicResponse> UpdateOrCreateTopic(
        PreferenceUpdateOrCreateTopicParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UpdateOrCreateTopic(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PreferenceUpdateOrCreateTopicResponse> UpdateOrCreateTopic(
        string topicID,
        PreferenceUpdateOrCreateTopicParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateOrCreateTopic(parameters with { TopicID = topicID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class PreferenceServiceWithRawResponse : IPreferenceServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPreferenceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PreferenceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PreferenceServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PreferenceRetrieveResponse>> Retrieve(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var preference = await response
                    .Deserialize<PreferenceRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    preference.Validate();
                }
                return preference;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PreferenceRetrieveResponse>> Retrieve(
        string userID,
        PreferenceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PreferenceRetrieveTopicResponse>> RetrieveTopic(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<PreferenceRetrieveTopicResponse>(token)
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
    public Task<HttpResponse<PreferenceRetrieveTopicResponse>> RetrieveTopic(
        string topicID,
        PreferenceRetrieveTopicParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveTopic(parameters with { TopicID = topicID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PreferenceUpdateOrCreateTopicResponse>> UpdateOrCreateTopic(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<PreferenceUpdateOrCreateTopicResponse>(token)
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
    public Task<HttpResponse<PreferenceUpdateOrCreateTopicResponse>> UpdateOrCreateTopic(
        string topicID,
        PreferenceUpdateOrCreateTopicParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateOrCreateTopic(parameters with { TopicID = topicID }, cancellationToken);
    }
}
