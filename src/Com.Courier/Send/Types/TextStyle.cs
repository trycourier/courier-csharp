using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Com.Courier;
using Com.Courier.Core;

#nullable enable

namespace Com.Courier;

[JsonConverter(typeof(StringEnumSerializer<TextStyle>))]
public enum TextStyle
{
    [EnumMember(Value = "text")]
    Text,

    [EnumMember(Value = "h1")]
    H1,

    [EnumMember(Value = "h2")]
    H2,

    [EnumMember(Value = "subtext")]
    Subtext
}
