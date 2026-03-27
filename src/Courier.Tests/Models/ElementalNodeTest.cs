using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models;

namespace Courier.Tests.Models;

public class ElementalNodeTest : TestBase
{
    [Fact]
    public void TextNodeWithTypeValidationWorks()
    {
        ElementalNode value = new ElementalTextNodeWithType()
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
        };
        value.Validate();
    }

    [Fact]
    public void MetaNodeWithTypeValidationWorks()
    {
        ElementalNode value = new ElementalMetaNodeWithType()
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = ElementalMetaNodeWithTypeIntersectionMember1Type.Meta,
        };
        value.Validate();
    }

    [Fact]
    public void ChannelNodeWithTypeValidationWorks()
    {
        ElementalNode value = new ElementalChannelNodeWithType()
        {
            Type = ElementalChannelNodeWithTypeIntersectionMember1Type.Channel,
        };
        value.Validate();
    }

    [Fact]
    public void ImageNodeWithTypeValidationWorks()
    {
        ElementalNode value = new ElementalImageNodeWithType()
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = ElementalImageNodeWithTypeIntersectionMember1Type.Image,
        };
        value.Validate();
    }

    [Fact]
    public void ActionNodeWithTypeValidationWorks()
    {
        ElementalNode value = new ElementalActionNodeWithType()
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = Type.Action,
        };
        value.Validate();
    }

    [Fact]
    public void DividerNodeWithTypeValidationWorks()
    {
        ElementalNode value = new ElementalDividerNodeWithType()
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = ElementalDividerNodeWithTypeIntersectionMember1Type.Divider,
        };
        value.Validate();
    }

    [Fact]
    public void QuoteNodeWithTypeValidationWorks()
    {
        ElementalNode value = new ElementalQuoteNodeWithType()
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = ElementalQuoteNodeWithTypeIntersectionMember1Type.Quote,
        };
        value.Validate();
    }

    [Fact]
    public void UnionMember7ValidationWorks()
    {
        ElementalNode value = new UnionMember7()
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = UnionMember7IntersectionMember1Type.Html,
        };
        value.Validate();
    }

    [Fact]
    public void TextNodeWithTypeSerializationRoundtripWorks()
    {
        ElementalNode value = new ElementalTextNodeWithType()
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalNode>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MetaNodeWithTypeSerializationRoundtripWorks()
    {
        ElementalNode value = new ElementalMetaNodeWithType()
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = ElementalMetaNodeWithTypeIntersectionMember1Type.Meta,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalNode>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ChannelNodeWithTypeSerializationRoundtripWorks()
    {
        ElementalNode value = new ElementalChannelNodeWithType()
        {
            Type = ElementalChannelNodeWithTypeIntersectionMember1Type.Channel,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalNode>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ImageNodeWithTypeSerializationRoundtripWorks()
    {
        ElementalNode value = new ElementalImageNodeWithType()
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = ElementalImageNodeWithTypeIntersectionMember1Type.Image,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalNode>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ActionNodeWithTypeSerializationRoundtripWorks()
    {
        ElementalNode value = new ElementalActionNodeWithType()
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = Type.Action,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalNode>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DividerNodeWithTypeSerializationRoundtripWorks()
    {
        ElementalNode value = new ElementalDividerNodeWithType()
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = ElementalDividerNodeWithTypeIntersectionMember1Type.Divider,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalNode>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void QuoteNodeWithTypeSerializationRoundtripWorks()
    {
        ElementalNode value = new ElementalQuoteNodeWithType()
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = ElementalQuoteNodeWithTypeIntersectionMember1Type.Quote,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalNode>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnionMember7SerializationRoundtripWorks()
    {
        ElementalNode value = new UnionMember7()
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = UnionMember7IntersectionMember1Type.Html,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalNode>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UnionMember7Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnionMember7
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = UnionMember7IntersectionMember1Type.Html,
        };

        List<string> expectedChannels = ["string"];
        string expectedIf = "if";
        string expectedLoop = "loop";
        string expectedRef = "ref";
        ApiEnum<string, UnionMember7IntersectionMember1Type> expectedType =
            UnionMember7IntersectionMember1Type.Html;

        Assert.NotNull(model.Channels);
        Assert.Equal(expectedChannels.Count, model.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], model.Channels[i]);
        }
        Assert.Equal(expectedIf, model.If);
        Assert.Equal(expectedLoop, model.Loop);
        Assert.Equal(expectedRef, model.Ref);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnionMember7
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = UnionMember7IntersectionMember1Type.Html,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember7>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnionMember7
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = UnionMember7IntersectionMember1Type.Html,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember7>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedChannels = ["string"];
        string expectedIf = "if";
        string expectedLoop = "loop";
        string expectedRef = "ref";
        ApiEnum<string, UnionMember7IntersectionMember1Type> expectedType =
            UnionMember7IntersectionMember1Type.Html;

        Assert.NotNull(deserialized.Channels);
        Assert.Equal(expectedChannels.Count, deserialized.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], deserialized.Channels[i]);
        }
        Assert.Equal(expectedIf, deserialized.If);
        Assert.Equal(expectedLoop, deserialized.Loop);
        Assert.Equal(expectedRef, deserialized.Ref);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnionMember7
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = UnionMember7IntersectionMember1Type.Html,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnionMember7
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UnionMember7
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UnionMember7
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UnionMember7
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnionMember7 { Type = UnionMember7IntersectionMember1Type.Html };

        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.If);
        Assert.False(model.RawData.ContainsKey("if"));
        Assert.Null(model.Loop);
        Assert.False(model.RawData.ContainsKey("loop"));
        Assert.Null(model.Ref);
        Assert.False(model.RawData.ContainsKey("ref"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new UnionMember7 { Type = UnionMember7IntersectionMember1Type.Html };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new UnionMember7
        {
            Type = UnionMember7IntersectionMember1Type.Html,

            Channels = null,
            If = null,
            Loop = null,
            Ref = null,
        };

        Assert.Null(model.Channels);
        Assert.True(model.RawData.ContainsKey("channels"));
        Assert.Null(model.If);
        Assert.True(model.RawData.ContainsKey("if"));
        Assert.Null(model.Loop);
        Assert.True(model.RawData.ContainsKey("loop"));
        Assert.Null(model.Ref);
        Assert.True(model.RawData.ContainsKey("ref"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UnionMember7
        {
            Type = UnionMember7IntersectionMember1Type.Html,

            Channels = null,
            If = null,
            Loop = null,
            Ref = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnionMember7
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = UnionMember7IntersectionMember1Type.Html,
        };

        UnionMember7 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnionMember7IntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnionMember7IntersectionMember1
        {
            Type = UnionMember7IntersectionMember1Type.Html,
        };

        ApiEnum<string, UnionMember7IntersectionMember1Type> expectedType =
            UnionMember7IntersectionMember1Type.Html;

        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnionMember7IntersectionMember1
        {
            Type = UnionMember7IntersectionMember1Type.Html,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember7IntersectionMember1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnionMember7IntersectionMember1
        {
            Type = UnionMember7IntersectionMember1Type.Html,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember7IntersectionMember1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, UnionMember7IntersectionMember1Type> expectedType =
            UnionMember7IntersectionMember1Type.Html;

        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnionMember7IntersectionMember1
        {
            Type = UnionMember7IntersectionMember1Type.Html,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnionMember7IntersectionMember1 { };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UnionMember7IntersectionMember1 { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UnionMember7IntersectionMember1
        {
            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UnionMember7IntersectionMember1
        {
            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnionMember7IntersectionMember1
        {
            Type = UnionMember7IntersectionMember1Type.Html,
        };

        UnionMember7IntersectionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnionMember7IntersectionMember1TypeTest : TestBase
{
    [Theory]
    [InlineData(UnionMember7IntersectionMember1Type.Html)]
    public void Validation_Works(UnionMember7IntersectionMember1Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionMember7IntersectionMember1Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, UnionMember7IntersectionMember1Type>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UnionMember7IntersectionMember1Type.Html)]
    public void SerializationRoundtrip_Works(UnionMember7IntersectionMember1Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionMember7IntersectionMember1Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UnionMember7IntersectionMember1Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, UnionMember7IntersectionMember1Type>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UnionMember7IntersectionMember1Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
