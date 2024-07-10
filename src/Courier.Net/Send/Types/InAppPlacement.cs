using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Net;
using Courier.Net.Core;

#nullable enable

namespace Courier.Net;

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
