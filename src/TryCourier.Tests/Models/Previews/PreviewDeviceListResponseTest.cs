using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Previews;

namespace TryCourier.Tests.Models.Previews;

public class PreviewDeviceListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PreviewDeviceListResponse
        {
            Results =
            [
                new()
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
                },
            ],
        };

        List<PreviewDevice> expectedResults =
        [
            new()
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
            },
        ];

        Assert.Equal(expectedResults.Count, model.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], model.Results[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PreviewDeviceListResponse
        {
            Results =
            [
                new()
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
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreviewDeviceListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PreviewDeviceListResponse
        {
            Results =
            [
                new()
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
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreviewDeviceListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<PreviewDevice> expectedResults =
        [
            new()
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
            },
        ];

        Assert.Equal(expectedResults.Count, deserialized.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], deserialized.Results[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PreviewDeviceListResponse
        {
            Results =
            [
                new()
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
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PreviewDeviceListResponse
        {
            Results =
            [
                new()
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
                },
            ],
        };

        PreviewDeviceListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
