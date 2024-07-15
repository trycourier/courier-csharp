using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Client;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

[JsonConverter(typeof(StringEnumSerializer<BlockType>))]
public enum BlockType
{
    [EnumMember(Value = "action")]
    Action,

    [EnumMember(Value = "divider")]
    Divider,

    [EnumMember(Value = "image")]
    Image,

    [EnumMember(Value = "jsonnet")]
    Jsonnet,

    [EnumMember(Value = "list")]
    List,

    [EnumMember(Value = "markdown")]
    Markdown,

    [EnumMember(Value = "quote")]
    Quote,

    [EnumMember(Value = "template")]
    Template,

    [EnumMember(Value = "text")]
    Text
}
