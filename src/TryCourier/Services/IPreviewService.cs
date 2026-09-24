using System;
using System.Threading;
using System.Threading.Tasks;
using TryCourier.Core;
using TryCourier.Models.Previews;

namespace TryCourier.Services;

/// <summary>
/// Render a template's email content on real email clients and read back the screenshots,
/// so you can check how it looks before you send it.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IPreviewService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPreviewServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPreviewService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Archive a device set. This is a soft delete — the archived set is returned and
    /// no longer appears in list results. Runs already created against it keep their
    /// own copy of the device list and are unaffected. The Courier-provided default set
    /// cannot be archived and returns 409.
    /// </summary>
    Task<DeviceSet> ArchiveDeviceSet(
        PreviewArchiveDeviceSetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ArchiveDeviceSet(PreviewArchiveDeviceSetParams, CancellationToken)"/>
    Task<DeviceSet> ArchiveDeviceSet(
        string deviceSetID,
        PreviewArchiveDeviceSetParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a named, reusable set of preview devices. Every id must be one listed by
    /// `GET /previews/devices`; any other is a 422.
    /// </summary>
    Task<DeviceSet> CreateDeviceSet(
        PreviewCreateDeviceSetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List the workspace's preview sets. Archived sets are not returned.
    /// </summary>
    Task<DeviceSetListResponse> ListDeviceSets(
        PreviewListDeviceSetsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List the devices a preview can be rendered on. Reference data, identical for
    /// every workspace — these ids are what a device set is built from and what a run
    /// reports results for.
    /// </summary>
    Task<PreviewDeviceListResponse> ListDevices(
        PreviewListDevicesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a preview set by ID. Archived sets return 404.
    /// </summary>
    Task<DeviceSet> RetrieveDeviceSet(
        PreviewRetrieveDeviceSetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveDeviceSet(PreviewRetrieveDeviceSetParams, CancellationToken)"/>
    Task<DeviceSet> RetrieveDeviceSet(
        string deviceSetID,
        PreviewRetrieveDeviceSetParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Replace a device set. This is a full replace, not a patch — both the name and
    /// the device list are always written. The Courier-provided default set cannot be
    /// changed and returns 409.
    /// </summary>
    Task<DeviceSet> UpdateDeviceSet(
        PreviewUpdateDeviceSetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateDeviceSet(PreviewUpdateDeviceSetParams, CancellationToken)"/>
    Task<DeviceSet> UpdateDeviceSet(
        string deviceSetID,
        PreviewUpdateDeviceSetParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPreviewService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPreviewServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPreviewServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /previews/device-sets/{deviceSetId}</c>, but is otherwise the
    /// same as <see cref="IPreviewService.ArchiveDeviceSet(PreviewArchiveDeviceSetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DeviceSet>> ArchiveDeviceSet(
        PreviewArchiveDeviceSetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ArchiveDeviceSet(PreviewArchiveDeviceSetParams, CancellationToken)"/>
    Task<HttpResponse<DeviceSet>> ArchiveDeviceSet(
        string deviceSetID,
        PreviewArchiveDeviceSetParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /previews/device-sets</c>, but is otherwise the
    /// same as <see cref="IPreviewService.CreateDeviceSet(PreviewCreateDeviceSetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DeviceSet>> CreateDeviceSet(
        PreviewCreateDeviceSetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /previews/device-sets</c>, but is otherwise the
    /// same as <see cref="IPreviewService.ListDeviceSets(PreviewListDeviceSetsParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DeviceSetListResponse>> ListDeviceSets(
        PreviewListDeviceSetsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /previews/devices</c>, but is otherwise the
    /// same as <see cref="IPreviewService.ListDevices(PreviewListDevicesParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PreviewDeviceListResponse>> ListDevices(
        PreviewListDevicesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /previews/device-sets/{deviceSetId}</c>, but is otherwise the
    /// same as <see cref="IPreviewService.RetrieveDeviceSet(PreviewRetrieveDeviceSetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DeviceSet>> RetrieveDeviceSet(
        PreviewRetrieveDeviceSetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveDeviceSet(PreviewRetrieveDeviceSetParams, CancellationToken)"/>
    Task<HttpResponse<DeviceSet>> RetrieveDeviceSet(
        string deviceSetID,
        PreviewRetrieveDeviceSetParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /previews/device-sets/{deviceSetId}</c>, but is otherwise the
    /// same as <see cref="IPreviewService.UpdateDeviceSet(PreviewUpdateDeviceSetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DeviceSet>> UpdateDeviceSet(
        PreviewUpdateDeviceSetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateDeviceSet(PreviewUpdateDeviceSetParams, CancellationToken)"/>
    Task<HttpResponse<DeviceSet>> UpdateDeviceSet(
        string deviceSetID,
        PreviewUpdateDeviceSetParams parameters,
        CancellationToken cancellationToken = default
    );
}
