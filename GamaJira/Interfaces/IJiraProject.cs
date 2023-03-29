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
        GamaIssue GetIssues(string issueId);
        //GamaIssue UpdateIssue(GamaIssueRequest issueConfig, string IssueName);
        List<JiraUser> SearchUser(string query);

    }
}
