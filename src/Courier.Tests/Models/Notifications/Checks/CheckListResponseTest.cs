using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models.Notifications;
using Courier.Models.Notifications.Checks;

namespace Courier.Tests.Models.Notifications.Checks;

public class CheckListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckListResponse
        {
            Checks =
            [
                new()
                {
                    ID = "id",
                    Status = Status.Resolved,
                    Type = Type.Custom,
                    Updated = 0,
                },
            ],
        };

        List<Check> expectedChecks =
        [
            new()
            {
                ID = "id",
                Status = Status.Resolved,
                Type = Type.Custom,
                Updated = 0,
            },
        ];

        Assert.Equal(expectedChecks.Count, model.Checks.Count);
        for (int i = 0; i < expectedChecks.Count; i++)
        {
            Assert.Equal(expectedChecks[i], model.Checks[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckListResponse
        {
            Checks =
            [
                new()
                {
                    ID = "id",
                    Status = Status.Resolved,
                    Type = Type.Custom,
                    Updated = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckListResponse
        {
            Checks =
            [
                new()
                {
                    ID = "id",
                    Status = Status.Resolved,
                    Type = Type.Custom,
                    Updated = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Check> expectedChecks =
        [
            new()
            {
                ID = "id",
                Status = Status.Resolved,
                Type = Type.Custom,
                Updated = 0,
            },
        ];

        Assert.Equal(expectedChecks.Count, deserialized.Checks.Count);
        for (int i = 0; i < expectedChecks.Count; i++)
        {
            Assert.Equal(expectedChecks[i], deserialized.Checks[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckListResponse
        {
            Checks =
            [
                new()
                {
                    ID = "id",
                    Status = Status.Resolved,
                    Type = Type.Custom,
                    Updated = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckListResponse
        {
            Checks =
            [
                new()
                {
                    ID = "id",
                    Status = Status.Resolved,
                    Type = Type.Custom,
                    Updated = 0,
                },
            ],
        };

        CheckListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
