using System.Collections.Generic;
using Courier.Models.Brands;

namespace Courier.Tests.Models.Brands;

public class BrandSnippetsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrandSnippets { Items = [new() { Name = "name", Value = "value" }] };

        List<BrandSnippet> expectedItems = [new() { Name = "name", Value = "value" }];

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
    }
}
