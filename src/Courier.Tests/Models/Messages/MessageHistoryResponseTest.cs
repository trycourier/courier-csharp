using System.Collections.Generic;
using System.Text.Json;
using Courier.Models.Messages;

namespace Courier.Tests.Models.Messages;

public class MessageHistoryResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageHistoryResponse
        {
            Results =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
        };

        List<Dictionary<string, JsonElement>> expectedResults =
        [
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        ];

        Assert.Equal(expectedResults.Count, model.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i].Count, model.Results[i].Count);
            foreach (var item in expectedResults[i])
            {
                Assert.True(model.Results[i].TryGetValue(item.Key, out var value));

                Assert.True(JsonElement.DeepEquals(value, model.Results[i][item.Key]));
            }
        }
    }
}
