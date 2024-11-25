using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

[JsonConverter(typeof(EnumSerializer<TextAlign>))]
public enum TextAlign
{
    [EnumMember(Value = "left")]
    Left,

    [EnumMember(Value = "center")]
    Center,

    [EnumMember(Value = "right")]
    Right,
}
