using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record BrandSettingsSocialPresence
{
    [JsonPropertyName("inheritDefault")]
    public bool? InheritDefault { get; set; }

    [JsonPropertyName("facebook")]
    public BaseSocialPresence? Facebook { get; set; }

    [JsonPropertyName("instagram")]
    public BaseSocialPresence? Instagram { get; set; }

    [JsonPropertyName("linkedin")]
    public BaseSocialPresence? Linkedin { get; set; }

    [JsonPropertyName("medium")]
    public BaseSocialPresence? Medium { get; set; }

    [JsonPropertyName("twitter")]
    public BaseSocialPresence? Twitter { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
