using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Profiles.Lists;

[JsonConverter(typeof(ModelConverter<ListSubscribeResponse>))]
public sealed record class ListSubscribeResponse : ModelBase, IFromRaw<ListSubscribeResponse>
{
    public required ApiEnum<string, ListSubscribeResponseStatus> Status
    {
        get
        {
            if (!this._properties.TryGetValue("status", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'status' cannot be null",
                    new System::ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, ListSubscribeResponseStatus>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Status.Validate();
    }

    public ListSubscribeResponse() { }

    public ListSubscribeResponse(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ListSubscribeResponse(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static ListSubscribeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public ListSubscribeResponse(ApiEnum<string, ListSubscribeResponseStatus> status)
        : this()
    {
        this.Status = status;
    }
}

[JsonConverter(typeof(ListSubscribeResponseStatusConverter))]
public enum ListSubscribeResponseStatus
{
    Success,
}

sealed class ListSubscribeResponseStatusConverter : JsonConverter<ListSubscribeResponseStatus>
{
    public override ListSubscribeResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SUCCESS" => ListSubscribeResponseStatus.Success,
            _ => (ListSubscribeResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ListSubscribeResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ListSubscribeResponseStatus.Success => "SUCCESS",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
