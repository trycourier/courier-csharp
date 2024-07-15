using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Client;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

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
