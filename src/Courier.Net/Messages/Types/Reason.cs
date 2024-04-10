using System.Runtime.Serialization;

namespace Courier.Net;

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
