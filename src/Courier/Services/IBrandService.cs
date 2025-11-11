using System;
using System.Threading;
using System.Threading.Tasks;
using Courier.Core;
using Courier.Models.Brands;

namespace Courier.Services;

public interface IBrandService
{
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

    /// <summary>
    /// Replace an existing brand with the supplied values.
    /// </summary>
    Task<Brand> Update(BrandUpdateParams parameters, CancellationToken cancellationToken = default);

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
}
