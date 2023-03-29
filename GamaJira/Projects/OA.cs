using Atlassian.Jira;
using GamaJira.Constant;
using GamaJira.Interfaces;
using GamaJira.Models;
using GamaJira.Utilities.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamaJira.Projects
{
    public class OA : JiraRestClient, IGJProject
    {
        public OA(string jiraUrl, GJProject config) : base(jiraUrl, config) { }
        public IssueBuilder CreateUserStory() => CreateIssue(JiraIssueType.UserStory);
    }
}
