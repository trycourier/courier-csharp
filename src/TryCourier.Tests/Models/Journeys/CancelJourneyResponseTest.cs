using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Journeys;

namespace TryCourier.Tests.Models.Journeys;

public class CancelJourneyResponseTest : TestBase
{
    [Fact]
    public void TokenBranchValidationWorks()
    {
        CancelJourneyResponse value = new TokenBranch("cancelation_token");
        value.Validate();
    }

    [Fact]
    public void RunIDBranchValidationWorks()
    {
        CancelJourneyResponse value = new RunIDBranch() { RunID = "run_id", Status = "status" };
        value.Validate();
    }

    [Fact]
    public void TokenBranchSerializationRoundtripWorks()
    {
        CancelJourneyResponse value = new TokenBranch("cancelation_token");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CancelJourneyResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RunIDBranchSerializationRoundtripWorks()
    {
        CancelJourneyResponse value = new RunIDBranch() { RunID = "run_id", Status = "status" };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CancelJourneyResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TokenBranchTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TokenBranch { CancelationToken = "cancelation_token" };

        string expectedCancelationToken = "cancelation_token";

        Assert.Equal(expectedCancelationToken, model.CancelationToken);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TokenBranch { CancelationToken = "cancelation_token" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TokenBranch>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TokenBranch { CancelationToken = "cancelation_token" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TokenBranch>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCancelationToken = "cancelation_token";

        Assert.Equal(expectedCancelationToken, deserialized.CancelationToken);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TokenBranch { CancelationToken = "cancelation_token" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TokenBranch { CancelationToken = "cancelation_token" };

        TokenBranch copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RunIDBranchTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RunIDBranch { RunID = "run_id", Status = "status" };

        string expectedRunID = "run_id";
        string expectedStatus = "status";

        Assert.Equal(expectedRunID, model.RunID);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RunIDBranch { RunID = "run_id", Status = "status" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RunIDBranch>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RunIDBranch { RunID = "run_id", Status = "status" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RunIDBranch>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedRunID = "run_id";
        string expectedStatus = "status";

        Assert.Equal(expectedRunID, deserialized.RunID);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RunIDBranch { RunID = "run_id", Status = "status" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RunIDBranch { RunID = "run_id", Status = "status" };

        RunIDBranch copied = new(model);

        Assert.Equal(model, copied);
    }
}
