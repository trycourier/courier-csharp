using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Notifications.Checks;

[JsonConverter(typeof(ModelConverter<CheckUpdateResponse, CheckUpdateResponseFromRaw>))]
public sealed record class CheckUpdateResponse : ModelBase
{
    public required IReadOnlyList<Check> Checks
    {
        get
        {
            if (!this._rawData.TryGetValue("checks", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'checks' cannot be null",
                    new ArgumentOutOfRangeException("checks", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Check>>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'checks' cannot be null",
                    new ArgumentNullException("checks")
                );
        }
        init
        {
            this._rawData["checks"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Checks)
        {
            item.Validate();
        }
    }

    public CheckUpdateResponse() { }

    public CheckUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static CheckUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CheckUpdateResponse(List<Check> checks)
        : this()
    {
        this.Checks = checks;
    }
}

class CheckUpdateResponseFromRaw : IFromRaw<CheckUpdateResponse>
{
    public CheckUpdateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CheckUpdateResponse.FromRawUnchecked(rawData);
}
