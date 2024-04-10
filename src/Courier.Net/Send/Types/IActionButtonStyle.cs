using System.Runtime.Serialization;

namespace Courier.Net;

public enum IActionButtonStyle
{
    [EnumMember(Value = "button")]
    Button,

    [EnumMember(Value = "link")]
    Link
}
