using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client.Users;

public record UserPreferencesGetResponse
{
    [JsonPropertyName("topic")]
    public required TopicPreference Topic { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
