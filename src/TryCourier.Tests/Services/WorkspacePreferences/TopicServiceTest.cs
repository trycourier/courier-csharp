using System.Threading.Tasks;
using TryCourier.Models.WorkspacePreferences.Topics;

namespace TryCourier.Tests.Services.WorkspacePreferences;

public class TopicServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var workspacePreferenceTopicGetResponse =
            await this.client.WorkspacePreferences.Topics.Create(
                "section_id",
                new() { DefaultStatus = DefaultStatus.OptedOut, Name = "Marketing" },
                TestContext.Current.CancellationToken
            );
        workspacePreferenceTopicGetResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var workspacePreferenceTopicGetResponse =
            await this.client.WorkspacePreferences.Topics.Retrieve(
                "topic_id",
                new() { SectionID = "section_id" },
                TestContext.Current.CancellationToken
            );
        workspacePreferenceTopicGetResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var workspacePreferenceTopicListResponse =
            await this.client.WorkspacePreferences.Topics.List(
                "section_id",
                new(),
                TestContext.Current.CancellationToken
            );
        workspacePreferenceTopicListResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Archive_Works()
    {
        await this.client.WorkspacePreferences.Topics.Archive(
            "topic_id",
            new() { SectionID = "section_id" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Replace_Works()
    {
        var workspacePreferenceTopicGetResponse =
            await this.client.WorkspacePreferences.Topics.Replace(
                "topic_id",
                new()
                {
                    SectionID = "section_id",
                    DefaultStatus = TopicReplaceParamsDefaultStatus.OptedOut,
                    Name = "name",
                },
                TestContext.Current.CancellationToken
            );
        workspacePreferenceTopicGetResponse.Validate();
    }
}
