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

            //var user = jira.SearchUser("g-ryanchang@gamania.com");

            var issue = jiraProject.CreateUserStory()
                .SetCustomFields(new Dictionary<string, string> {
                    {"WorkFlowID", "1234"},
                    {"EstimatedStartTime", "2023-03-29"},
                    {"EstimatedEndTime", "2023-03-30"},
                    {"ProjectType", "電子流程"},
                    {"ProjectPriority", "VIP"},
                    {"ITMemo", "MemoMemoMemoMemoMemoMemoMemoMemoMemoMemoMemoMemoMemoMemoMemoMemoMemoMemoMemoMemo"},
                })
                .SetDescription("Description")
                .SetPriority(JiraIssuePriority.Highest)
                .SetSummary("TestSummary")
                .Build();

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
