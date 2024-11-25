using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record ListTenantParams
{
    /// <summary>
    /// Filter the list of tenants by parent_id
    /// </summary>
    public string? ParentTenantId { get; set; }

    /// <summary>
    /// The number of tenants to return
    /// (defaults to 20, maximum value of 100)
    /// </summary>
    public int? Limit { get; set; }

    /// <summary>
    /// Continue the pagination with the next cursor
    /// </summary>
    public string? Cursor { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
