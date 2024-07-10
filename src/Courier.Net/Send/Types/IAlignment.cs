using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Net;
using Courier.Net.Core;

#nullable enable

namespace Courier.Net;

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
