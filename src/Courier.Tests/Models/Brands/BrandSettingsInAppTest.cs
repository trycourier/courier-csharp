using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Brands;

namespace Courier.Tests.Models.Brands;

public class BrandSettingsInAppTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrandSettingsInApp
        {
            Colors = new() { Primary = "primary", Secondary = "secondary" },
            Icons = new() { Bell = "bell", Message = "message" },
            WidgetBackground = new() { BottomColor = "bottomColor", TopColor = "topColor" },
            BorderRadius = "borderRadius",
            DisableMessageIcon = true,
            FontFamily = "fontFamily",
            Placement = Placement.Top,
        };

        BrandColors expectedColors = new() { Primary = "primary", Secondary = "secondary" };
        Icons expectedIcons = new() { Bell = "bell", Message = "message" };
        WidgetBackground expectedWidgetBackground = new()
        {
            BottomColor = "bottomColor",
            TopColor = "topColor",
        };
        string expectedBorderRadius = "borderRadius";
        bool expectedDisableMessageIcon = true;
        string expectedFontFamily = "fontFamily";
        ApiEnum<string, Placement> expectedPlacement = Placement.Top;

        Assert.Equal(expectedColors, model.Colors);
        Assert.Equal(expectedIcons, model.Icons);
        Assert.Equal(expectedWidgetBackground, model.WidgetBackground);
        Assert.Equal(expectedBorderRadius, model.BorderRadius);
        Assert.Equal(expectedDisableMessageIcon, model.DisableMessageIcon);
        Assert.Equal(expectedFontFamily, model.FontFamily);
        Assert.Equal(expectedPlacement, model.Placement);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BrandSettingsInApp
        {
            Colors = new() { Primary = "primary", Secondary = "secondary" },
            Icons = new() { Bell = "bell", Message = "message" },
            WidgetBackground = new() { BottomColor = "bottomColor", TopColor = "topColor" },
            BorderRadius = "borderRadius",
            DisableMessageIcon = true,
            FontFamily = "fontFamily",
            Placement = Placement.Top,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BrandSettingsInApp>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BrandSettingsInApp
        {
            Colors = new() { Primary = "primary", Secondary = "secondary" },
            Icons = new() { Bell = "bell", Message = "message" },
            WidgetBackground = new() { BottomColor = "bottomColor", TopColor = "topColor" },
            BorderRadius = "borderRadius",
            DisableMessageIcon = true,
            FontFamily = "fontFamily",
            Placement = Placement.Top,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BrandSettingsInApp>(element);
        Assert.NotNull(deserialized);

        BrandColors expectedColors = new() { Primary = "primary", Secondary = "secondary" };
        Icons expectedIcons = new() { Bell = "bell", Message = "message" };
        WidgetBackground expectedWidgetBackground = new()
        {
            BottomColor = "bottomColor",
            TopColor = "topColor",
        };
        string expectedBorderRadius = "borderRadius";
        bool expectedDisableMessageIcon = true;
        string expectedFontFamily = "fontFamily";
        ApiEnum<string, Placement> expectedPlacement = Placement.Top;

        Assert.Equal(expectedColors, deserialized.Colors);
        Assert.Equal(expectedIcons, deserialized.Icons);
        Assert.Equal(expectedWidgetBackground, deserialized.WidgetBackground);
        Assert.Equal(expectedBorderRadius, deserialized.BorderRadius);
        Assert.Equal(expectedDisableMessageIcon, deserialized.DisableMessageIcon);
        Assert.Equal(expectedFontFamily, deserialized.FontFamily);
        Assert.Equal(expectedPlacement, deserialized.Placement);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BrandSettingsInApp
        {
            Colors = new() { Primary = "primary", Secondary = "secondary" },
            Icons = new() { Bell = "bell", Message = "message" },
            WidgetBackground = new() { BottomColor = "bottomColor", TopColor = "topColor" },
            BorderRadius = "borderRadius",
            DisableMessageIcon = true,
            FontFamily = "fontFamily",
            Placement = Placement.Top,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BrandSettingsInApp
        {
            Colors = new() { Primary = "primary", Secondary = "secondary" },
            Icons = new() { Bell = "bell", Message = "message" },
            WidgetBackground = new() { BottomColor = "bottomColor", TopColor = "topColor" },
        };

        Assert.Null(model.BorderRadius);
        Assert.False(model.RawData.ContainsKey("borderRadius"));
        Assert.Null(model.DisableMessageIcon);
        Assert.False(model.RawData.ContainsKey("disableMessageIcon"));
        Assert.Null(model.FontFamily);
        Assert.False(model.RawData.ContainsKey("fontFamily"));
        Assert.Null(model.Placement);
        Assert.False(model.RawData.ContainsKey("placement"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BrandSettingsInApp
        {
            Colors = new() { Primary = "primary", Secondary = "secondary" },
            Icons = new() { Bell = "bell", Message = "message" },
            WidgetBackground = new() { BottomColor = "bottomColor", TopColor = "topColor" },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BrandSettingsInApp
        {
            Colors = new() { Primary = "primary", Secondary = "secondary" },
            Icons = new() { Bell = "bell", Message = "message" },
            WidgetBackground = new() { BottomColor = "bottomColor", TopColor = "topColor" },

            BorderRadius = null,
            DisableMessageIcon = null,
            FontFamily = null,
            Placement = null,
        };

        Assert.Null(model.BorderRadius);
        Assert.True(model.RawData.ContainsKey("borderRadius"));
        Assert.Null(model.DisableMessageIcon);
        Assert.True(model.RawData.ContainsKey("disableMessageIcon"));
        Assert.Null(model.FontFamily);
        Assert.True(model.RawData.ContainsKey("fontFamily"));
        Assert.Null(model.Placement);
        Assert.True(model.RawData.ContainsKey("placement"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BrandSettingsInApp
        {
            Colors = new() { Primary = "primary", Secondary = "secondary" },
            Icons = new() { Bell = "bell", Message = "message" },
            WidgetBackground = new() { BottomColor = "bottomColor", TopColor = "topColor" },

            BorderRadius = null,
            DisableMessageIcon = null,
            FontFamily = null,
            Placement = null,
        };

        model.Validate();
    }
}

public class PlacementTest : TestBase
{
    [Theory]
    [InlineData(Placement.Top)]
    [InlineData(Placement.Bottom)]
    [InlineData(Placement.Left)]
    [InlineData(Placement.Right)]
    public void Validation_Works(Placement rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Placement> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Placement>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Placement.Top)]
    [InlineData(Placement.Bottom)]
    [InlineData(Placement.Left)]
    [InlineData(Placement.Right)]
    public void SerializationRoundtrip_Works(Placement rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Placement> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Placement>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Placement>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Placement>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
