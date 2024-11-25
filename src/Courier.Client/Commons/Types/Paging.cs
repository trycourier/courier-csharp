using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record Paging
{
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    [JsonPropertyName("more")]
    public required bool More { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
