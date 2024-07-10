namespace Courier.Net;

public record ListBrandsRequest
{
    /// <summary>
    /// A unique identifier that allows for fetching the next set of brands.
    /// </summary>
    public string? Cursor { get; init; }
}
