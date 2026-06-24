using System.Threading.Tasks;
using TryCourier.Models.PreferenceSections.Topics;

namespace TryCourier.Tests.Services.PreferenceSections;

public class TopicServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var preferenceTopicGetResponse = await this.client.PreferenceSections.Topics.Create(
            "section_id",
            new() { DefaultStatus = DefaultStatus.OptedOut, Name = "Marketing" },
            TestContext.Current.CancellationToken
        );
        preferenceTopicGetResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var preferenceTopicGetResponse = await this.client.PreferenceSections.Topics.Retrieve(
            "topic_id",
            new() { SectionID = "section_id" },
            TestContext.Current.CancellationToken
        );
        preferenceTopicGetResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var preferenceTopicListResponse = await this.client.PreferenceSections.Topics.List(
            "section_id",
            new(),
            TestContext.Current.CancellationToken
        );
        preferenceTopicListResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Archive_Works()
    {
        await this.client.PreferenceSections.Topics.Archive(
            "topic_id",
            new() { SectionID = "section_id" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Replace_Works()
    {
        var preferenceTopicGetResponse = await this.client.PreferenceSections.Topics.Replace(
            "topic_id",
            new()
            {
                SectionID = "section_id",
                DefaultStatus = TopicReplaceParamsDefaultStatus.OptedOut,
                Name = "name",
            },
            TestContext.Current.CancellationToken
        );
        preferenceTopicGetResponse.Validate();
    }
}
