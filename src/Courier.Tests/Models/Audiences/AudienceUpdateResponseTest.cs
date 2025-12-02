using Courier.Models.Audiences;

namespace Courier.Tests.Models.Audiences;

public class AudienceUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AudienceUpdateResponse
        {
            Audience = new()
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
            },
        };

        Audience expectedAudience = new()
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

        Assert.Equal(expectedAudience, model.Audience);
    }
}
