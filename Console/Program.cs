using Atlassian.Jira;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Get Issue
            //var issues = jira.Issues.Queryable
            //    .Where(x => x.Project == "Ryan Task").ToList();
            //var json = JsonConvert.SerializeObject(issues,Formatting.Indented,new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore});
            #endregion
            #region Create Issue
            //var issue = jira.CreateIssue("RYT");
            //issue.Type = "Bug";
            //issue.Summary = "Issue Summary";

            //issue.SaveChanges();
            #endregion
        }
    }
}
