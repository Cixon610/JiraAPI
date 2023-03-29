﻿using Atlassian.Jira;
using GamaJira.Constant;
using GamaJira.Interfaces;
using GamaJira.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace GamaJira.Projects
{
    public class RyanTask : JiraRestClient, IGJProject
    {
        public RyanTask(string jiraUrl, GJProject config) : base(jiraUrl, config) { }

        public GamaIssueResponse CreateUserStory(GamaIssueRequest issueRequest)
            => CreateIssue(issueRequest, "UserStory");

        public GamaIssueResponse CreateUserTask(GamaIssueRequest issueRequest)
            => CreateIssue(issueRequest, "Task");

        public GamaIssueResponse UpdateIssue(GamaIssueRequest issueConfig, string IssueName)
        {
            throw new NotImplementedException();
        }
    }
}
