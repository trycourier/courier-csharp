using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class ListPutParams
{
    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("preferences")]
    public RecipientPreferences? Preferences { get; init; }
}
