using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Client;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

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
