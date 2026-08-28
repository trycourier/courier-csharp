using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models;

namespace TryCourier.Tests.Models;

public class ElementalImageNodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElementalImageNode
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Src = "src",
            Align = Alignment.Center,
            AltText = "altText",
            BorderColor = "border_color",
            BorderSize = "border_size",
            Href = "href",
            Padding = "padding",
            Width = "width",
        };

        List<string> expectedChannels = ["string"];
        string expectedIf = "if";
        string expectedLoop = "loop";
        string expectedRef = "ref";
        string expectedSrc = "src";
        ApiEnum<string, Alignment> expectedAlign = Alignment.Center;
        string expectedAltText = "altText";
        string expectedBorderColor = "border_color";
        string expectedBorderSize = "border_size";
        string expectedHref = "href";
        string expectedPadding = "padding";
        string expectedWidth = "width";

        Assert.NotNull(model.Channels);
        Assert.Equal(expectedChannels.Count, model.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], model.Channels[i]);
        }
        Assert.Equal(expectedIf, model.If);
        Assert.Equal(expectedLoop, model.Loop);
        Assert.Equal(expectedRef, model.Ref);
        Assert.Equal(expectedSrc, model.Src);
        Assert.Equal(expectedAlign, model.Align);
        Assert.Equal(expectedAltText, model.AltText);
        Assert.Equal(expectedBorderColor, model.BorderColor);
        Assert.Equal(expectedBorderSize, model.BorderSize);
        Assert.Equal(expectedHref, model.Href);
        Assert.Equal(expectedPadding, model.Padding);
        Assert.Equal(expectedWidth, model.Width);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ElementalImageNode
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Src = "src",
            Align = Alignment.Center,
            AltText = "altText",
            BorderColor = "border_color",
            BorderSize = "border_size",
            Href = "href",
            Padding = "padding",
            Width = "width",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalImageNode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ElementalImageNode
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Src = "src",
            Align = Alignment.Center,
            AltText = "altText",
            BorderColor = "border_color",
            BorderSize = "border_size",
            Href = "href",
            Padding = "padding",
            Width = "width",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalImageNode>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedChannels = ["string"];
        string expectedIf = "if";
        string expectedLoop = "loop";
        string expectedRef = "ref";
        string expectedSrc = "src";
        ApiEnum<string, Alignment> expectedAlign = Alignment.Center;
        string expectedAltText = "altText";
        string expectedBorderColor = "border_color";
        string expectedBorderSize = "border_size";
        string expectedHref = "href";
        string expectedPadding = "padding";
        string expectedWidth = "width";

        Assert.NotNull(deserialized.Channels);
        Assert.Equal(expectedChannels.Count, deserialized.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], deserialized.Channels[i]);
        }
        Assert.Equal(expectedIf, deserialized.If);
        Assert.Equal(expectedLoop, deserialized.Loop);
        Assert.Equal(expectedRef, deserialized.Ref);
        Assert.Equal(expectedSrc, deserialized.Src);
        Assert.Equal(expectedAlign, deserialized.Align);
        Assert.Equal(expectedAltText, deserialized.AltText);
        Assert.Equal(expectedBorderColor, deserialized.BorderColor);
        Assert.Equal(expectedBorderSize, deserialized.BorderSize);
        Assert.Equal(expectedHref, deserialized.Href);
        Assert.Equal(expectedPadding, deserialized.Padding);
        Assert.Equal(expectedWidth, deserialized.Width);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ElementalImageNode
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Src = "src",
            Align = Alignment.Center,
            AltText = "altText",
            BorderColor = "border_color",
            BorderSize = "border_size",
            Href = "href",
            Padding = "padding",
            Width = "width",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ElementalImageNode
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Src = "src",
            AltText = "altText",
            BorderColor = "border_color",
            BorderSize = "border_size",
            Href = "href",
            Padding = "padding",
            Width = "width",
        };

        Assert.Null(model.Align);
        Assert.False(model.RawData.ContainsKey("align"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ElementalImageNode
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Src = "src",
            AltText = "altText",
            BorderColor = "border_color",
            BorderSize = "border_size",
            Href = "href",
            Padding = "padding",
            Width = "width",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ElementalImageNode
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Src = "src",
            AltText = "altText",
            BorderColor = "border_color",
            BorderSize = "border_size",
            Href = "href",
            Padding = "padding",
            Width = "width",

            // Null should be interpreted as omitted for these properties
            Align = null,
        };

        Assert.Null(model.Align);
        Assert.False(model.RawData.ContainsKey("align"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ElementalImageNode
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Src = "src",
            AltText = "altText",
            BorderColor = "border_color",
            BorderSize = "border_size",
            Href = "href",
            Padding = "padding",
            Width = "width",

            // Null should be interpreted as omitted for these properties
            Align = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ElementalImageNode { Src = "src", Align = Alignment.Center };

        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.If);
        Assert.False(model.RawData.ContainsKey("if"));
        Assert.Null(model.Loop);
        Assert.False(model.RawData.ContainsKey("loop"));
        Assert.Null(model.Ref);
        Assert.False(model.RawData.ContainsKey("ref"));
        Assert.Null(model.AltText);
        Assert.False(model.RawData.ContainsKey("altText"));
        Assert.Null(model.BorderColor);
        Assert.False(model.RawData.ContainsKey("border_color"));
        Assert.Null(model.BorderSize);
        Assert.False(model.RawData.ContainsKey("border_size"));
        Assert.Null(model.Href);
        Assert.False(model.RawData.ContainsKey("href"));
        Assert.Null(model.Padding);
        Assert.False(model.RawData.ContainsKey("padding"));
        Assert.Null(model.Width);
        Assert.False(model.RawData.ContainsKey("width"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ElementalImageNode { Src = "src", Align = Alignment.Center };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ElementalImageNode
        {
            Src = "src",
            Align = Alignment.Center,

            Channels = null,
            If = null,
            Loop = null,
            Ref = null,
            AltText = null,
            BorderColor = null,
            BorderSize = null,
            Href = null,
            Padding = null,
            Width = null,
        };

        Assert.Null(model.Channels);
        Assert.True(model.RawData.ContainsKey("channels"));
        Assert.Null(model.If);
        Assert.True(model.RawData.ContainsKey("if"));
        Assert.Null(model.Loop);
        Assert.True(model.RawData.ContainsKey("loop"));
        Assert.Null(model.Ref);
        Assert.True(model.RawData.ContainsKey("ref"));
        Assert.Null(model.AltText);
        Assert.True(model.RawData.ContainsKey("altText"));
        Assert.Null(model.BorderColor);
        Assert.True(model.RawData.ContainsKey("border_color"));
        Assert.Null(model.BorderSize);
        Assert.True(model.RawData.ContainsKey("border_size"));
        Assert.Null(model.Href);
        Assert.True(model.RawData.ContainsKey("href"));
        Assert.Null(model.Padding);
        Assert.True(model.RawData.ContainsKey("padding"));
        Assert.Null(model.Width);
        Assert.True(model.RawData.ContainsKey("width"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ElementalImageNode
        {
            Src = "src",
            Align = Alignment.Center,

            Channels = null,
            If = null,
            Loop = null,
            Ref = null,
            AltText = null,
            BorderColor = null,
            BorderSize = null,
            Href = null,
            Padding = null,
            Width = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ElementalImageNode
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Src = "src",
            Align = Alignment.Center,
            AltText = "altText",
            BorderColor = "border_color",
            BorderSize = "border_size",
            Href = "href",
            Padding = "padding",
            Width = "width",
        };

        ElementalImageNode copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ElementalImageNodeIntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElementalImageNodeIntersectionMember1
        {
            Src = "src",
            Align = Alignment.Center,
            AltText = "altText",
            BorderColor = "border_color",
            BorderSize = "border_size",
            Href = "href",
            Padding = "padding",
            Width = "width",
        };

        string expectedSrc = "src";
        ApiEnum<string, Alignment> expectedAlign = Alignment.Center;
        string expectedAltText = "altText";
        string expectedBorderColor = "border_color";
        string expectedBorderSize = "border_size";
        string expectedHref = "href";
        string expectedPadding = "padding";
        string expectedWidth = "width";

        Assert.Equal(expectedSrc, model.Src);
        Assert.Equal(expectedAlign, model.Align);
        Assert.Equal(expectedAltText, model.AltText);
        Assert.Equal(expectedBorderColor, model.BorderColor);
        Assert.Equal(expectedBorderSize, model.BorderSize);
        Assert.Equal(expectedHref, model.Href);
        Assert.Equal(expectedPadding, model.Padding);
        Assert.Equal(expectedWidth, model.Width);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ElementalImageNodeIntersectionMember1
        {
            Src = "src",
            Align = Alignment.Center,
            AltText = "altText",
            BorderColor = "border_color",
            BorderSize = "border_size",
            Href = "href",
            Padding = "padding",
            Width = "width",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalImageNodeIntersectionMember1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ElementalImageNodeIntersectionMember1
        {
            Src = "src",
            Align = Alignment.Center,
            AltText = "altText",
            BorderColor = "border_color",
            BorderSize = "border_size",
            Href = "href",
            Padding = "padding",
            Width = "width",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalImageNodeIntersectionMember1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSrc = "src";
        ApiEnum<string, Alignment> expectedAlign = Alignment.Center;
        string expectedAltText = "altText";
        string expectedBorderColor = "border_color";
        string expectedBorderSize = "border_size";
        string expectedHref = "href";
        string expectedPadding = "padding";
        string expectedWidth = "width";

        Assert.Equal(expectedSrc, deserialized.Src);
        Assert.Equal(expectedAlign, deserialized.Align);
        Assert.Equal(expectedAltText, deserialized.AltText);
        Assert.Equal(expectedBorderColor, deserialized.BorderColor);
        Assert.Equal(expectedBorderSize, deserialized.BorderSize);
        Assert.Equal(expectedHref, deserialized.Href);
        Assert.Equal(expectedPadding, deserialized.Padding);
        Assert.Equal(expectedWidth, deserialized.Width);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ElementalImageNodeIntersectionMember1
        {
            Src = "src",
            Align = Alignment.Center,
            AltText = "altText",
            BorderColor = "border_color",
            BorderSize = "border_size",
            Href = "href",
            Padding = "padding",
            Width = "width",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ElementalImageNodeIntersectionMember1 { Src = "src" };

        Assert.Null(model.Align);
        Assert.False(model.RawData.ContainsKey("align"));
        Assert.Null(model.AltText);
        Assert.False(model.RawData.ContainsKey("altText"));
        Assert.Null(model.BorderColor);
        Assert.False(model.RawData.ContainsKey("border_color"));
        Assert.Null(model.BorderSize);
        Assert.False(model.RawData.ContainsKey("border_size"));
        Assert.Null(model.Href);
        Assert.False(model.RawData.ContainsKey("href"));
        Assert.Null(model.Padding);
        Assert.False(model.RawData.ContainsKey("padding"));
        Assert.Null(model.Width);
        Assert.False(model.RawData.ContainsKey("width"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ElementalImageNodeIntersectionMember1 { Src = "src" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ElementalImageNodeIntersectionMember1
        {
            Src = "src",

            Align = null,
            AltText = null,
            BorderColor = null,
            BorderSize = null,
            Href = null,
            Padding = null,
            Width = null,
        };

        Assert.Null(model.Align);
        Assert.True(model.RawData.ContainsKey("align"));
        Assert.Null(model.AltText);
        Assert.True(model.RawData.ContainsKey("altText"));
        Assert.Null(model.BorderColor);
        Assert.True(model.RawData.ContainsKey("border_color"));
        Assert.Null(model.BorderSize);
        Assert.True(model.RawData.ContainsKey("border_size"));
        Assert.Null(model.Href);
        Assert.True(model.RawData.ContainsKey("href"));
        Assert.Null(model.Padding);
        Assert.True(model.RawData.ContainsKey("padding"));
        Assert.Null(model.Width);
        Assert.True(model.RawData.ContainsKey("width"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ElementalImageNodeIntersectionMember1
        {
            Src = "src",

            Align = null,
            AltText = null,
            BorderColor = null,
            BorderSize = null,
            Href = null,
            Padding = null,
            Width = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ElementalImageNodeIntersectionMember1
        {
            Src = "src",
            Align = Alignment.Center,
            AltText = "altText",
            BorderColor = "border_color",
            BorderSize = "border_size",
            Href = "href",
            Padding = "padding",
            Width = "width",
        };

        ElementalImageNodeIntersectionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}
