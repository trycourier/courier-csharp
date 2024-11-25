using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

[JsonConverter(typeof(EnumSerializer<TextStyle>))]
public enum TextStyle
{
    [EnumMember(Value = "text")]
    Text,

    [EnumMember(Value = "h1")]
    H1,

    [EnumMember(Value = "h2")]
    H2,

    [EnumMember(Value = "subtext")]
    Subtext,
}
