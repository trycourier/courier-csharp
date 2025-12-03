using System.Text.Json;
using Courier.Models;

namespace Courier.Tests.Models;

public class UtmTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Utm
        {
            Campaign = "campaign",
            Content = "content",
            Medium = "medium",
            Source = "source",
            Term = "term",
        };

        string expectedCampaign = "campaign";
        string expectedContent = "content";
        string expectedMedium = "medium";
        string expectedSource = "source";
        string expectedTerm = "term";

        Assert.Equal(expectedCampaign, model.Campaign);
        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedMedium, model.Medium);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedTerm, model.Term);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Utm
        {
            Campaign = "campaign",
            Content = "content",
            Medium = "medium",
            Source = "source",
            Term = "term",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Utm>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Utm
        {
            Campaign = "campaign",
            Content = "content",
            Medium = "medium",
            Source = "source",
            Term = "term",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Utm>(json);
        Assert.NotNull(deserialized);

        string expectedCampaign = "campaign";
        string expectedContent = "content";
        string expectedMedium = "medium";
        string expectedSource = "source";
        string expectedTerm = "term";

        Assert.Equal(expectedCampaign, deserialized.Campaign);
        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedMedium, deserialized.Medium);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedTerm, deserialized.Term);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Utm
        {
            Campaign = "campaign",
            Content = "content",
            Medium = "medium",
            Source = "source",
            Term = "term",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Utm { };

        Assert.Null(model.Campaign);
        Assert.False(model.RawData.ContainsKey("campaign"));
        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.Medium);
        Assert.False(model.RawData.ContainsKey("medium"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
        Assert.Null(model.Term);
        Assert.False(model.RawData.ContainsKey("term"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Utm { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Utm
        {
            Campaign = null,
            Content = null,
            Medium = null,
            Source = null,
            Term = null,
        };

        Assert.Null(model.Campaign);
        Assert.True(model.RawData.ContainsKey("campaign"));
        Assert.Null(model.Content);
        Assert.True(model.RawData.ContainsKey("content"));
        Assert.Null(model.Medium);
        Assert.True(model.RawData.ContainsKey("medium"));
        Assert.Null(model.Source);
        Assert.True(model.RawData.ContainsKey("source"));
        Assert.Null(model.Term);
        Assert.True(model.RawData.ContainsKey("term"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Utm
        {
            Campaign = null,
            Content = null,
            Medium = null,
            Source = null,
            Term = null,
        };

        model.Validate();
    }
}
