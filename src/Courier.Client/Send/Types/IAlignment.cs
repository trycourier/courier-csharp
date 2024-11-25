using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

[JsonConverter(typeof(EnumSerializer<IAlignment>))]
public enum IAlignment
{
    [EnumMember(Value = "center")]
    Center,

    [EnumMember(Value = "left")]
    Left,

    [EnumMember(Value = "right")]
    Right,

    [EnumMember(Value = "full")]
    Full,
}
