using Atlassian.Jira;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamaJira.Models
{
    public class GamaJiraWebHookModel
    {
        public GamaJiraWebHookModel(string hookJson, GJIssueType issueType = null)
        {
            var jobj = JObject.Parse(hookJson);
            IssueID = jobj["id"].Value<int>();

            var assignee = jobj["fields"]["assignee"];
            if(assignee != null)
            {
                AccountId = assignee["accountId"].Value<string>();
                EmailAddress = assignee["emailAddress"].Value<string>();
                DisplayName = assignee["displayName"].Value<string>();
            }

            if (issueType != null)
            {
                var fieldToken = jobj["fields"];
                CustomFields = new Dictionary<string, JToken>();
                foreach (var field in issueType.CustomFieldIDs)
                {
                    var value = fieldToken[field.Value];
                    if (value != null) 
                        CustomFields.Add(field.Key,value);
                }
            }
        }

        public int IssueID { get; set; }
        public string AccountId { get; set; }
        public string EmailAddress { get; set; }
        public string DisplayName { get; set; }
        public Dictionary<string, JToken> CustomFields { get; set; }
    }
}
