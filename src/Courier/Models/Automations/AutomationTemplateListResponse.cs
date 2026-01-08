using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Automations;

[JsonConverter(
    typeof(JsonModelConverter<
        AutomationTemplateListResponse,
        AutomationTemplateListResponseFromRaw
    >)
)]
public sealed record class AutomationTemplateListResponse : JsonModel
{
    /// <summary>
    /// A cursor token for pagination. Present when there are more results available.
    /// </summary>
    public string? Cursor
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "cursor"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "cursor", value);
        }
    }

    public IReadOnlyList<AutomationTemplate>? Templates
    {
        get
        {
            return JsonModel.GetNullableClass<List<AutomationTemplate>>(this.RawData, "templates");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "templates", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Cursor;
        foreach (var item in this.Templates ?? [])
        {
            item.Validate();
        }
    }

    public AutomationTemplateListResponse() { }

    public AutomationTemplateListResponse(
        AutomationTemplateListResponse automationTemplateListResponse
    )
        : base(automationTemplateListResponse) { }

    public AutomationTemplateListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutomationTemplateListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AutomationTemplateListResponseFromRaw.FromRawUnchecked"/>
    public static AutomationTemplateListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AutomationTemplateListResponseFromRaw : IFromRawJson<AutomationTemplateListResponse>
{
    /// <inheritdoc/>
    public AutomationTemplateListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AutomationTemplateListResponse.FromRawUnchecked(rawData);
}
