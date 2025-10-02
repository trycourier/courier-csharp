using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[Serializable]
public record GetMessageHistoryRequest
{
    /// <summary>
    /// A supported Message History type that will filter the events returned.
    /// </summary>
    [JsonIgnore]
    public string? Type { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
