using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Previews;

namespace TryCourier.Tests.Models.Previews;

public class PreviewDeviceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PreviewDevice
        {
            ID = "pvd_2tecf6d6pybbvvnkdr0hwdpaxf",
            App = "outlook_com",
            Category = Category.Webmail,
            Name = "Outlook.com (Firefox, Windows 10, dark mode)",
            Os = "windows",
            OsVersion = "10",
            Platform = "firefox",
            PlatformVersion = "15_pro_max",
            Theme = Theme.Light,
        };

        string expectedID = "pvd_2tecf6d6pybbvvnkdr0hwdpaxf";
        string expectedApp = "outlook_com";
        ApiEnum<string, Category> expectedCategory = Category.Webmail;
        string expectedName = "Outlook.com (Firefox, Windows 10, dark mode)";
        string expectedOs = "windows";
        string expectedOsVersion = "10";
        string expectedPlatform = "firefox";
        string expectedPlatformVersion = "15_pro_max";
        ApiEnum<string, Theme> expectedTheme = Theme.Light;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedApp, model.App);
        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedOs, model.Os);
        Assert.Equal(expectedOsVersion, model.OsVersion);
        Assert.Equal(expectedPlatform, model.Platform);
        Assert.Equal(expectedPlatformVersion, model.PlatformVersion);
        Assert.Equal(expectedTheme, model.Theme);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PreviewDevice
        {
            ID = "pvd_2tecf6d6pybbvvnkdr0hwdpaxf",
            App = "outlook_com",
            Category = Category.Webmail,
            Name = "Outlook.com (Firefox, Windows 10, dark mode)",
            Os = "windows",
            OsVersion = "10",
            Platform = "firefox",
            PlatformVersion = "15_pro_max",
            Theme = Theme.Light,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreviewDevice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PreviewDevice
        {
            ID = "pvd_2tecf6d6pybbvvnkdr0hwdpaxf",
            App = "outlook_com",
            Category = Category.Webmail,
            Name = "Outlook.com (Firefox, Windows 10, dark mode)",
            Os = "windows",
            OsVersion = "10",
            Platform = "firefox",
            PlatformVersion = "15_pro_max",
            Theme = Theme.Light,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreviewDevice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "pvd_2tecf6d6pybbvvnkdr0hwdpaxf";
        string expectedApp = "outlook_com";
        ApiEnum<string, Category> expectedCategory = Category.Webmail;
        string expectedName = "Outlook.com (Firefox, Windows 10, dark mode)";
        string expectedOs = "windows";
        string expectedOsVersion = "10";
        string expectedPlatform = "firefox";
        string expectedPlatformVersion = "15_pro_max";
        ApiEnum<string, Theme> expectedTheme = Theme.Light;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedApp, deserialized.App);
        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedOs, deserialized.Os);
        Assert.Equal(expectedOsVersion, deserialized.OsVersion);
        Assert.Equal(expectedPlatform, deserialized.Platform);
        Assert.Equal(expectedPlatformVersion, deserialized.PlatformVersion);
        Assert.Equal(expectedTheme, deserialized.Theme);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PreviewDevice
        {
            ID = "pvd_2tecf6d6pybbvvnkdr0hwdpaxf",
            App = "outlook_com",
            Category = Category.Webmail,
            Name = "Outlook.com (Firefox, Windows 10, dark mode)",
            Os = "windows",
            OsVersion = "10",
            Platform = "firefox",
            PlatformVersion = "15_pro_max",
            Theme = Theme.Light,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PreviewDevice
        {
            ID = "pvd_2tecf6d6pybbvvnkdr0hwdpaxf",
            App = "outlook_com",
            Category = Category.Webmail,
            Name = "Outlook.com (Firefox, Windows 10, dark mode)",
            Os = "windows",
            OsVersion = "10",
            Platform = "firefox",
            PlatformVersion = "15_pro_max",
            Theme = Theme.Light,
        };

        PreviewDevice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CategoryTest : TestBase
{
    [Theory]
    [InlineData(Category.Webmail)]
    [InlineData(Category.Mobile)]
    [InlineData(Category.Desktop)]
    public void Validation_Works(Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Category> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Category.Webmail)]
    [InlineData(Category.Mobile)]
    [InlineData(Category.Desktop)]
    public void SerializationRoundtrip_Works(Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Category> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ThemeTest : TestBase
{
    [Theory]
    [InlineData(Theme.Light)]
    [InlineData(Theme.Dark)]
    public void Validation_Works(Theme rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Theme> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Theme>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Theme.Light)]
    [InlineData(Theme.Dark)]
    public void SerializationRoundtrip_Works(Theme rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Theme> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Theme>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Theme>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Theme>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
