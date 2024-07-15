using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Com.Courier;
using Com.Courier.Core;

#nullable enable

namespace Com.Courier;

[JsonConverter(typeof(StringEnumSerializer<AutomationFetchDataWebhookMethod>))]
public enum AutomationFetchDataWebhookMethod
{
    [EnumMember(Value = "GET")]
    Get,

    [EnumMember(Value = "POST")]
    Post
}
