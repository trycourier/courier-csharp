using System;
using TryCourier.Models.PreferenceSections;

namespace TryCourier.Tests.Models.PreferenceSections;

public class PreferenceSectionRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PreferenceSectionRetrieveParams { SectionID = "section_id" };

        string expectedSectionID = "section_id";

        Assert.Equal(expectedSectionID, parameters.SectionID);
    }

    [Fact]
    public void Url_Works()
    {
        PreferenceSectionRetrieveParams parameters = new() { SectionID = "section_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.courier.com/preferences/sections/section_id"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PreferenceSectionRetrieveParams { SectionID = "section_id" };

        PreferenceSectionRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
