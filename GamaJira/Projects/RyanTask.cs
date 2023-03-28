using Atlassian.Jira;
using GamaJira.Enums;
using GamaJira.Interface;
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
        
        public new GamaIssueResponse CreateIssue(GamaIssueRequest issue) => 
            base.CreateIssue(new GamaIssueRequest
            {
                Summary = "Summary",
                Description = "Description",
                Assignee = "g-ryanchang@gamania.com",
                Priority = JiraIssuePriority.High,
                Project = ProjectName,
                //Reporter = "g-ryanchang@gamania.com",
                //Status = "Status",
                Type = "Task",
                //AttachmentsPath = new,
                //CustomFields = CustomFields,
                //Labels = labels
            });
    }
}
