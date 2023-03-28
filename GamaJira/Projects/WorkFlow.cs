using Atlassian.Jira;
using GamaJira.Interface;
using GamaJira.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamaJira.Projects
{
    public class WorkFlow : JiraRestClient, IGJProject
    {
        public WorkFlow(string jiraUrl, GJProject config) : base(jiraUrl, config) { }
    }
}
