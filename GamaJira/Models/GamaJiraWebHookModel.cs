using Atlassian.Jira;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamaJira.Models
{

    /// <summary>
    /// WebHook: Web 要求內文使用議題資料(Automation格式)
    /// </summary>
    public class GamaJiraWebHookModel
    {
        public GamaJiraWebHookModel() { }

        public GamaJiraWebHookModel(string hookJson, GamaJiraConfig JsonConfig)
        {
            if (string.IsNullOrEmpty(hookJson))
                throw new NullReferenceException("HookJson is null");

            _ = JsonConfig
                ?? throw new NullReferenceException("GamaJiraConfig is null");

            var jobj = JObject.Parse(hookJson)
                ?? throw new NullReferenceException("Hook parameter is null");

            IssueID = jobj["id"].Value<string>();
            ProjectID = jobj["fields"]["project"]["id"].Value<string>();
            IssueTypeID = jobj["fields"]["issuetype"]["id"].Value<string>();
            StatusName = jobj["fields"]["status"]["name"].Value<string>();

            var assignee = jobj["fields"]["assignee"];
            if (assignee != null)
            {
                AccountId = assignee["accountId"].Value<string>();
                EmailAddress = assignee["emailAddress"].Value<string>();
                DisplayName = assignee["displayName"].Value<string>();
            }

            var issueType = JsonConfig.Projects.FirstOrDefault(x => x.ID == ProjectID)
                ?.IssueTypes.FirstOrDefault(x => x.ID == IssueTypeID);
            if (issueType != null)
            {
                var fieldToken = jobj["fields"];
                CustomFields = new Dictionary<string, JToken>();
                foreach (var field in issueType.CustomFieldIDs)
                {
                    var value = fieldToken[field.Value];
                    if (value != null)
                        CustomFields.Add(field.Key, value);
                }
            }
        }

        public string IssueID { get; set; }
        public string IssueTypeID { get; set; }
        public string ProjectID { get; set; }
        public string AccountId { get; set; }
        public string EmailAddress { get; set; }
        public string DisplayName { get; set; }
        public string StatusName { get; set; }
        public Dictionary<string, JToken> CustomFields { get; set; }

        #region CustomFields global parameters
        // 電子流程 ID
        public string WorkFlowID => CustomFields.FirstOrDefault(x => x.Key == "WorkFlowID").Value?.ToString();
        // 預計開始時間
        public string EstimatedStartTime => CustomFields.FirstOrDefault(x => x.Key == "EstimatedStartTime").Value?.ToString();
        // 預計結束時間
        public string EstimatedEndTime => CustomFields.FirstOrDefault(x => x.Key == "EstimatedEndTime").Value?.ToString();
        // QA 人員
        public string QA => CustomFields.FirstOrDefault(x => x.Key == "QA").Value?.ToString();
        // 上版人員
        public string ReleasePersonnel => CustomFields.FirstOrDefault(x => x.Key == "ReleasePersonnel").Value?.ToString();
        // 專案分類
        public string ProjectType => CustomFields.FirstOrDefault(x => x.Key == "ProjectType").Value?.ToString();
        // 專案重要性
        public string ProjectPriority => CustomFields.FirstOrDefault(x => x.Key == "ProjectPriority").Value?.ToString();
        // 需求申請者
        public string DemandApplicant => CustomFields.FirstOrDefault(x => x.Key == "DemandApplicant").Value?.ToString();
        // IT 備註
        public string ITMemo => CustomFields.FirstOrDefault(x => x.Key == "ITMemo").Value?.ToString();
        #endregion
    }
}
