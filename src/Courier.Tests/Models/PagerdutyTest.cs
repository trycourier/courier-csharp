using System.Text.Json;
using Courier.Models;

namespace Courier.Tests.Models;

public class PagerdutyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Pagerduty
        {
            EventAction = "event_action",
            RoutingKey = "routing_key",
            Severity = "severity",
            Source = "source",
        };

        string expectedEventAction = "event_action";
        string expectedRoutingKey = "routing_key";
        string expectedSeverity = "severity";
        string expectedSource = "source";

        Assert.Equal(expectedEventAction, model.EventAction);
        Assert.Equal(expectedRoutingKey, model.RoutingKey);
        Assert.Equal(expectedSeverity, model.Severity);
        Assert.Equal(expectedSource, model.Source);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Pagerduty
        {
            EventAction = "event_action",
            RoutingKey = "routing_key",
            Severity = "severity",
            Source = "source",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Pagerduty>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Pagerduty
        {
            EventAction = "event_action",
            RoutingKey = "routing_key",
            Severity = "severity",
            Source = "source",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Pagerduty>(element);
        Assert.NotNull(deserialized);

        string expectedEventAction = "event_action";
        string expectedRoutingKey = "routing_key";
        string expectedSeverity = "severity";
        string expectedSource = "source";

        Assert.Equal(expectedEventAction, deserialized.EventAction);
        Assert.Equal(expectedRoutingKey, deserialized.RoutingKey);
        Assert.Equal(expectedSeverity, deserialized.Severity);
        Assert.Equal(expectedSource, deserialized.Source);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Pagerduty
        {
            EventAction = "event_action",
            RoutingKey = "routing_key",
            Severity = "severity",
            Source = "source",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Pagerduty { };

        Assert.Null(model.EventAction);
        Assert.False(model.RawData.ContainsKey("event_action"));
        Assert.Null(model.RoutingKey);
        Assert.False(model.RawData.ContainsKey("routing_key"));
        Assert.Null(model.Severity);
        Assert.False(model.RawData.ContainsKey("severity"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Pagerduty { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Pagerduty
        {
            EventAction = null,
            RoutingKey = null,
            Severity = null,
            Source = null,
        };

        Assert.Null(model.EventAction);
        Assert.True(model.RawData.ContainsKey("event_action"));
        Assert.Null(model.RoutingKey);
        Assert.True(model.RawData.ContainsKey("routing_key"));
        Assert.Null(model.Severity);
        Assert.True(model.RawData.ContainsKey("severity"));
        Assert.Null(model.Source);
        Assert.True(model.RawData.ContainsKey("source"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Pagerduty
        {
            EventAction = null,
            RoutingKey = null,
            Severity = null,
            Source = null,
        };

        model.Validate();
    }
}
