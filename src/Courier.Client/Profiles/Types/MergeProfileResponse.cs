using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record MergeProfileResponse
{
    [JsonPropertyName("status")]
    public required string Status { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
