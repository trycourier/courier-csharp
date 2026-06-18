using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Notifications;

namespace TryCourier.Tests.Models.Notifications;

public class NotificationContentMutationResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NotificationContentMutationResponse
        {
            ID = "id",
            Elements = [new() { ID = "id", Checksum = "checksum" }],
            State = NotificationTemplateState.Draft,
            Version = "version",
        };

        string expectedID = "id";
        List<NotificationContentMutationResponseElement> expectedElements =
        [
            new() { ID = "id", Checksum = "checksum" },
        ];
        ApiEnum<string, NotificationTemplateState> expectedState = NotificationTemplateState.Draft;
        string expectedVersion = "version";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedElements.Count, model.Elements.Count);
        for (int i = 0; i < expectedElements.Count; i++)
        {
            Assert.Equal(expectedElements[i], model.Elements[i]);
        }
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NotificationContentMutationResponse
        {
            ID = "id",
            Elements = [new() { ID = "id", Checksum = "checksum" }],
            State = NotificationTemplateState.Draft,
            Version = "version",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotificationContentMutationResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NotificationContentMutationResponse
        {
            ID = "id",
            Elements = [new() { ID = "id", Checksum = "checksum" }],
            State = NotificationTemplateState.Draft,
            Version = "version",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotificationContentMutationResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<NotificationContentMutationResponseElement> expectedElements =
        [
            new() { ID = "id", Checksum = "checksum" },
        ];
        ApiEnum<string, NotificationTemplateState> expectedState = NotificationTemplateState.Draft;
        string expectedVersion = "version";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedElements.Count, deserialized.Elements.Count);
        for (int i = 0; i < expectedElements.Count; i++)
        {
            Assert.Equal(expectedElements[i], deserialized.Elements[i]);
        }
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NotificationContentMutationResponse
        {
            ID = "id",
            Elements = [new() { ID = "id", Checksum = "checksum" }],
            State = NotificationTemplateState.Draft,
            Version = "version",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NotificationContentMutationResponse
        {
            ID = "id",
            Elements = [new() { ID = "id", Checksum = "checksum" }],
            State = NotificationTemplateState.Draft,
            Version = "version",
        };

        NotificationContentMutationResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NotificationContentMutationResponseElementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NotificationContentMutationResponseElement
        {
            ID = "id",
            Checksum = "checksum",
        };

        string expectedID = "id";
        string expectedChecksum = "checksum";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedChecksum, model.Checksum);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NotificationContentMutationResponseElement
        {
            ID = "id",
            Checksum = "checksum",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotificationContentMutationResponseElement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NotificationContentMutationResponseElement
        {
            ID = "id",
            Checksum = "checksum",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotificationContentMutationResponseElement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedChecksum = "checksum";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedChecksum, deserialized.Checksum);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NotificationContentMutationResponseElement
        {
            ID = "id",
            Checksum = "checksum",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NotificationContentMutationResponseElement
        {
            ID = "id",
            Checksum = "checksum",
        };

        NotificationContentMutationResponseElement copied = new(model);

        Assert.Equal(model, copied);
    }
}
