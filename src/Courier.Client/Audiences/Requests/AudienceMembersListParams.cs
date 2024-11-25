using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record AudienceMembersListParams
{
    /// <summary>
    /// A unique identifier that allows for fetching the next set of members
    /// </summary>
    public string? Cursor { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
