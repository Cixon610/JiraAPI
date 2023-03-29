using Atlassian.Jira;
using GamaJira.Models;
using GamaJira.Utilities.Builder;
using System.Collections.Generic;

namespace GamaJira.Interfaces
{
    /// <summary>
    /// Interface of Gama Jira Project
    /// </summary>
    public interface IGJProject
    {
        IssueBuilder CreateUserStory();
        GamaIssueResponse GetIssues(string issueId);
        GamaIssueResponse UpdateIssue(GamaIssueRequest issueConfig, string IssueName);
        List<JiraUser> SearchUser(string query);

    }
}
