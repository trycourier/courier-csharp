using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Net;
using Courier.Net.Core;

#nullable enable

namespace Courier.Net;

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
