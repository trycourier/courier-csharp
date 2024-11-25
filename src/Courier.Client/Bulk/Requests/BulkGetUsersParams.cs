using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record BulkGetUsersParams
{
    /// <summary>
    /// A unique identifier that allows for fetching the next set of users added to the bulk job
    /// </summary>
    public string? Cursor { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
