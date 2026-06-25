using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.WorkspacePreferences;
using TryCourier.Models.WorkspacePreferences.Topics;

namespace TryCourier.Services.WorkspacePreferences;

/// <inheritdoc/>
public sealed class TopicService : ITopicService
{
    readonly Lazy<ITopicServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITopicServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public ITopicService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TopicService(this._client.WithOptions(modifier));
    }

    public TopicService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() => new TopicServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<WorkspacePreferenceTopicGetResponse> Create(
        TopicCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WorkspacePreferenceTopicGetResponse> Create(
        string sectionID,
        TopicCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { SectionID = sectionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<WorkspacePreferenceTopicGetResponse> Retrieve(
        TopicRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WorkspacePreferenceTopicGetResponse> Retrieve(
        string topicID,
        TopicRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { TopicID = topicID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<WorkspacePreferenceTopicListResponse> List(
        TopicListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WorkspacePreferenceTopicListResponse> List(
        string sectionID,
        TopicListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { SectionID = sectionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Archive(
        TopicArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Archive(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Archive(
        string topicID,
        TopicArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Archive(parameters with { TopicID = topicID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<WorkspacePreferenceTopicGetResponse> Replace(
        TopicReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Replace(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WorkspacePreferenceTopicGetResponse> Replace(
        string topicID,
        TopicReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Replace(parameters with { TopicID = topicID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class TopicServiceWithRawResponse : ITopicServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITopicServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TopicServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TopicServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WorkspacePreferenceTopicGetResponse>> Create(
        TopicCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SectionID == null)
        {
            throw new CourierInvalidDataException("'parameters.SectionID' cannot be null");
        }

        HttpRequest<TopicCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var workspacePreferenceTopicGetResponse = await response
                    .Deserialize<WorkspacePreferenceTopicGetResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    workspacePreferenceTopicGetResponse.Validate();
                }
                return workspacePreferenceTopicGetResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<WorkspacePreferenceTopicGetResponse>> Create(
        string sectionID,
        TopicCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { SectionID = sectionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WorkspacePreferenceTopicGetResponse>> Retrieve(
        TopicRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TopicID == null)
        {
            throw new CourierInvalidDataException("'parameters.TopicID' cannot be null");
        }

        HttpRequest<TopicRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var workspacePreferenceTopicGetResponse = await response
                    .Deserialize<WorkspacePreferenceTopicGetResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    workspacePreferenceTopicGetResponse.Validate();
                }
                return workspacePreferenceTopicGetResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<WorkspacePreferenceTopicGetResponse>> Retrieve(
        string topicID,
        TopicRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { TopicID = topicID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WorkspacePreferenceTopicListResponse>> List(
        TopicListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SectionID == null)
        {
            throw new CourierInvalidDataException("'parameters.SectionID' cannot be null");
        }

        HttpRequest<TopicListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var workspacePreferenceTopicListResponse = await response
                    .Deserialize<WorkspacePreferenceTopicListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    workspacePreferenceTopicListResponse.Validate();
                }
                return workspacePreferenceTopicListResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<WorkspacePreferenceTopicListResponse>> List(
        string sectionID,
        TopicListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { SectionID = sectionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Archive(
        TopicArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TopicID == null)
        {
            throw new CourierInvalidDataException("'parameters.TopicID' cannot be null");
        }

        HttpRequest<TopicArchiveParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Archive(
        string topicID,
        TopicArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Archive(parameters with { TopicID = topicID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WorkspacePreferenceTopicGetResponse>> Replace(
        TopicReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TopicID == null)
        {
            throw new CourierInvalidDataException("'parameters.TopicID' cannot be null");
        }

        HttpRequest<TopicReplaceParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var workspacePreferenceTopicGetResponse = await response
                    .Deserialize<WorkspacePreferenceTopicGetResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    workspacePreferenceTopicGetResponse.Validate();
                }
                return workspacePreferenceTopicGetResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<WorkspacePreferenceTopicGetResponse>> Replace(
        string topicID,
        TopicReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Replace(parameters with { TopicID = topicID }, cancellationToken);
    }
}
