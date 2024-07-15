using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Com.Courier;
using Com.Courier.Core;

#nullable enable

namespace Com.Courier;

[JsonConverter(typeof(StringEnumSerializer<AutomationAddToBatchRetainType>))]
public enum AutomationAddToBatchRetainType
{
    [EnumMember(Value = "first")]
    First,

    [EnumMember(Value = "last")]
    Last,

    [EnumMember(Value = "highest")]
    Highest,

    [EnumMember(Value = "lowest")]
    Lowest
}
