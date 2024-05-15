using System.Runtime.Serialization;

namespace Courier.Net;

public enum Override
{
    [EnumMember(Value = "MessageChannelEmailOverride")]
    MessageChannelEmailOverride,

    [EnumMember(Value = "MessageChannelPushOverride")]
    MessageChannelPushOverride
}
