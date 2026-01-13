using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Automations;

[JsonConverter(typeof(JsonModelConverter<AutomationTemplate, AutomationTemplateFromRaw>))]
public sealed record class AutomationTemplate : JsonModel
{
    /// <summary>
    /// The unique identifier of the automation template.
    /// </summary>
    public required string ID
    {
        get { return this._rawData.GetNotNullClass<string>("id"); }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The name of the automation template.
    /// </summary>
    public required string Name
    {
        get { return this._rawData.GetNotNullClass<string>("name"); }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The version of the template published, draft.
    /// </summary>
    public required ApiEnum<string, AutomationTemplateVersion> Version
    {
        get
        {
            return this._rawData.GetNotNullClass<ApiEnum<string, AutomationTemplateVersion>>(
                "version"
            );
        }
        init { this._rawData.Set("version", value); }
    }

    /// <summary>
    /// ISO 8601 timestamp when the template was created.
    /// </summary>
    public System::DateTimeOffset? CreatedAt
    {
        get { return this._rawData.GetNullableStruct<System::DateTimeOffset>("createdAt"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    /// <summary>
    /// ISO 8601 timestamp when the template was last updated.
    /// </summary>
    public System::DateTimeOffset? UpdatedAt
    {
        get { return this._rawData.GetNullableStruct<System::DateTimeOffset>("updatedAt"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updatedAt", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        this.Version.Validate();
        _ = this.CreatedAt;
        _ = this.UpdatedAt;
    }

    public AutomationTemplate() { }

    public AutomationTemplate(AutomationTemplate automationTemplate)
        : base(automationTemplate) { }

    public AutomationTemplate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutomationTemplate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AutomationTemplateFromRaw.FromRawUnchecked"/>
    public static AutomationTemplate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AutomationTemplateFromRaw : IFromRawJson<AutomationTemplate>
{
    /// <inheritdoc/>
    public AutomationTemplate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AutomationTemplate.FromRawUnchecked(rawData);
}

/// <summary>
/// The version of the template published, draft.
/// </summary>
[JsonConverter(typeof(AutomationTemplateVersionConverter))]
public enum AutomationTemplateVersion
{
    Published,
    Draft,
}

sealed class AutomationTemplateVersionConverter : JsonConverter<AutomationTemplateVersion>
{
    public override AutomationTemplateVersion Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "published" => AutomationTemplateVersion.Published,
            "draft" => AutomationTemplateVersion.Draft,
            _ => (AutomationTemplateVersion)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AutomationTemplateVersion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AutomationTemplateVersion.Published => "published",
                AutomationTemplateVersion.Draft => "draft",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
