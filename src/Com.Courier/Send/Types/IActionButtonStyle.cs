using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Com.Courier;
using Com.Courier.Core;

#nullable enable

namespace Com.Courier;

[JsonConverter(typeof(StringEnumSerializer<IActionButtonStyle>))]
public enum IActionButtonStyle
{
    [EnumMember(Value = "button")]
    Button,

    [EnumMember(Value = "link")]
    Link
}
