using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.PreferenceSections;
using TryCourier.Services.PreferenceSections;

namespace TryCourier.Services;

/// <inheritdoc/>
public sealed class PreferenceSectionService : IPreferenceSectionService
{
    readonly Lazy<IPreferenceSectionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPreferenceSectionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public IPreferenceSectionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PreferenceSectionService(this._client.WithOptions(modifier));
    }

    public PreferenceSectionService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new PreferenceSectionServiceWithRawResponse(client.WithRawResponse)
        );
        _topics = new(() => new TopicService(client));
    }

    readonly Lazy<ITopicService> _topics;
    public ITopicService Topics
    {
        get { return _topics.Value; }
    }

    /// <inheritdoc/>
    public async Task<PreferenceSectionGetResponse> Create(
        PreferenceSectionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PreferenceSectionGetResponse> Retrieve(
        PreferenceSectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PreferenceSectionGetResponse> Retrieve(
        string sectionID,
        PreferenceSectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { SectionID = sectionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PreferenceSectionListResponse> List(
        PreferenceSectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Archive(
        PreferenceSectionArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Archive(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Archive(
        string sectionID,
        PreferenceSectionArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Archive(parameters with { SectionID = sectionID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PublishPreferencesResponse> Publish(
        PreferenceSectionPublishParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Publish(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PreferenceSectionGetResponse> Replace(
        PreferenceSectionReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Replace(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PreferenceSectionGetResponse> Replace(
        string sectionID,
        PreferenceSectionReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Replace(parameters with { SectionID = sectionID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class PreferenceSectionServiceWithRawResponse
    : IPreferenceSectionServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPreferenceSectionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PreferenceSectionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PreferenceSectionServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;

        _topics = new(() => new TopicServiceWithRawResponse(client));
    }

    readonly Lazy<ITopicServiceWithRawResponse> _topics;
    public ITopicServiceWithRawResponse Topics
    {
        get { return _topics.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PreferenceSectionGetResponse>> Create(
        PreferenceSectionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PreferenceSectionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var preferenceSectionGetResponse = await response
                    .Deserialize<PreferenceSectionGetResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    preferenceSectionGetResponse.Validate();
                }
                return preferenceSectionGetResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PreferenceSectionGetResponse>> Retrieve(
        PreferenceSectionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SectionID == null)
        {
            throw new CourierInvalidDataException("'parameters.SectionID' cannot be null");
        }

        HttpRequest<PreferenceSectionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var preferenceSectionGetResponse = await response
                    .Deserialize<PreferenceSectionGetResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    preferenceSectionGetResponse.Validate();
                }
                return preferenceSectionGetResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PreferenceSectionGetResponse>> Retrieve(
        string sectionID,
        PreferenceSectionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { SectionID = sectionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PreferenceSectionListResponse>> List(
        PreferenceSectionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PreferenceSectionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var preferenceSectionListResponse = await response
                    .Deserialize<PreferenceSectionListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    preferenceSectionListResponse.Validate();
                }
                return preferenceSectionListResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Archive(
        PreferenceSectionArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SectionID == null)
        {
            throw new CourierInvalidDataException("'parameters.SectionID' cannot be null");
        }

        HttpRequest<PreferenceSectionArchiveParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Archive(
        string sectionID,
        PreferenceSectionArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { SectionID = sectionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PublishPreferencesResponse>> Publish(
        PreferenceSectionPublishParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PreferenceSectionPublishParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var publishPreferencesResponse = await response
                    .Deserialize<PublishPreferencesResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    publishPreferencesResponse.Validate();
                }
                return publishPreferencesResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PreferenceSectionGetResponse>> Replace(
        PreferenceSectionReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SectionID == null)
        {
            throw new CourierInvalidDataException("'parameters.SectionID' cannot be null");
        }

        HttpRequest<PreferenceSectionReplaceParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var preferenceSectionGetResponse = await response
                    .Deserialize<PreferenceSectionGetResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    preferenceSectionGetResponse.Validate();
                }
                return preferenceSectionGetResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PreferenceSectionGetResponse>> Replace(
        string sectionID,
        PreferenceSectionReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Replace(parameters with { SectionID = sectionID }, cancellationToken);
    }
}
