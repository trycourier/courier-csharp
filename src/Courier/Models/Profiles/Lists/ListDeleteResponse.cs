using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Profiles.Lists;

[JsonConverter(typeof(JsonModelConverter<ListDeleteResponse, ListDeleteResponseFromRaw>))]
public sealed record class ListDeleteResponse : JsonModel
{
    public required ApiEnum<string, global::Courier.Models.Profiles.Lists.Status> Status
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, global::Courier.Models.Profiles.Lists.Status>
            >(this.RawData, "status");
        }
        init { JsonModel.Set(this._rawData, "status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Status.Validate();
    }

    public ListDeleteResponse() { }

    public ListDeleteResponse(ListDeleteResponse listDeleteResponse)
        : base(listDeleteResponse) { }

    public ListDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ListDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ListDeleteResponseFromRaw.FromRawUnchecked"/>
    public static ListDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ListDeleteResponse(ApiEnum<string, global::Courier.Models.Profiles.Lists.Status> status)
        : this()
    {
        this.Status = status;
    }
}

class ListDeleteResponseFromRaw : IFromRawJson<ListDeleteResponse>
{
    /// <inheritdoc/>
    public ListDeleteResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ListDeleteResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(global::Courier.Models.Profiles.Lists.StatusConverter))]
public enum Status
{
    Success,
}

sealed class StatusConverter : JsonConverter<global::Courier.Models.Profiles.Lists.Status>
{
    public override global::Courier.Models.Profiles.Lists.Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SUCCESS" => global::Courier.Models.Profiles.Lists.Status.Success,
            _ => (global::Courier.Models.Profiles.Lists.Status)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Courier.Models.Profiles.Lists.Status value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Courier.Models.Profiles.Lists.Status.Success => "SUCCESS",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
