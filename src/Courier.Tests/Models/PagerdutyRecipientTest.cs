using System.Text.Json;
using Courier.Models;

namespace Courier.Tests.Models;

public class PagerdutyRecipientTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PagerdutyRecipient
        {
            Pagerduty = new()
            {
                EventAction = "event_action",
                RoutingKey = "routing_key",
                Severity = "severity",
                Source = "source",
            },
        };

        Pagerduty expectedPagerduty = new()
        {
            EventAction = "event_action",
            RoutingKey = "routing_key",
            Severity = "severity",
            Source = "source",
        };

        Assert.Equal(expectedPagerduty, model.Pagerduty);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PagerdutyRecipient
        {
            Pagerduty = new()
            {
                EventAction = "event_action",
                RoutingKey = "routing_key",
                Severity = "severity",
                Source = "source",
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PagerdutyRecipient>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PagerdutyRecipient
        {
            Pagerduty = new()
            {
                EventAction = "event_action",
                RoutingKey = "routing_key",
                Severity = "severity",
                Source = "source",
            },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PagerdutyRecipient>(element);
        Assert.NotNull(deserialized);

        Pagerduty expectedPagerduty = new()
        {
            EventAction = "event_action",
            RoutingKey = "routing_key",
            Severity = "severity",
            Source = "source",
        };

        Assert.Equal(expectedPagerduty, deserialized.Pagerduty);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PagerdutyRecipient
        {
            Pagerduty = new()
            {
                EventAction = "event_action",
                RoutingKey = "routing_key",
                Severity = "severity",
                Source = "source",
            },
        };

        model.Validate();
    }
}
