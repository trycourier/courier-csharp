using System.Threading.Tasks;
using Courier.Models.Brands;

namespace Courier.Services.Brands;

public interface IBrandService
{
    /// <summary>
    /// Create a new brand
    /// </summary>
    Task<Brand> Create(BrandCreateParams parameters);

    /// <summary>
    /// Fetch a specific brand by brand ID.
    /// </summary>
    Task<Brand> Retrieve(BrandRetrieveParams parameters);

    /// <summary>
    /// Replace an existing brand with the supplied values.
    /// </summary>
    Task<Brand> Update(BrandUpdateParams parameters);

    /// <summary>
    /// Get the list of brands.
    /// </summary>
    Task<BrandListResponse> List(BrandListParams? parameters = null);

    /// <summary>
    /// Delete a brand by brand ID.
    /// </summary>
    Task Delete(BrandDeleteParams parameters);
}
