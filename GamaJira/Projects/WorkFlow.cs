using GamaJira.Interface;
using GamaJira.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamaJira.Projects
{
    public class WorkFlow : JiraRestClient, IJiraProject
    {
        public WorkFlow(string jiraUrl, JiraProjectConfig config) : base(jiraUrl, config)
        {

        }
        public void CreateIssue(string summary, string description)
        {
            throw new NotImplementedException();
        }

        public void GetIssues(string issueId)
        {
            throw new NotImplementedException();
        }
    }
}
