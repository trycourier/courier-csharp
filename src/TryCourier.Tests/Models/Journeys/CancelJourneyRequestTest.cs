using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Journeys;

namespace TryCourier.Tests.Models.Journeys;

public class CancelJourneyRequestTest : TestBase
{
    [Fact]
    public void ByCancelationTokenValidationWorks()
    {
        CancelJourneyRequest value = new ByCancelationToken("x");
        value.Validate();
    }

    [Fact]
    public void ByRunIDValidationWorks()
    {
        CancelJourneyRequest value = new ByRunID("x");
        value.Validate();
    }

    [Fact]
    public void ByCancelationTokenSerializationRoundtripWorks()
    {
        CancelJourneyRequest value = new ByCancelationToken("x");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CancelJourneyRequest>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ByRunIDSerializationRoundtripWorks()
    {
        CancelJourneyRequest value = new ByRunID("x");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CancelJourneyRequest>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ByCancelationTokenTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ByCancelationToken { CancelationToken = "x" };

        string expectedCancelationToken = "x";

        Assert.Equal(expectedCancelationToken, model.CancelationToken);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ByCancelationToken { CancelationToken = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ByCancelationToken>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ByCancelationToken { CancelationToken = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ByCancelationToken>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCancelationToken = "x";

        Assert.Equal(expectedCancelationToken, deserialized.CancelationToken);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ByCancelationToken { CancelationToken = "x" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ByCancelationToken { CancelationToken = "x" };

        ByCancelationToken copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ByRunIDTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ByRunID { RunID = "x" };

        string expectedRunID = "x";

        Assert.Equal(expectedRunID, model.RunID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ByRunID { RunID = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ByRunID>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ByRunID { RunID = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ByRunID>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedRunID = "x";

        Assert.Equal(expectedRunID, deserialized.RunID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ByRunID { RunID = "x" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ByRunID { RunID = "x" };

        ByRunID copied = new(model);

        Assert.Equal(model, copied);
    }
}
