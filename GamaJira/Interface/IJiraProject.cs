using Atlassian.Jira;
using GamaJira.Models;
using System.Collections.Generic;

namespace GamaJira.Interface
{
    /// <summary>
    /// Interface of Gama Jira Project
    /// </summary>
    public interface IGJProject
    {
        GamaIssueResponse CreateIssue(GamaIssueRequest issue);
        GamaIssueResponse GetIssues(string issueId);
        GamaIssueResponse UpdateIssue(GamaIssueRequest issueConfig);
        List<JiraUser> SearchUser(string query);

    }
}
