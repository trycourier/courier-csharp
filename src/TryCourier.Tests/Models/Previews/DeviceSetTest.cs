using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Previews;

namespace TryCourier.Tests.Models.Previews;

public class DeviceSetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeviceSet
        {
            ID = "id",
            CreatedAt = "created_at",
            DeviceIds = ["string"],
            Name = "name",
            UpdatedAt = "updated_at",
            ArchivedAt = "archived_at",
        };

        string expectedID = "id";
        string expectedCreatedAt = "created_at";
        List<string> expectedDeviceIds = ["string"];
        string expectedName = "name";
        string expectedUpdatedAt = "updated_at";
        string expectedArchivedAt = "archived_at";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDeviceIds.Count, model.DeviceIds.Count);
        for (int i = 0; i < expectedDeviceIds.Count; i++)
        {
            Assert.Equal(expectedDeviceIds[i], model.DeviceIds[i]);
        }
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedArchivedAt, model.ArchivedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeviceSet
        {
            ID = "id",
            CreatedAt = "created_at",
            DeviceIds = ["string"],
            Name = "name",
            UpdatedAt = "updated_at",
            ArchivedAt = "archived_at",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeviceSet>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeviceSet
        {
            ID = "id",
            CreatedAt = "created_at",
            DeviceIds = ["string"],
            Name = "name",
            UpdatedAt = "updated_at",
            ArchivedAt = "archived_at",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeviceSet>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedCreatedAt = "created_at";
        List<string> expectedDeviceIds = ["string"];
        string expectedName = "name";
        string expectedUpdatedAt = "updated_at";
        string expectedArchivedAt = "archived_at";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDeviceIds.Count, deserialized.DeviceIds.Count);
        for (int i = 0; i < expectedDeviceIds.Count; i++)
        {
            Assert.Equal(expectedDeviceIds[i], deserialized.DeviceIds[i]);
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedArchivedAt, deserialized.ArchivedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeviceSet
        {
            ID = "id",
            CreatedAt = "created_at",
            DeviceIds = ["string"],
            Name = "name",
            UpdatedAt = "updated_at",
            ArchivedAt = "archived_at",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DeviceSet
        {
            ID = "id",
            CreatedAt = "created_at",
            DeviceIds = ["string"],
            Name = "name",
            UpdatedAt = "updated_at",
        };

        Assert.Null(model.ArchivedAt);
        Assert.False(model.RawData.ContainsKey("archived_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new DeviceSet
        {
            ID = "id",
            CreatedAt = "created_at",
            DeviceIds = ["string"],
            Name = "name",
            UpdatedAt = "updated_at",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DeviceSet
        {
            ID = "id",
            CreatedAt = "created_at",
            DeviceIds = ["string"],
            Name = "name",
            UpdatedAt = "updated_at",

            // Null should be interpreted as omitted for these properties
            ArchivedAt = null,
        };

        Assert.Null(model.ArchivedAt);
        Assert.False(model.RawData.ContainsKey("archived_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DeviceSet
        {
            ID = "id",
            CreatedAt = "created_at",
            DeviceIds = ["string"],
            Name = "name",
            UpdatedAt = "updated_at",

            // Null should be interpreted as omitted for these properties
            ArchivedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeviceSet
        {
            ID = "id",
            CreatedAt = "created_at",
            DeviceIds = ["string"],
            Name = "name",
            UpdatedAt = "updated_at",
            ArchivedAt = "archived_at",
        };

        DeviceSet copied = new(model);

        Assert.Equal(model, copied);
    }
}
