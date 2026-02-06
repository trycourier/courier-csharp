using System.Text.Json;
using Courier.Exceptions;
using Courier.Models;
using Courier.Models.Automations;
using Courier.Models.Brands;
using Courier.Models.Bulk;
using Audiences = Courier.Models.Audiences;
using Inbound = Courier.Models.Inbound;
using Invoke = Courier.Models.Automations.Invoke;
using Items = Courier.Models.Tenants.Preferences.Items;
using Lists = Courier.Models.Profiles.Lists;
using Messages = Courier.Models.Messages;
using Notifications = Courier.Models.Notifications;
using Profiles = Courier.Models.Profiles;
using Send = Courier.Models.Send;
using Templates = Courier.Models.Tenants.Templates;
using Tenants = Courier.Models.Tenants;
using Tokens = Courier.Models.Users.Tokens;
using UsersTenants = Courier.Models.Users.Tenants;

namespace Courier.Core;

/// <summary>
/// The base class for all API objects with properties.
///
/// <para>API objects such as enums do not inherit from this class.</para>
/// </summary>
public abstract record class ModelBase
{
    protected ModelBase(ModelBase modelBase)
    {
        // Nothing to copy. Just so that subclasses can define copy constructors.
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new FrozenDictionaryConverterFactory(),
            new ApiEnumConverter<string, Alignment>(),
            new ApiEnumConverter<string, Operator>(),
            new ApiEnumConverter<string, Path>(),
            new ApiEnumConverter<string, ChannelClassification>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, ElementalChannelNodeWithTypeIntersectionMember1Type>(),
            new ApiEnumConverter<string, ElementalDividerNodeWithTypeIntersectionMember1Type>(),
            new ApiEnumConverter<string, ElementalImageNodeWithTypeIntersectionMember1Type>(),
            new ApiEnumConverter<string, ElementalMetaNodeWithTypeIntersectionMember1Type>(),
            new ApiEnumConverter<string, ElementalQuoteNodeWithTypeIntersectionMember1Type>(),
            new ApiEnumConverter<string, ElementalTextNodeWithTypeIntersectionMember1Type>(),
            new ApiEnumConverter<string, ListFilterOperator>(),
            new ApiEnumConverter<string, ListFilterPath>(),
            new ApiEnumConverter<string, Method>(),
            new ApiEnumConverter<string, Source>(),
            new ApiEnumConverter<string, PreferenceStatus>(),
            new ApiEnumConverter<string, TextStyle>(),
            new ApiEnumConverter<string, WebhookAuthMode>(),
            new ApiEnumConverter<string, WebhookMethod>(),
            new ApiEnumConverter<string, WebhookProfileType>(),
            new ApiEnumConverter<string, Send::RoutingMethod>(),
            new ApiEnumConverter<string, Send::Method>(),
            new ApiEnumConverter<string, Send::Criteria>(),
            new ApiEnumConverter<string, Audiences::AudienceOperator>(),
            new ApiEnumConverter<string, Audiences::Operator>(),
            new ApiEnumConverter<string, AutomationTemplateVersion>(),
            new ApiEnumConverter<string, Version>(),
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
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, JobStatus>(),
            new ApiEnumConverter<string, Inbound::Type>(),
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
            new ApiEnumConverter<string, Tenants::RoutingMethod>(),
            new ApiEnumConverter<string, Tenants::TenantListResponseType>(),
            new ApiEnumConverter<string, Tenants::TenantListUsersResponseType>(),
            new ApiEnumConverter<string, Items::Status>(),
            new ApiEnumConverter<string, Templates::Type>(),
            new ApiEnumConverter<string, UsersTenants::Type>(),
            new ApiEnumConverter<string, Tokens::UserTokenProviderKey>(),
            new ApiEnumConverter<string, Tokens::Status>(),
            new ApiEnumConverter<string, Tokens::ProviderKey>(),
        },
    };

    internal static readonly JsonSerializerOptions ToStringSerializerOptions = new(
        SerializerOptions
    )
    {
        WriteIndented = true,
    };

    /// <summary>
    /// Validates that all required fields are set and that each field's value is of the expected type.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="CourierInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public abstract void Validate();
}
