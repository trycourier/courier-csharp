using System.Runtime.Serialization;

namespace Courier.Net;

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
