using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Net;
using Courier.Net.Core;

#nullable enable

namespace Courier.Net;

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
