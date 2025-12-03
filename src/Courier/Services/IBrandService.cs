using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Brands;

namespace Courier.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IBrandService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBrandService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a new brand
    /// </summary>
    Task<Brand> Create(BrandCreateParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetch a specific brand by brand ID.
    /// </summary>
    Task<Brand> Retrieve(
        BrandRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(BrandRetrieveParams, CancellationToken)"/>
    Task<Brand> Retrieve(
        string brandID,
        BrandRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Replace an existing brand with the supplied values.
    /// </summary>
    Task<Brand> Update(BrandUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Update(BrandUpdateParams, CancellationToken)"/>
    Task<Brand> Update(
        string brandID,
        BrandUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get the list of brands.
    /// </summary>
    Task<BrandListResponse> List(
        BrandListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a brand by brand ID.
    /// </summary>
    Task Delete(BrandDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(BrandDeleteParams, CancellationToken)"/>
    Task Delete(
        string brandID,
        BrandDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
