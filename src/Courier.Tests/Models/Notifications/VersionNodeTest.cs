using System.Text.Json;
using Courier.Core;
using Courier.Models.Notifications;

namespace Courier.Tests.Models.Notifications;

public class VersionNodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VersionNode
        {
            Created = 0,
            Creator = "creator",
            Version = "version",
            HasChanges = true,
        };

        long expectedCreated = 0;
        string expectedCreator = "creator";
        string expectedVersion = "version";
        bool expectedHasChanges = true;

        Assert.Equal(expectedCreated, model.Created);
        Assert.Equal(expectedCreator, model.Creator);
        Assert.Equal(expectedVersion, model.Version);
        Assert.Equal(expectedHasChanges, model.HasChanges);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VersionNode
        {
            Created = 0,
            Creator = "creator",
            Version = "version",
            HasChanges = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VersionNode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VersionNode
        {
            Created = 0,
            Creator = "creator",
            Version = "version",
            HasChanges = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VersionNode>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCreated = 0;
        string expectedCreator = "creator";
        string expectedVersion = "version";
        bool expectedHasChanges = true;

        Assert.Equal(expectedCreated, deserialized.Created);
        Assert.Equal(expectedCreator, deserialized.Creator);
        Assert.Equal(expectedVersion, deserialized.Version);
        Assert.Equal(expectedHasChanges, deserialized.HasChanges);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VersionNode
        {
            Created = 0,
            Creator = "creator",
            Version = "version",
            HasChanges = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VersionNode
        {
            Created = 0,
            Creator = "creator",
            Version = "version",
        };

        Assert.Null(model.HasChanges);
        Assert.False(model.RawData.ContainsKey("has_changes"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VersionNode
        {
            Created = 0,
            Creator = "creator",
            Version = "version",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VersionNode
        {
            Created = 0,
            Creator = "creator",
            Version = "version",

            // Null should be interpreted as omitted for these properties
            HasChanges = null,
        };

        Assert.Null(model.HasChanges);
        Assert.False(model.RawData.ContainsKey("has_changes"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VersionNode
        {
            Created = 0,
            Creator = "creator",
            Version = "version",

            // Null should be interpreted as omitted for these properties
            HasChanges = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VersionNode
        {
            Created = 0,
            Creator = "creator",
            Version = "version",
            HasChanges = true,
        };

        VersionNode copied = new(model);

        Assert.Equal(model, copied);
    }
}
