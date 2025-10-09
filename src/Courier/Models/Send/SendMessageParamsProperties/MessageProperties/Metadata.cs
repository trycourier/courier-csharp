using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Send.SendMessageParamsProperties.MessageProperties;

[JsonConverter(typeof(ModelConverter<Metadata>))]
public sealed record class Metadata : ModelBase, IFromRaw<Metadata>
{
    public string? Event
    {
        get
        {
            if (!this.Properties.TryGetValue("event", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["event"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public List<string>? Tags
    {
        get
        {
            if (!this.Properties.TryGetValue("tags", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["tags"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? TraceID
    {
        get
        {
            if (!this.Properties.TryGetValue("trace_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["trace_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Utm? Utm
    {
        get
        {
            if (!this.Properties.TryGetValue("utm", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Utm?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["utm"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Event;
        foreach (var item in this.Tags ?? [])
        {
            _ = item;
        }
        _ = this.TraceID;
        this.Utm?.Validate();
    }

    public Metadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Metadata(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Metadata FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
