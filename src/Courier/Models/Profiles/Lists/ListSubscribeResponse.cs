using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Profiles.Lists;

[JsonConverter(typeof(JsonModelConverter<ListSubscribeResponse, ListSubscribeResponseFromRaw>))]
public sealed record class ListSubscribeResponse : JsonModel
{
    public required ApiEnum<string, ListSubscribeResponseStatus> Status
    {
        get
        {
            return this._rawData.GetNotNullClass<ApiEnum<string, ListSubscribeResponseStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Status.Validate();
    }

    public ListSubscribeResponse() { }

    public ListSubscribeResponse(ListSubscribeResponse listSubscribeResponse)
        : base(listSubscribeResponse) { }

    public ListSubscribeResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ListSubscribeResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ListSubscribeResponseFromRaw.FromRawUnchecked"/>
    public static ListSubscribeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ListSubscribeResponse(ApiEnum<string, ListSubscribeResponseStatus> status)
        : this()
    {
        this.Status = status;
    }
}

class ListSubscribeResponseFromRaw : IFromRawJson<ListSubscribeResponse>
{
    /// <inheritdoc/>
    public ListSubscribeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ListSubscribeResponse.FromRawUnchecked(rawData);
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
