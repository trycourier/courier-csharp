using System.Collections.Generic;
using System.Text.Json;
using Courier.Models.Auth.AuthIssueTokenParamsProperties;
using Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationAddToDigestStepProperties.IntersectionMember1Properties;
using Courier.Models.Automations.Invoke;
using Courier.Models.Brands.BrandSnippetsProperties.ItemProperties;
using Courier.Models.Bulk.BulkListUsersResponseProperties.ItemProperties.IntersectionMember1Properties;
using Courier.Models.Bulk.UserRecipientProperties.PreferencesProperties.NotificationsProperties.NotificationsItemProperties;
using Courier.Models.Send;
using Courier.Models.Send.BaseMessageProperties.TimeoutProperties;
using Courier.Models.Send.BaseMessageSendToProperties.ToProperties.AudienceRecipientProperties.FilterProperties;
using Courier.Models.Send.BaseMessageSendToProperties.ToProperties.WebhookRecipientProperties.WebhookProperties;
using Courier.Models.Send.BaseMessageSendToProperties.ToProperties.WebhookRecipientProperties.WebhookProperties.AuthenticationProperties;
using Courier.Models.Send.ElementalNodeProperties.UnionMember0Properties;
using Courier.Models.Tenants.DefaultPreferences.Items;
using Courier.Models.Users.Preferences;
using Courier.Models.Users.Tokens.UserTokenProperties;
using AuthenticationProperties = Courier.Models.Send.RecipientProperties.WebhookRecipientProperties.WebhookProperties.AuthenticationProperties;
using AutomationUpdateProfileStepProperties = Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationUpdateProfileStepProperties;
using BaseCheckProperties = Courier.Models.Notifications.Checks.BaseCheckProperties;
using BlockProperties = Courier.Models.Notifications.NotificationGetContentProperties.BlockProperties;
using CategoriesItemProperties = Courier.Models.Bulk.UserRecipientProperties.PreferencesProperties.CategoriesProperties.CategoriesItemProperties;
using FilterProperties = Courier.Models.Send.BaseMessageSendToProperties.ToProperties.UnionMember1Properties.FilterProperties;
using InboundTrackEventParamsProperties = Courier.Models.Inbound.InboundTrackEventParamsProperties;
using IntersectionMember1Properties = Courier.Models.Send.ElementalNodeProperties.UnionMember6Properties.IntersectionMember1Properties;
using ItemUpdateParamsProperties = Courier.Models.Tenants.DefaultPreferences.Items.ItemUpdateParamsProperties;
using JobProperties = Courier.Models.Bulk.BulkRetrieveJobResponseProperties.JobProperties;
using ListDeleteResponseProperties = Courier.Models.Profiles.Lists.ListDeleteResponseProperties;
using ListSubscribeResponseProperties = Courier.Models.Profiles.Lists.ListSubscribeResponseProperties;
using MessageDetailsProperties = Courier.Models.Messages.MessageDetailsProperties;
using MessageRoutingProperties = Courier.Models.Notifications.MessageRoutingProperties;
using NestedFilterConfigProperties = Courier.Models.Audiences.NestedFilterConfigProperties;
using ProfileCreateResponseProperties = Courier.Models.Profiles.ProfileCreateResponseProperties;
using ProfileReplaceResponseProperties = Courier.Models.Profiles.ProfileReplaceResponseProperties;
using RetainProperties = Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationAddToBatchStepProperties.IntersectionMember1Properties.RetainProperties;
using SubscriptionTopicNewProperties = Courier.Models.Tenants.DefaultPreferences.Items.SubscriptionTopicNewProperties;
using TenantAssociationProperties = Courier.Models.Users.Tenants.TenantAssociationProperties;
using TenantListResponseProperties = Courier.Models.Tenants.TenantListResponseProperties;
using TenantListUsersResponseProperties = Courier.Models.Tenants.TenantListUsersResponseProperties;
using TokenAddSingleParamsProperties = Courier.Models.Users.Tokens.TokenAddSingleParamsProperties;
using TypeProperties = Courier.Models.Send.ElementalNodeProperties.TypeProperties;
using UnionMember0Properties = Courier.Models.Audiences.FilterProperties.UnionMember0Properties;
using UnionMember1Properties = Courier.Models.Send.ElementalNodeProperties.UnionMember1Properties;
using UnionMember3Properties = Courier.Models.Send.ElementalNodeProperties.UnionMember3Properties;
using UnionMember4Properties = Courier.Models.Send.ElementalNodeProperties.UnionMember4Properties;
using UnionMember5Properties = Courier.Models.Send.ElementalNodeProperties.UnionMember5Properties;
using UnionMember7Properties = Courier.Models.Send.ElementalNodeProperties.UnionMember7Properties;
using WebhookProperties = Courier.Models.Send.RecipientProperties.WebhookRecipientProperties.WebhookProperties;

namespace Courier.Core;

