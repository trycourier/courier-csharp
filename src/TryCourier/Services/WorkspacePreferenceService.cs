using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.WorkspacePreferences;
using TryCourier.Services.WorkspacePreferences;

namespace TryCourier.Services;

/// <inheritdoc/>
public sealed class WorkspacePreferenceService : IWorkspacePreferenceService
{
    readonly Lazy<IWorkspacePreferenceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWorkspacePreferenceServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public IWorkspacePreferenceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WorkspacePreferenceService(this._client.WithOptions(modifier));
    }

    public WorkspacePreferenceService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new WorkspacePreferenceServiceWithRawResponse(client.WithRawResponse)
        );
        _topics = new(() => new TopicService(client));
    }

    readonly Lazy<ITopicService> _topics;
    public ITopicService Topics
    {
        get { return _topics.Value; }
    }

    /// <inheritdoc/>
    public async Task<WorkspacePreferenceGetResponse> Create(
        WorkspacePreferenceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<WorkspacePreferenceGetResponse> Retrieve(
        WorkspacePreferenceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WorkspacePreferenceGetResponse> Retrieve(
        string sectionID,
        WorkspacePreferenceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { SectionID = sectionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<WorkspacePreferenceListResponse> List(
        WorkspacePreferenceListParams? parameters = null,
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
        WorkspacePreferenceArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Archive(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Archive(
        string sectionID,
        WorkspacePreferenceArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Archive(parameters with { SectionID = sectionID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PublishPreferencesResponse> Publish(
        WorkspacePreferencePublishParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Publish(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<WorkspacePreferenceGetResponse> Replace(
        WorkspacePreferenceReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Replace(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WorkspacePreferenceGetResponse> Replace(
        string sectionID,
        WorkspacePreferenceReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Replace(parameters with { SectionID = sectionID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class WorkspacePreferenceServiceWithRawResponse
    : IWorkspacePreferenceServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWorkspacePreferenceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new WorkspacePreferenceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WorkspacePreferenceServiceWithRawResponse(ICourierClientWithRawResponse client)
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
    public async Task<HttpResponse<WorkspacePreferenceGetResponse>> Create(
        WorkspacePreferenceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<WorkspacePreferenceCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var workspacePreferenceGetResponse = await response
                    .Deserialize<WorkspacePreferenceGetResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    workspacePreferenceGetResponse.Validate();
                }
                return workspacePreferenceGetResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WorkspacePreferenceGetResponse>> Retrieve(
        WorkspacePreferenceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SectionID == null)
        {
            throw new CourierInvalidDataException("'parameters.SectionID' cannot be null");
        }

        HttpRequest<WorkspacePreferenceRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var workspacePreferenceGetResponse = await response
                    .Deserialize<WorkspacePreferenceGetResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    workspacePreferenceGetResponse.Validate();
                }
                return workspacePreferenceGetResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<WorkspacePreferenceGetResponse>> Retrieve(
        string sectionID,
        WorkspacePreferenceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { SectionID = sectionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WorkspacePreferenceListResponse>> List(
        WorkspacePreferenceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<WorkspacePreferenceListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var workspacePreferenceListResponse = await response
                    .Deserialize<WorkspacePreferenceListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    workspacePreferenceListResponse.Validate();
                }
                return workspacePreferenceListResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Archive(
        WorkspacePreferenceArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SectionID == null)
        {
            throw new CourierInvalidDataException("'parameters.SectionID' cannot be null");
        }

        HttpRequest<WorkspacePreferenceArchiveParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Archive(
        string sectionID,
        WorkspacePreferenceArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { SectionID = sectionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PublishPreferencesResponse>> Publish(
        WorkspacePreferencePublishParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<WorkspacePreferencePublishParams> request = new()
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
    public async Task<HttpResponse<WorkspacePreferenceGetResponse>> Replace(
        WorkspacePreferenceReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SectionID == null)
        {
            throw new CourierInvalidDataException("'parameters.SectionID' cannot be null");
        }

        HttpRequest<WorkspacePreferenceReplaceParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var workspacePreferenceGetResponse = await response
                    .Deserialize<WorkspacePreferenceGetResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    workspacePreferenceGetResponse.Validate();
                }
                return workspacePreferenceGetResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<WorkspacePreferenceGetResponse>> Replace(
        string sectionID,
        WorkspacePreferenceReplaceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Replace(parameters with { SectionID = sectionID }, cancellationToken);
    }
}
