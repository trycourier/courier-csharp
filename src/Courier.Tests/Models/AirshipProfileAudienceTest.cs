using System.Text.Json;
using Courier.Core;
using Courier.Models;

namespace Courier.Tests.Models;

public class AirshipProfileAudienceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AirshipProfileAudience { NamedUser = "named_user" };

        string expectedNamedUser = "named_user";

        Assert.Equal(expectedNamedUser, model.NamedUser);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AirshipProfileAudience { NamedUser = "named_user" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AirshipProfileAudience>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AirshipProfileAudience { NamedUser = "named_user" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AirshipProfileAudience>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedNamedUser = "named_user";

        Assert.Equal(expectedNamedUser, deserialized.NamedUser);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AirshipProfileAudience { NamedUser = "named_user" };

        model.Validate();
    }
}
