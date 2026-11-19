using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Feedback;

namespace TryCourier.Tests.Models.Feedback;

public class FeedbackCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FeedbackCreateResponse { FeedbackID = "feedback_id" };

        string expectedFeedbackID = "feedback_id";

        Assert.Equal(expectedFeedbackID, model.FeedbackID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FeedbackCreateResponse { FeedbackID = "feedback_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeedbackCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FeedbackCreateResponse { FeedbackID = "feedback_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeedbackCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFeedbackID = "feedback_id";

        Assert.Equal(expectedFeedbackID, deserialized.FeedbackID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FeedbackCreateResponse { FeedbackID = "feedback_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FeedbackCreateResponse { FeedbackID = "feedback_id" };

        FeedbackCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
