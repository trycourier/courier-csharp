using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record Tag
{
    [JsonPropertyName("data")]
    public IEnumerable<TagData> Data { get; set; } = new List<TagData>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