public abstract record class ModelBase
{
    public Dictionary<string, JsonElement> Properties { get; set; } = [];

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new ApiEnumConverter<string, Criteria>(),
            new ApiEnumConverter<string, Operator>(),
            new ApiEnumConverter<string, Path>(),
            new ApiEnumConverter<string, FilterProperties::Operator>(),
            new ApiEnumConverter<string, FilterProperties::Path>(),
            new ApiEnumConverter<string, Mode>(),
            new ApiEnumConverter<string, Method>(),
            new ApiEnumConverter<string, Profile>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, UnionMember1Properties::Type>(),
            new ApiEnumConverter<string, TypeProperties::Type>(),
            new ApiEnumConverter<string, UnionMember3Properties::Type>(),
            new ApiEnumConverter<string, UnionMember4Properties::Type>(),
            new ApiEnumConverter<string, UnionMember5Properties::Type>(),
            new ApiEnumConverter<string, IntersectionMember1Properties::Type>(),
            new ApiEnumConverter<string, UnionMember7Properties::Type>(),
            new ApiEnumConverter<
                string,
                global::Courier.Models.Send.RecipientProperties.AudienceRecipientProperties.FilterProperties.Operator
            >(),
            new ApiEnumConverter<
                string,
                global::Courier.Models.Send.RecipientProperties.AudienceRecipientProperties.FilterProperties.Path
            >(),
            new ApiEnumConverter<
                string,
                global::Courier.Models.Send.RecipientProperties.UnionMember1Properties.FilterProperties.Operator
            >(),
            new ApiEnumConverter<
                string,
                global::Courier.Models.Send.RecipientProperties.UnionMember1Properties.FilterProperties.Path
            >(),
            new ApiEnumConverter<string, AuthenticationProperties::Mode>(),
            new ApiEnumConverter<string, WebhookProperties::Method>(),
            new ApiEnumConverter<string, WebhookProperties::Profile>(),
            new ApiEnumConverter<string, RoutingMethod>(),
            new ApiEnumConverter<string, UnionMember0Properties::Operator>(),
            new ApiEnumConverter<
                string,
                global::Courier.Models.Audiences.FilterConfigProperties.UnionMember0Properties.Operator
            >(),
            new ApiEnumConverter<string, NestedFilterConfigProperties::Operator>(),
            new ApiEnumConverter<string, Scope>(),
            new ApiEnumConverter<string, Action>(),
            new ApiEnumConverter<
                string,
                global::Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationAddToBatchStepProperties.IntersectionMember1Properties.Action
            >(),
            new ApiEnumConverter<string, RetainProperties::Type>(),
            new ApiEnumConverter<
                string,
                global::Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationAddToBatchStepProperties.IntersectionMember1Properties.Scope
            >(),
            new ApiEnumConverter<
                string,
                global::Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationThrottleStepProperties.IntersectionMember1Properties.Action
            >(),
            new ApiEnumConverter<
                string,
                global::Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationThrottleStepProperties.IntersectionMember1Properties.Scope
            >(),
            new ApiEnumConverter<
                string,
                global::Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationCancelStepProperties.IntersectionMember1Properties.Action
            >(),
            new ApiEnumConverter<
                string,
                global::Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationDelayStepProperties.IntersectionMember1Properties.Action
            >(),
            new ApiEnumConverter<
                string,
                global::Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationFetchDataStepProperties.IntersectionMember1Properties.Action
            >(),
            new ApiEnumConverter<
                string,
                global::Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationFetchDataStepProperties.IntersectionMember1Properties.WebhookProperties.Method
            >(),
            new ApiEnumConverter<
                string,
                global::Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationInvokeStepProperties.IntersectionMember1Properties.Action
            >(),
            new ApiEnumConverter<
                string,
                global::Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationSendStepProperties.IntersectionMember1Properties.Action
            >(),
            new ApiEnumConverter<
                string,
                global::Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationV2SendStepProperties.IntersectionMember1Properties.Action
            >(),
            new ApiEnumConverter<
                string,
                global::Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationSendListStepProperties.IntersectionMember1Properties.Action
            >(),
            new ApiEnumConverter<string, AutomationUpdateProfileStepProperties::Action>(),
            new ApiEnumConverter<string, MergeAlgorithm>(),
            new ApiEnumConverter<string, Format>(),
            new ApiEnumConverter<string, Source>(),
            new ApiEnumConverter<string, CategoriesItemProperties::Source>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, JobProperties::Status>(),
            new ApiEnumConverter<string, InboundTrackEventParamsProperties::Type>(),
            new ApiEnumConverter<string, MessageDetailsProperties::Status>(),
            new ApiEnumConverter<string, MessageDetailsProperties::Reason>(),
            new ApiEnumConverter<string, MessageRoutingProperties::Method>(),
            new ApiEnumConverter<string, BlockProperties::Type>(),
            new ApiEnumConverter<string, BaseCheckProperties::Status>(),
            new ApiEnumConverter<string, BaseCheckProperties::Type>(),
            new ApiEnumConverter<string, ProfileCreateResponseProperties::Status>(),
            new ApiEnumConverter<string, ProfileReplaceResponseProperties::Status>(),
            new ApiEnumConverter<string, ListDeleteResponseProperties::Status>(),
            new ApiEnumConverter<string, ListSubscribeResponseProperties::Status>(),
            new ApiEnumConverter<string, TenantListResponseProperties::Type>(),
            new ApiEnumConverter<string, TenantListUsersResponseProperties::Type>(),
            new ApiEnumConverter<string, ChannelClassification>(),
            new ApiEnumConverter<string, SubscriptionTopicNewProperties::Status>(),
            new ApiEnumConverter<string, ItemUpdateParamsProperties::Status>(),
            new ApiEnumConverter<string, PreferenceStatus>(),
            new ApiEnumConverter<string, TenantAssociationProperties::Type>(),
            new ApiEnumConverter<
                string,
                global::Courier.Models.Users.Tenants.TenantListResponseProperties.Type
            >(),
            new ApiEnumConverter<string, ProviderKey>(),
            new ApiEnumConverter<
                string,
                global::Courier.Models.Users.Tokens.TokenRetrieveSingleResponseProperties.IntersectionMember1Properties.Status
            >(),
            new ApiEnumConverter<string, TokenAddSingleParamsProperties::ProviderKey>(),
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
