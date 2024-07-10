using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Net;
using Courier.Net.Core;

#nullable enable

namespace Courier.Net;

[JsonConverter(typeof(StringEnumSerializer<IActionButtonStyle>))]
public enum IActionButtonStyle
{
    [EnumMember(Value = "button")]
    Button,

    [EnumMember(Value = "link")]
    Link
}
