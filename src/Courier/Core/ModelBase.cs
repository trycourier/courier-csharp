using System.Collections.Generic;
using System.Text.Json;
using Courier.Exceptions;
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
    private protected FreezableDictionary<string, JsonElement> _rawData = [];

    public IReadOnlyDictionary<string, JsonElement> RawData
    {
        get { return this._rawData.Freeze(); }
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

    internal static void Set<T>(IDictionary<string, JsonElement> dictionary, string key, T value)
    {
        dictionary[key] = JsonSerializer.SerializeToElement(value, SerializerOptions);
    }

    internal static T GetNotNullClass<T>(
        IReadOnlyDictionary<string, JsonElement> dictionary,
        string key
    )
        where T : class
    {
        if (!dictionary.TryGetValue(key, out JsonElement element))
        {
            throw new CourierInvalidDataException($"'{key}' cannot be absent");
        }

        try
        {
            return JsonSerializer.Deserialize<T>(element, SerializerOptions)
                ?? throw new CourierInvalidDataException($"'{key}' cannot be null");
        }
        catch (JsonException e)
        {
            throw new CourierInvalidDataException(
                $"'{key}' must be of type {typeof(T).FullName}",
                e
            );
        }
    }

    internal static T GetNotNullStruct<T>(
        IReadOnlyDictionary<string, JsonElement> dictionary,
        string key
    )
        where T : struct
    {
        if (!dictionary.TryGetValue(key, out JsonElement element))
        {
            throw new CourierInvalidDataException($"'{key}' cannot be absent");
        }

        try
        {
            return JsonSerializer.Deserialize<T?>(element, SerializerOptions)
                ?? throw new CourierInvalidDataException($"'{key}' cannot be null");
        }
        catch (JsonException e)
        {
            throw new CourierInvalidDataException(
                $"'{key}' must be of type {typeof(T).FullName}",
                e
            );
        }
    }

    internal static T? GetNullableClass<T>(
        IReadOnlyDictionary<string, JsonElement> dictionary,
        string key
    )
        where T : class
    {
        if (!dictionary.TryGetValue(key, out JsonElement element))
        {
            return null;
        }

        try
        {
            return JsonSerializer.Deserialize<T?>(element, SerializerOptions);
        }
        catch (JsonException e)
        {
            throw new CourierInvalidDataException(
                $"'{key}' must be of type {typeof(T).FullName}",
                e
            );
        }
    }

    internal static T? GetNullableStruct<T>(
        IReadOnlyDictionary<string, JsonElement> dictionary,
        string key
    )
        where T : struct
    {
        if (!dictionary.TryGetValue(key, out JsonElement element))
        {
            return null;
        }

        try
        {
            return JsonSerializer.Deserialize<T?>(element, SerializerOptions);
        }
        catch (JsonException e)
        {
            throw new CourierInvalidDataException(
                $"'{key}' must be of type {typeof(T).FullName}",
                e
            );
        }
    }

    public sealed override string? ToString()
    {
        return JsonSerializer.Serialize(this.RawData, _toStringSerializerOptions);
    }

    public virtual bool Equals(ModelBase? other)
    {
        if (other == null || this.RawData.Count != other.RawData.Count)
        {
            return false;
        }

        foreach (var item in this.RawData)
        {
            if (!other.RawData.TryGetValue(item.Key, out var otherValue))
            {
                return false;
            }

            if (!JsonElement.DeepEquals(item.Value, otherValue))
            {
                return false;
            }
        }

        return true;
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public abstract void Validate();
}

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
interface IFromRaw<T>
{
    /// <summary>
    /// NOTE: This interface is in the style of a factory instance instead of using
    /// abstract static methods because .NET Standard 2.0 doesn't support abstract
    /// static methods.
    /// </summary>
    T FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData);
}
