namespace Courier.Net;

public record ListTenantParams
{
    /// <summary>
    /// Filter the list of tenants by parent_id
    /// </summary>
    public string? ParentTenantId { get; init; }

    /// <summary>
    /// The number of tenants to return
    /// (defaults to 20, maximum value of 100)
    /// </summary>
    public int? Limit { get; init; }

    /// <summary>
    /// Continue the pagination with the next cursor
    /// </summary>
    public string? Cursor { get; init; }
}
