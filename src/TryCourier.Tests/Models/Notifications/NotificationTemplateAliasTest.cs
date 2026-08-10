using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Notifications;

namespace TryCourier.Tests.Models.Notifications;

public class NotificationTemplateAliasTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        NotificationTemplateAlias value = "string";
        value.Validate();
    }

    [Fact]
    public void StringsValidationWorks()
    {
        NotificationTemplateAlias value = new(["string"]);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        NotificationTemplateAlias value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotificationTemplateAlias>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringsSerializationRoundtripWorks()
    {
        NotificationTemplateAlias value = new(["string"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotificationTemplateAlias>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
