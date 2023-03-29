using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamaJira.Extension;
using Atlassian.Jira;
using GamaJira.Models;

namespace GamaJira
{
    public class JiraRestClient
    {
        private Jira Jira { get; set; }
        protected string ProjectName { get; set; }
        protected string ProjectTag { get; set; }
        protected List<GJIssueType> IssueTypes { get; set; }
        public JiraRestClient(string url, GJProject config)
        {
            //EnableUserPrivacyMode會禁止查詢User
            Jira = Jira.CreateRestClient(url, config.Auth.UserName, config.Auth.Password, 
                new JiraRestClientSettings() { EnableUserPrivacyMode  = true });
            ProjectName = config.Name;
            ProjectTag = config.Tag;
            IssueTypes = config.IssueTypes;
        }

        #region Public Function
        /// <summary>
        /// 專案客製化需屏蔽(new)後再呼叫base.CreateIssue
        /// </summary>
        /// <param name="issueConfig"></param>
        /// <returns></returns>
        public GamaIssueResponse CreateIssue(GamaIssueRequest issueConfig, string issueTypeName)
        {
            try
            {
                var issueType = IssueTypes.FirstOrDefault(x => x.Name == issueTypeName);
                var createIssue = Jira.CreateIssue(ProjectTag);
                createIssue = createIssue.MapFromGamaIssue(issueConfig, issueType);
                createIssue.SaveChanges();
                return new GamaIssueResponse(createIssue);
            }
            catch (Exception ex)
            {
                //TODO:Log
                throw;
            }
        }
        public GamaIssueResponse GetIssues(string issueTag)
        {
            try
            {
                var issue = Jira.Issues.GetIssueAsync(issueTag).Result;
                return new GamaIssueResponse(issue);
            }
            catch (Exception ex)
            {
                //TODO:Log
                throw;
            }
        }
        public GamaIssueResponse UpdateIssue(GamaIssueRequest issueConfig, GJIssueType issueType)
        {
            try
            {
                var issue = Jira.Issues.GetIssueAsync(issueConfig.Key.Value).Result;
                issue = issue.MapFromGamaIssue(issueConfig, issueType);
                issue.SaveChanges();
                return new GamaIssueResponse(issue);
            }
            catch (Exception ex)
            {
                //TODO:Log
                throw;
            }
        }

        public List<JiraUser> SearchUser(string query)
        {
            try
            {
                var users = Jira.Users.SearchAssignableUsersForProjectAsync(query, ProjectTag).Result;
                var userss = Jira.Users.SearchUsersAsync(query);
                return users.ToList();
            }
            catch (Exception ex)
            {
                //TODO:Log
                throw;
            }
        }
        #endregion
    }
}
