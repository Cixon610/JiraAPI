using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atlassian.Jira;
using GamaJira.Models;
using GamaJira.Utilities.Builder;
using GamaJira.Constant;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Resources;

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
        public IssueBuilder CreateIssue(JiraIssueType jIssueType)
        {
            try
            {
                var issueType = IssueTypes.FirstOrDefault(x => x.Name == jIssueType.ToString());
                return new IssueBuilder(Jira, ProjectTag, issueType).SetType(issueType.ID);
            }
            catch (Exception ex)
            {
                //TODO:Log
                throw;
            }
        }
        public GamaIssue GetIssues(string issueTag)
        {
            try
            {
                var issue = Jira.Issues.GetIssueAsync(issueTag).Result;
                return new GamaIssue(issue);
            }
            catch (Exception ex)
            {
                //TODO:Log
                throw;
            }
        }
        //public GamaIssue UpdateIssue(GamaIssueRequest issueConfig, GJIssueType issueType)
        //{
        //    try
        //    {
        //        var issue = Jira.Issues.GetIssueAsync(issueConfig.Key.Value).Result;
        //        issue.SaveChanges();
        //        return new GamaIssue(issue);
        //    }
        //    catch (Exception ex)
        //    {
        //        TODO:Log
        //        throw;
        //    }
        //}

        public List<JiraUser> SearchUser(string query)
        {
            try
            {
                var resourceSb = new StringBuilder($"rest/api/2/user/assignable/search", 200);
                resourceSb.Append($"?query={Uri.EscapeDataString(query)}&project={Uri.EscapeDataString(ProjectTag)}");
                resourceSb.Append($"&startAt=0&maxResults=50");
                return Jira.RestClient.ExecuteRequestAsync<IEnumerable<JiraUser>>(Method.GET, resourceSb.ToString(), null).Result.ToList();
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
