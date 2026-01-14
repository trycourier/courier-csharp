using System.Text.Json;
using Courier.Core;
using Courier.Models;

namespace Courier.Tests.Models;

public class PagingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Paging { More = true, Cursor = "cursor" };

        bool expectedMore = true;
        string expectedCursor = "cursor";

        Assert.Equal(expectedMore, model.More);
        Assert.Equal(expectedCursor, model.Cursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Paging { More = true, Cursor = "cursor" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Paging>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Paging { More = true, Cursor = "cursor" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Paging>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        bool expectedMore = true;
        string expectedCursor = "cursor";

        Assert.Equal(expectedMore, deserialized.More);
        Assert.Equal(expectedCursor, deserialized.Cursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Paging { More = true, Cursor = "cursor" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Paging { More = true };

        Assert.Null(model.Cursor);
        Assert.False(model.RawData.ContainsKey("cursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Paging { More = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Paging
        {
            More = true,

            Cursor = null,
        };

        Assert.Null(model.Cursor);
        Assert.True(model.RawData.ContainsKey("cursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Paging
        {
            More = true,

            Cursor = null,
        };

        model.Validate();
    }
}
