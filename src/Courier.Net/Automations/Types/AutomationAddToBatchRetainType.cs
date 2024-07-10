using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Net;
using Courier.Net.Core;

#nullable enable

namespace Courier.Net;

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
