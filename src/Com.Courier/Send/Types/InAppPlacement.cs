using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Com.Courier;
using Com.Courier.Core;

#nullable enable

namespace Com.Courier;

[JsonConverter(typeof(StringEnumSerializer<InAppPlacement>))]
public enum InAppPlacement
{
    [EnumMember(Value = "top")]
    Top,

    [EnumMember(Value = "bottom")]
    Bottom,

    [EnumMember(Value = "left")]
    Left,

    [EnumMember(Value = "right")]
    Right
}
