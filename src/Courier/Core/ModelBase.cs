using System.Collections.Generic;
using System.Text.Json;
using Courier.Models.Audiences;
using Courier.Models.Brands;
using Courier.Models.Inbound;
using Courier.Models.Send;
using Courier.Models.Tenants.Preferences.Items;
using Bulk = Courier.Models.Bulk;
using Invoke = Courier.Models.Automations.Invoke;
using Lists = Courier.Models.Profiles.Lists;
using Messages = Courier.Models.Messages;
using Models = Courier.Models;
using Notifications = Courier.Models.Notifications;
using Profiles = Courier.Models.Profiles;
using Templates = Courier.Models.Tenants.Templates;
using Tenants = Courier.Models.Tenants;
using Tokens = Courier.Models.Users.Tokens;

namespace Courier.Core;

public abstract record class ModelBase
{
    private protected FreezableDictionary<string, JsonElement> _properties = [];

    public IReadOnlyDictionary<string, JsonElement> Properties
    {
        get { return this._properties.Freeze(); }
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new ApiEnumConverter<string, Models::Alignment>(),
            new ApiEnumConverter<string, Models::ChannelClassification>(),
            new ApiEnumConverter<string, Models::Type>(),
            new ApiEnumConverter<
                string,
                Models::ElementalChannelNodeWithTypeIntersectionMember1Type
            >(),
            new ApiEnumConverter<
                string,
                Models::ElementalDividerNodeWithTypeIntersectionMember1Type
            >(),
            new ApiEnumConverter<
                string,
                Models::ElementalImageNodeWithTypeIntersectionMember1Type
            >(),
            new ApiEnumConverter<
                string,
                Models::ElementalMetaNodeWithTypeIntersectionMember1Type
            >(),
            new ApiEnumConverter<
                string,
                Models::ElementalQuoteNodeWithTypeIntersectionMember1Type
            >(),
            new ApiEnumConverter<
                string,
                Models::ElementalTextNodeWithTypeIntersectionMember1Type
            >(),
            new ApiEnumConverter<string, Models::Method>(),
            new ApiEnumConverter<string, Models::Source>(),
            new ApiEnumConverter<string, Models::PreferenceStatus>(),
            new ApiEnumConverter<string, Models::TextStyle>(),
            new ApiEnumConverter<string, RoutingMethod>(),
            new ApiEnumConverter<string, Method>(),
            new ApiEnumConverter<string, Criteria>(),
            new ApiEnumConverter<string, Operator>(),
            new ApiEnumConverter<string, FilterConfigOperator>(),
            new ApiEnumConverter<string, Invoke::Action>(),
            new ApiEnumConverter<string, Invoke::AutomationSendStepAction>(),
            new ApiEnumConverter<string, Invoke::AutomationSendListStepAction>(),
            new ApiEnumConverter<string, Invoke::AutomationUpdateProfileStepAction>(),
            new ApiEnumConverter<string, Invoke::Merge>(),
            new ApiEnumConverter<string, Invoke::AutomationCancelStepAction>(),
            new ApiEnumConverter<string, Invoke::AutomationFetchDataStepAction>(),
            new ApiEnumConverter<string, Invoke::Method>(),
            new ApiEnumConverter<string, Invoke::MergeStrategy>(),
            new ApiEnumConverter<string, Invoke::AutomationInvokeStepAction>(),
            new ApiEnumConverter<string, Placement>(),
            new ApiEnumConverter<string, Bulk::Status>(),
            new ApiEnumConverter<string, Bulk::JobStatus>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, Messages::Status>(),
            new ApiEnumConverter<string, Messages::Reason>(),
            new ApiEnumConverter<string, Notifications::Status>(),
            new ApiEnumConverter<string, Notifications::Type>(),
            new ApiEnumConverter<string, Notifications::BlockType>(),
            new ApiEnumConverter<string, Profiles::Status>(),
            new ApiEnumConverter<string, Profiles::ProfileReplaceResponseStatus>(),
            new ApiEnumConverter<string, Lists::Status>(),
            new ApiEnumConverter<string, Lists::ListSubscribeResponseStatus>(),
            new ApiEnumConverter<string, Tenants::Status>(),
            new ApiEnumConverter<string, Tenants::Type>(),
            new ApiEnumConverter<string, Tenants::TenantListResponseType>(),
            new ApiEnumConverter<string, Tenants::TenantListUsersResponseType>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, Templates::Type>(),
            new ApiEnumConverter<string, global::Courier.Models.Users.Tenants.Type>(),
            new ApiEnumConverter<string, Tokens::UserTokenProviderKey>(),
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
    static abstract T FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties);
}
