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

            var jiraFactory = new JiraProjectFactory(@".\SystemConfigs\JiraProjectConfig.json");
            var jiraProject = jiraFactory.CreateJiraProject(nameof(SA35));
            //var user = jiraProject.SearchUser("g-ryanchang@gamania.com");
            //var userE = jiraProject.SearchUser("g-ryanchang");
            //var userC = jiraProject.SearchUser("張景翔");

            var issue = jiraProject.CreateUserStory()
                .SetAttachmentsPath(new List<string> {
                    ".\\Attaches\\Giwawa.jpg"
                })
                .SetCustomFields(new Dictionary<string, string> {
                    {"WorkFlowID", "1234"},
                    {"EstimatedStartTime", "2023-03-29"},
                    {"EstimatedEndTime", "2023-03-30"},
                    {"ProjectType", "電子流程"},
                    {"ProjectPriority", "VIP"},
                    {"ITMemo", "MemoMemoMemoMemoMemoMemoMemoMemoMemoMemoMemoMemoMemoMemoMemoMemoMemoMemoMemoMemo"},
                })
                .SetAssignee("634f693bfe5ff3752357f8ab")
                .SetDescription("Description")
                .SetPriority(JiraIssuePriority.Highest)
                .SetSummary("TestSummary")
                .Build();

            //jiraProject.SearchUser("");

            //var json = JsonConvert.SerializeObject(issue, Formatting.Indented);
            //Console.WriteLine(json);
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
