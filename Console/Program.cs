using Atlassian.Jira;
using GamaJira.Constant;
using GamaJira;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamaJira.Models;
using System.ComponentModel;
using GamaJira.Projects;

namespace JiraConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            //base.CreateIssue(new GamaIssueRequest
            //{
            //    Summary = "Summary",
            //    Description = "Description",
            //    Assignee = "g-ryanchang@gamania.com",
            //    Priority = JiraIssuePriority.High,
            //    Project = ProjectName,
            //    Type = "Task",
            //    //Reporter = "g-ryanchang@gamania.com",
            //    //Status = "Status",
            //    //AttachmentsPath = new,
            //    //CustomFields = CustomFields,
            //    //Labels = labels
            //});
            var settings = SysConfig.Instance.JiraProject.Projects
                .FirstOrDefault(x => x.ClassName == nameof(RyanTask));

            var jira = JiraProjectFactory.CreateJiraProject(SysConfig.Instance.JiraProject.Url, settings);

            //var user = jira.SearchUser("g-ryanchang@gamania.com");

            var issue = jira.CreateIssue(new GamaIssueRequest
            {
                Summary = "Summary",
                Description = "Description",
                Assignee = "g-ryanchang@gamania.com",
                Priority = JiraIssuePriority.High,
                Type = "Task",
                //Reporter = "g-ryanchang@gamania.com",
                //Status = "Status",
                //AttachmentsPath = new,
                //CustomFields = CustomFields,
                //Labels = labels
            });
            var json = JsonConvert.SerializeObject(issue, Formatting.Indented);
            Console.WriteLine(json);
            Console.ReadLine();
        }

        static void Test()
        {
            var properties = typeof(Issue).GetProperties();
            var obj = properties.Select(x => new { x.Name, x.PropertyType.FullName });
            var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
}
