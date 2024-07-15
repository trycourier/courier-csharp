using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Client;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

[JsonConverter(typeof(StringEnumSerializer<TextAlign>))]
public enum TextAlign
{
    [EnumMember(Value = "left")]
    Left,

    [EnumMember(Value = "center")]
    Center,

    [EnumMember(Value = "right")]
    Right
}
