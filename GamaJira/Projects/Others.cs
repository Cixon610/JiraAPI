using Atlassian.Jira;
using GamaJira.Interfaces;
using GamaJira.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamaJira.Projects
{
    public class Others : JiraRestClient, IGJProject
    {
        public Others(string jiraUrl, GJProject config) : base(jiraUrl, config) { }
        public GamaIssueResponse CreateUserStory(GamaIssueRequest issueRequest)
            => CreateIssue(issueRequest, "UserStory");

        public GamaIssueResponse UpdateIssue(GamaIssueRequest issueConfig, string IssueName)
        {
            throw new NotImplementedException();
        }
    }
}
