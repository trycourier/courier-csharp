using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Previews;

namespace TryCourier.Services;

/// <inheritdoc/>
public sealed class PreviewService : IPreviewService
{
    readonly Lazy<IPreviewServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPreviewServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ICourierClient _client;

    /// <inheritdoc/>
    public IPreviewService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PreviewService(this._client.WithOptions(modifier));
    }

    public PreviewService(ICourierClient client)
    {
        _client = client;

        _withRawResponse = new(() => new PreviewServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<DeviceSet> ArchiveDeviceSet(
        PreviewArchiveDeviceSetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ArchiveDeviceSet(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<DeviceSet> ArchiveDeviceSet(
        string deviceSetID,
        PreviewArchiveDeviceSetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ArchiveDeviceSet(
            parameters with
            {
                DeviceSetID = deviceSetID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<DeviceSet> CreateDeviceSet(
        PreviewCreateDeviceSetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateDeviceSet(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<DeviceSetListResponse> ListDeviceSets(
        PreviewListDeviceSetsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListDeviceSets(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PreviewDeviceListResponse> ListDevices(
        PreviewListDevicesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListDevices(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<DeviceSet> RetrieveDeviceSet(
        PreviewRetrieveDeviceSetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveDeviceSet(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<DeviceSet> RetrieveDeviceSet(
        string deviceSetID,
        PreviewRetrieveDeviceSetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveDeviceSet(
            parameters with
            {
                DeviceSetID = deviceSetID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<DeviceSet> UpdateDeviceSet(
        PreviewUpdateDeviceSetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UpdateDeviceSet(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<DeviceSet> UpdateDeviceSet(
        string deviceSetID,
        PreviewUpdateDeviceSetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateDeviceSet(
            parameters with
            {
                DeviceSetID = deviceSetID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class PreviewServiceWithRawResponse : IPreviewServiceWithRawResponse
{
    readonly ICourierClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPreviewServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PreviewServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PreviewServiceWithRawResponse(ICourierClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DeviceSet>> ArchiveDeviceSet(
        PreviewArchiveDeviceSetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DeviceSetID == null)
        {
            throw new CourierInvalidDataException("'parameters.DeviceSetID' cannot be null");
        }

        HttpRequest<PreviewArchiveDeviceSetParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deviceSet = await response.Deserialize<DeviceSet>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deviceSet.Validate();
                }
                return deviceSet;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<DeviceSet>> ArchiveDeviceSet(
        string deviceSetID,
        PreviewArchiveDeviceSetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ArchiveDeviceSet(
            parameters with
            {
                DeviceSetID = deviceSetID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DeviceSet>> CreateDeviceSet(
        PreviewCreateDeviceSetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PreviewCreateDeviceSetParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deviceSet = await response.Deserialize<DeviceSet>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deviceSet.Validate();
                }
                return deviceSet;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DeviceSetListResponse>> ListDeviceSets(
        PreviewListDeviceSetsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PreviewListDeviceSetsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deviceSetListResponse = await response
                    .Deserialize<DeviceSetListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deviceSetListResponse.Validate();
                }
                return deviceSetListResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PreviewDeviceListResponse>> ListDevices(
        PreviewListDevicesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PreviewListDevicesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var previewDeviceListResponse = await response
                    .Deserialize<PreviewDeviceListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    previewDeviceListResponse.Validate();
                }
                return previewDeviceListResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DeviceSet>> RetrieveDeviceSet(
        PreviewRetrieveDeviceSetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DeviceSetID == null)
        {
            throw new CourierInvalidDataException("'parameters.DeviceSetID' cannot be null");
        }

        HttpRequest<PreviewRetrieveDeviceSetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deviceSet = await response.Deserialize<DeviceSet>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deviceSet.Validate();
                }
                return deviceSet;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<DeviceSet>> RetrieveDeviceSet(
        string deviceSetID,
        PreviewRetrieveDeviceSetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveDeviceSet(
            parameters with
            {
                DeviceSetID = deviceSetID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DeviceSet>> UpdateDeviceSet(
        PreviewUpdateDeviceSetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DeviceSetID == null)
        {
            throw new CourierInvalidDataException("'parameters.DeviceSetID' cannot be null");
        }

        HttpRequest<PreviewUpdateDeviceSetParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deviceSet = await response.Deserialize<DeviceSet>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deviceSet.Validate();
                }
                return deviceSet;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<DeviceSet>> UpdateDeviceSet(
        string deviceSetID,
        PreviewUpdateDeviceSetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateDeviceSet(
            parameters with
            {
                DeviceSetID = deviceSetID,
            },
            cancellationToken
        );
    }
}
