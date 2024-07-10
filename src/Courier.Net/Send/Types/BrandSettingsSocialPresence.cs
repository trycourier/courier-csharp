using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record BrandSettingsSocialPresence
{
    [JsonPropertyName("inheritDefault")]
    public bool? InheritDefault { get; init; }

    [JsonPropertyName("facebook")]
    public BaseSocialPresence? Facebook { get; init; }

    [JsonPropertyName("instagram")]
    public BaseSocialPresence? Instagram { get; init; }

    [JsonPropertyName("linkedin")]
    public BaseSocialPresence? Linkedin { get; init; }

    [JsonPropertyName("medium")]
    public BaseSocialPresence? Medium { get; init; }

    [JsonPropertyName("twitter")]
    public BaseSocialPresence? Twitter { get; init; }
}
