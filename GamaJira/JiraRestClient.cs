using Atlassian.Jira;
using GamaJira.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamaJira
{
    public class JiraRestClient
    {
        private Jira Jira { get; set; }
        protected string ProjectName { get; set; }
        protected string ProjectTag { get; set; }
        public JiraRestClient(string url, JiraProjectConfig config)
        {
            Jira = Jira.CreateRestClient(url, config.UserName, config.Password);
            ProjectName = config.Name;
            ProjectTag = config.Tag;
        }

        #region Public Function
        public Issue CreateIssueFields(Issue issueConfig)
        {
            try
            {
                var createIssue = Jira.CreateIssue(ProjectTag);
                MapIssue(createIssue, issueConfig);
                createIssue.SaveChanges();
                return createIssue;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Private Function
        private void MapIssue(Issue createIssue, Issue issueConfig)
        {
            createIssue.Type = issueConfig.Type;
            createIssue.Summary = issueConfig.Summary;
            createIssue.Assignee = issueConfig.Assignee;
        }
        //public GetProjectIssues()
        //{

        //}
        #endregion
    }
}
