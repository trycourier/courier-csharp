using System.Text.Json;
using TryCourier.Exceptions;
using TryCourier.Models;
using TryCourier.Models.Automations;
using TryCourier.Models.Brands;
using TryCourier.Models.Bulk;
using Audiences = TryCourier.Models.Audiences;
using Digests = TryCourier.Models.Digests;
using Inbound = TryCourier.Models.Inbound;
using Invoke = TryCourier.Models.Automations.Invoke;
using Items = TryCourier.Models.Tenants.Preferences.Items;
using Journeys = TryCourier.Models.Journeys;
using Lists = TryCourier.Models.Profiles.Lists;
using Messages = TryCourier.Models.Messages;
using Notifications = TryCourier.Models.Notifications;
using Profiles = TryCourier.Models.Profiles;
using Send = TryCourier.Models.Send;
using Templates = TryCourier.Models.Journeys.Templates;
using Tenants = TryCourier.Models.Tenants;
using TenantsTemplates = TryCourier.Models.Tenants.Templates;
using Tokens = TryCourier.Models.Users.Tokens;
using UsersTenants = TryCourier.Models.Users.Tenants;

namespace TryCourier.Core;

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
            new ApiEnumConverter<string, RoutingMethod>(),
            new ApiEnumConverter<string, ChannelClassification>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, ElementalChannelNodeWithTypeIntersectionMember1Type>(),
            new ApiEnumConverter<string, ElementalDividerNodeWithTypeIntersectionMember1Type>(),
            new ApiEnumConverter<string, ElementalHtmlNodeWithTypeIntersectionMember1Type>(),
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
            new ApiEnumConverter<string, Journeys::JourneyVersion>(),
            new ApiEnumConverter<string, Journeys::Type>(),
            new ApiEnumConverter<string, Journeys::TriggerType>(),
            new ApiEnumConverter<string, Journeys::JourneyApiInvokeTriggerNodeType>(),
            new ApiEnumConverter<string, Journeys::Mode>(),
            new ApiEnumConverter<string, Journeys::JourneyDelayDurationNodeType>(),
            new ApiEnumConverter<string, Journeys::JourneyDelayUntilNodeMode>(),
            new ApiEnumConverter<string, Journeys::JourneyDelayUntilNodeType>(),
            new ApiEnumConverter<string, Journeys::JourneyExitNodeType>(),
            new ApiEnumConverter<string, Journeys::Method>(),
            new ApiEnumConverter<string, Journeys::JourneyFetchGetDeleteNodeType>(),
            new ApiEnumConverter<string, Journeys::JourneyFetchPostPutNodeMethod>(),
            new ApiEnumConverter<string, Journeys::JourneyFetchPostPutNodeType>(),
            new ApiEnumConverter<string, Journeys::JourneyMergeStrategy>(),
            new ApiEnumConverter<string, Journeys::RetainType>(),
            new ApiEnumConverter<string, Journeys::Scope>(),
            new ApiEnumConverter<string, Journeys::JourneyBatchNodeType>(),
            new ApiEnumConverter<string, Journeys::JourneyAddToDigestNodeType>(),
            new ApiEnumConverter<string, Journeys::JourneyBranchNodeType>(),
            new ApiEnumConverter<string, Journeys::RequestType>(),
            new ApiEnumConverter<string, Journeys::JourneySegmentTriggerNodeTriggerType>(),
            new ApiEnumConverter<string, Journeys::JourneySegmentTriggerNodeType>(),
            new ApiEnumConverter<string, Journeys::JourneySendNodeType>(),
            new ApiEnumConverter<string, Journeys::JourneyState>(),
            new ApiEnumConverter<string, Journeys::ContentVersion>(),
            new ApiEnumConverter<string, Journeys::ContentScope>(),
            new ApiEnumConverter<string, Journeys::JourneyTemplateGetResponseContentVersion>(),
            new ApiEnumConverter<string, Journeys::JourneyTemplateGetResponseContentScope>(),
            new ApiEnumConverter<string, Journeys::State>(),
            new ApiEnumConverter<
                string,
                Journeys::JourneyTemplateReplaceRequestNotificationContentVersion
            >(),
            new ApiEnumConverter<
                string,
                Journeys::JourneyTemplateReplaceRequestNotificationContentScope
            >(),
            new ApiEnumConverter<string, Journeys::JourneyThrottleDynamicNodeScope>(),
            new ApiEnumConverter<string, Journeys::JourneyThrottleDynamicNodeType>(),
            new ApiEnumConverter<string, Journeys::JourneyThrottleStaticNodeScope>(),
            new ApiEnumConverter<string, Journeys::JourneyThrottleStaticNodeType>(),
            new ApiEnumConverter<string, Journeys::Version>(),
            new ApiEnumConverter<string, Templates::Version>(),
            new ApiEnumConverter<string, Templates::Scope>(),
            new ApiEnumConverter<
                string,
                Templates::TemplateReplaceParamsNotificationContentVersion
            >(),
            new ApiEnumConverter<
                string,
                Templates::TemplateReplaceParamsNotificationContentScope
            >(),
            new ApiEnumConverter<string, Placement>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, JobStatus>(),
            new ApiEnumConverter<string, Digests::Retain>(),
            new ApiEnumConverter<string, Digests::Status>(),
            new ApiEnumConverter<string, Digests::Type>(),
            new ApiEnumConverter<string, Inbound::Type>(),
            new ApiEnumConverter<string, Messages::Status>(),
            new ApiEnumConverter<string, Messages::Reason>(),
            new ApiEnumConverter<string, Notifications::Status>(),
            new ApiEnumConverter<string, Notifications::Type>(),
            new ApiEnumConverter<string, Notifications::BlockType>(),
            new ApiEnumConverter<string, Notifications::NotificationTemplateCreateRequestState>(),
            new ApiEnumConverter<
                string,
                Notifications::NotificationTemplateResponseIntersectionMember1State
            >(),
            new ApiEnumConverter<string, Notifications::NotificationTemplateState>(),
            new ApiEnumConverter<string, Notifications::NotificationTemplateSummaryState>(),
            new ApiEnumConverter<string, Notifications::NotificationTemplateUpdateRequestState>(),
            new ApiEnumConverter<string, Notifications::State>(),
            new ApiEnumConverter<string, Notifications::NotificationReplaceParamsState>(),
            new ApiEnumConverter<string, Profiles::Status>(),
            new ApiEnumConverter<string, Profiles::ProfileReplaceResponseStatus>(),
            new ApiEnumConverter<string, Lists::Status>(),
            new ApiEnumConverter<string, Lists::ListSubscribeResponseStatus>(),
            new ApiEnumConverter<string, Tenants::Status>(),
            new ApiEnumConverter<string, Tenants::Type>(),
            new ApiEnumConverter<string, Tenants::TenantListResponseType>(),
            new ApiEnumConverter<string, Tenants::TenantListUsersResponseType>(),
            new ApiEnumConverter<string, Items::Status>(),
            new ApiEnumConverter<string, TenantsTemplates::Type>(),
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
