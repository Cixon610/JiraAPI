using Atlassian.Jira;
using GamaJira.Models;
using System.Collections.Generic;

namespace GamaJira.Interfaces
{
    /// <summary>
    /// Interface of Gama Jira Project
    /// </summary>
    public interface IGJProject
    {
        GamaIssueResponse CreateUserStory(GamaIssueRequest issueRequest);
        GamaIssueResponse GetIssues(string issueId);
        GamaIssueResponse UpdateIssue(GamaIssueRequest issueConfig, string IssueName);
        List<JiraUser> SearchUser(string query);

    }
}
