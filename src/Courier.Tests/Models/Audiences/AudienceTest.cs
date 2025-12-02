using Courier.Models.Audiences;

namespace Courier.Tests.Models.Audiences;

public class AudienceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Audience
        {
            ID = "id",
            CreatedAt = "created_at",
            Description = "description",
            Filter = new()
            {
                Operator = Operator.EndsWith,
                Path = "path",
                Value = "value",
            },
            Name = "name",
            UpdatedAt = "updated_at",
        };

        string expectedID = "id";
        string expectedCreatedAt = "created_at";
        string expectedDescription = "description";
        Filter expectedFilter = new()
        {
            Operator = Operator.EndsWith,
            Path = "path",
            Value = "value",
        };
        string expectedName = "name";
        string expectedUpdatedAt = "updated_at";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedFilter, model.Filter);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }
}
