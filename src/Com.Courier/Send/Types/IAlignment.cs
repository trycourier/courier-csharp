using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Com.Courier;
using Com.Courier.Core;

#nullable enable

namespace Com.Courier;

[JsonConverter(typeof(StringEnumSerializer<IAlignment>))]
public enum IAlignment
{
    [EnumMember(Value = "center")]
    Center,

    [EnumMember(Value = "left")]
    Left,

    [EnumMember(Value = "right")]
    Right,

    [EnumMember(Value = "full")]
    Full
}
