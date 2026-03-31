using System.Text.Json;
using Courier.Core;
using Courier.Models.RoutingStrategies;

namespace Courier.Tests.Models.RoutingStrategies;

public class RoutingStrategyMutationResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RoutingStrategyMutationResponse { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RoutingStrategyMutationResponse { ID = "id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RoutingStrategyMutationResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RoutingStrategyMutationResponse { ID = "id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RoutingStrategyMutationResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";

        Assert.Equal(expectedID, deserialized.ID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RoutingStrategyMutationResponse { ID = "id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RoutingStrategyMutationResponse { ID = "id" };

        RoutingStrategyMutationResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
