using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

[JsonConverter(typeof(EnumSerializer<IActionButtonStyle>))]
public enum IActionButtonStyle
{
    [EnumMember(Value = "button")]
    Button,

    [EnumMember(Value = "link")]
    Link,
}
