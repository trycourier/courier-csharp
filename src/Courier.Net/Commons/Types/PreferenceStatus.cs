using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Net;
using Courier.Net.Core;

#nullable enable

namespace Courier.Net;

[JsonConverter(typeof(StringEnumSerializer<PreferenceStatus>))]
public enum PreferenceStatus
{
    [EnumMember(Value = "OPTED_IN")]
    OptedIn,

    [EnumMember(Value = "OPTED_OUT")]
    OptedOut,

    [EnumMember(Value = "REQUIRED")]
    Required
}
