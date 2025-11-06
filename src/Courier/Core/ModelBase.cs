using System.Collections.Generic;
using System.Text.Json;
using Courier.Models.Audiences;
using Courier.Models.Brands;
using Courier.Models.Inbound;
using Courier.Models.Send;
using Courier.Models.Tenants.TenantDefaultPreferences.Items;
using Bulk = Courier.Models.Bulk;
using Invoke = Courier.Models.Automations.Invoke;
using Lists = Courier.Models.Profiles.Lists;
using Messages = Courier.Models.Messages;
using Models = Courier.Models;
using Notifications = Courier.Models.Notifications;
using Profiles = Courier.Models.Profiles;
using Templates = Courier.Models.Tenants.Templates;
using Tenants = Courier.Models.Users.Tenants;
using Tokens = Courier.Models.Users.Tokens;

namespace Courier.Core;

public abstract record class ModelBase
{
    public Dictionary<string, JsonElement> Properties { get; set; } = [];

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new ApiEnumConverter<string, Models::Alignment>(),
            new ApiEnumConverter<string, Models::ChannelClassification>(),
            new ApiEnumConverter<string, Models::Type>(),
            new ApiEnumConverter<string, Models::TypeModel>(),
            new ApiEnumConverter<string, Models::Type1>(),
            new ApiEnumConverter<string, Models::Type2>(),
            new ApiEnumConverter<string, Models::Type3>(),
            new ApiEnumConverter<string, Models::Type4>(),
            new ApiEnumConverter<string, Models::Type5>(),
            new ApiEnumConverter<string, Models::Method>(),
            new ApiEnumConverter<string, Models::Source>(),
            new ApiEnumConverter<string, Models::PreferenceStatus>(),
            new ApiEnumConverter<string, Models::TextStyle>(),
            new ApiEnumConverter<string, RoutingMethod>(),
            new ApiEnumConverter<string, Method>(),
            new ApiEnumConverter<string, Criteria>(),
            new ApiEnumConverter<string, Operator>(),
            new ApiEnumConverter<string, OperatorModel>(),
            new ApiEnumConverter<string, Invoke::Action>(),
            new ApiEnumConverter<string, Invoke::ActionModel>(),
            new ApiEnumConverter<string, Invoke::Action1>(),
            new ApiEnumConverter<string, Invoke::Action2>(),
            new ApiEnumConverter<string, Invoke::Merge>(),
            new ApiEnumConverter<string, Invoke::Action3>(),
            new ApiEnumConverter<string, Invoke::Action4>(),
            new ApiEnumConverter<string, Invoke::Method>(),
            new ApiEnumConverter<string, Invoke::MergeStrategy>(),
            new ApiEnumConverter<string, Invoke::Action5>(),
            new ApiEnumConverter<string, Placement>(),
            new ApiEnumConverter<string, Bulk::Status>(),
            new ApiEnumConverter<string, Bulk::StatusModel>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, Messages::Status>(),
            new ApiEnumConverter<string, Messages::Reason>(),
            new ApiEnumConverter<string, Notifications::Status>(),
            new ApiEnumConverter<string, Notifications::Type>(),
            new ApiEnumConverter<string, Notifications::TypeModel>(),
            new ApiEnumConverter<string, Profiles::Status>(),
            new ApiEnumConverter<string, Profiles::StatusModel>(),
            new ApiEnumConverter<string, Lists::Status>(),
            new ApiEnumConverter<string, Lists::StatusModel>(),
            new ApiEnumConverter<string, global::Courier.Models.Tenants.Status>(),
            new ApiEnumConverter<string, global::Courier.Models.Tenants.Type>(),
            new ApiEnumConverter<string, global::Courier.Models.Tenants.TypeModel>(),
            new ApiEnumConverter<string, global::Courier.Models.Tenants.Type1>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, Templates::Type>(),
            new ApiEnumConverter<string, Tenants::Type>(),
            new ApiEnumConverter<string, Tokens::ProviderKeyModel>(),
            new ApiEnumConverter<string, Tokens::Status>(),
            new ApiEnumConverter<string, Tokens::ProviderKey>(),
        },
    };

    static readonly JsonSerializerOptions _toStringSerializerOptions = new(SerializerOptions)
    {
        WriteIndented = true,
    };

    public sealed override string? ToString()
    {
        return JsonSerializer.Serialize(this.Properties, _toStringSerializerOptions);
    }

    public abstract void Validate();
}

interface IFromRaw<T>
{
    static abstract T FromRawUnchecked(Dictionary<string, JsonElement> properties);
}
