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
    public class GamaCert : JiraRestClient, IGJProject
    {
        public GamaCert(string jiraUrl, GJProject config) : base(jiraUrl, config) { }
    }
}
