using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Send.BaseMessageProperties;

/// <summary>
/// Defines the time to wait before delivering the message. You can specify one of
/// the following options. Duration with the number of milliseconds to delay. Until
/// with an ISO 8601 timestamp that specifies when it should be delivered. Until
/// with an OpenStreetMap opening_hours-like format that specifies the [Delivery Window](https://www.courier.com/docs/platform/sending/failover/#delivery-window)
/// (e.g., 'Mo-Fr 08:00-18:00pm')
/// </summary>
[JsonConverter(typeof(ModelConverter<Delay>))]
public sealed record class Delay : ModelBase, IFromRaw<Delay>
{
    /// <summary>
    /// The duration of the delay in milliseconds.
    /// </summary>
    public long? Duration
    {
        get
        {
            if (!this.Properties.TryGetValue("duration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["duration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 8601 timestamp that specifies when it should be delivered or an OpenStreetMap
    /// opening_hours-like format that specifies the [Delivery Window](https://www.courier.com/docs/platform/sending/failover/#delivery-window)
    /// (e.g., 'Mo-Fr 08:00-18:00pm')
    /// </summary>
    public string? Until
    {
        get
        {
            if (!this.Properties.TryGetValue("until", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["until"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Duration;
        _ = this.Until;
    }

    public Delay() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Delay(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Delay FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
