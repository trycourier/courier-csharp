using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Com.Courier;
using Com.Courier.Core;

#nullable enable

namespace Com.Courier;

[JsonConverter(typeof(StringEnumSerializer<Reason>))]
public enum Reason
{
    [EnumMember(Value = "FILTERED")]
    Filtered,

    [EnumMember(Value = "NO_CHANNELS")]
    NoChannels,

    [EnumMember(Value = "NO_PROVIDERS")]
    NoProviders,

    [EnumMember(Value = "PROVIDER_ERROR")]
    ProviderError,

    [EnumMember(Value = "UNPUBLISHED")]
    Unpublished,

    [EnumMember(Value = "UNSUBSCRIBED")]
    Unsubscribed
}
