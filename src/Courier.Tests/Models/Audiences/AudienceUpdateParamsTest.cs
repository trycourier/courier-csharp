using Courier.Models.Audiences;

namespace Courier.Tests.Models.Audiences;

public class AudienceUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AudienceUpdateParams
        {
            AudienceID = "audience_id",
            Description = "description",
            Filter = new SingleFilterConfig()
            {
                Operator = SingleFilterConfigOperator.EndsWith,
                Path = "path",
                Value = "value",
            },
            Name = "name",
        };

        string expectedAudienceID = "audience_id";
        string expectedDescription = "description";
        Filter expectedFilter = new SingleFilterConfig()
        {
            Operator = SingleFilterConfigOperator.EndsWith,
            Path = "path",
            Value = "value",
        };
        string expectedName = "name";

        Assert.Equal(expectedAudienceID, parameters.AudienceID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedFilter, parameters.Filter);
        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AudienceUpdateParams { AudienceID = "audience_id" };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Filter);
        Assert.False(parameters.RawBodyData.ContainsKey("filter"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new AudienceUpdateParams
        {
            AudienceID = "audience_id",

            Description = null,
            Filter = null,
            Name = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Filter);
        Assert.False(parameters.RawBodyData.ContainsKey("filter"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }
}
