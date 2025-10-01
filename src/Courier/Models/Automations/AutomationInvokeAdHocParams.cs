using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Automations.AutomationInvokeAdHocParamsProperties;

namespace Courier.Models.Automations;

/// <summary>
/// Invoke an ad hoc automation run. This endpoint accepts a JSON payload with a series
/// of automation steps. For information about what steps are available, checkout
/// the ad hoc automation guide [here](https://www.courier.com/docs/automations/steps/).
/// </summary>
public sealed record class AutomationInvokeAdHocParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required Automation Automation
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("automation", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'automation' cannot be null",
                    new ArgumentOutOfRangeException("automation", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Automation>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'automation' cannot be null",
                    new ArgumentNullException("automation")
                );
        }
        set
        {
            this.BodyProperties["automation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Brand
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("brand", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["brand"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dictionary<string, JsonElement>? Data
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("data", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement? Profile
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("profile", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<JsonElement?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["profile"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Recipient
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("recipient", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["recipient"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Template
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("template", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["template"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(ICourierClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/automations/invoke")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ICourierClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
