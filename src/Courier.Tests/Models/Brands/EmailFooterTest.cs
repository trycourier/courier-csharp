using System.Text.Json;
using Courier.Models.Brands;

namespace Courier.Tests.Models.Brands;

public class EmailFooterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EmailFooter { Content = "content", InheritDefault = true };

        string expectedContent = "content";
        bool expectedInheritDefault = true;

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedInheritDefault, model.InheritDefault);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EmailFooter { Content = "content", InheritDefault = true };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<EmailFooter>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EmailFooter { Content = "content", InheritDefault = true };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<EmailFooter>(json);
        Assert.NotNull(deserialized);

        string expectedContent = "content";
        bool expectedInheritDefault = true;

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedInheritDefault, deserialized.InheritDefault);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EmailFooter { Content = "content", InheritDefault = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EmailFooter { };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.InheritDefault);
        Assert.False(model.RawData.ContainsKey("inheritDefault"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new EmailFooter { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new EmailFooter { Content = null, InheritDefault = null };

        Assert.Null(model.Content);
        Assert.True(model.RawData.ContainsKey("content"));
        Assert.Null(model.InheritDefault);
        Assert.True(model.RawData.ContainsKey("inheritDefault"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EmailFooter { Content = null, InheritDefault = null };

        model.Validate();
    }
}
