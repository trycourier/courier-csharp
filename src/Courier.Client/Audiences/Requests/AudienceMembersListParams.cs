using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[Serializable]
public record AudienceMembersListParams
{
    /// <summary>
    /// A unique identifier that allows for fetching the next set of members
    /// </summary>
    [JsonIgnore]
    public string? Cursor { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
