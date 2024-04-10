using Courier.Net;
using System.Text.Json.Serialization;

namespace Courier.Net;

public class ElementalNode
{
    public class _Text : ElementalTextNode
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "text";
    }
    public class _Meta : ElementalMetaNode
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "meta";
    }
    public class _Channel : ElementalChannelNode
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "channel";
    }
    public class _Image : ElementalImageNode
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "image";
    }
    public class _Action : ElementalActionNode
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "action";
    }
    public class _Divider : ElementalDividerNode
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "divider";
    }
    public class _Group : ElementalGroupNode
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "group";
    }
    public class _Quote : ElementalQuoteNode
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "quote";
    }
}
