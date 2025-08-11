using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

[JsonConverter(typeof(EnumSerializer<Reason>))]
public enum Reason
{
    [EnumMember(Value = "BOUNCED")]
    Bounced,

    [EnumMember(Value = "FAILED")]
    Failed,

    [EnumMember(Value = "FILTERED")]
    Filtered,

    [EnumMember(Value = "NO_CHANNELS")]
    NoChannels,

    [EnumMember(Value = "NO_PROVIDERS")]
    NoProviders,

    [EnumMember(Value = "OPT_IN_REQUIRED")]
    OptInRequired,

    [EnumMember(Value = "PROVIDER_ERROR")]
    ProviderError,

    [EnumMember(Value = "UNPUBLISHED")]
    Unpublished,

    [EnumMember(Value = "UNSUBSCRIBED")]
    Unsubscribed,
}
