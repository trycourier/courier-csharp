using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record ListUsersForTenantParams
{
    /// <summary>
    /// The number of accounts to return
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
