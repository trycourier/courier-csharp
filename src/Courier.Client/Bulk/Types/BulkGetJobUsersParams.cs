using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record BulkGetJobUsersParams
{
    [JsonPropertyName("jobId")]
    public required string JobId { get; set; }

    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
