using Atlassian.Jira;
using GamaJira.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace GamaJira.Extension
{
    public static class IssueExtension
    {
        public static Issue MapFromGamaIssue(this Issue issue, GamaIssueRequest request, GJIssueType issueType)
        {
            issue.Assignee = request.Assignee;
            issue.Description = request.Description;
            issue.Priority = request.Priority.ToString();
            issue.Reporter = request.Reporter;
            issue.Summary = request.Summary;
            issue.Type = request.Type;

            if(request.AttachmentsPath?.Length > 0)
                issue.AddAttachment(request.AttachmentsPath);

            if(request.CustomFieldIDs?.Count > 0)
            {
                //對應customfieldID
                var fieldIDDic = issueType.CustomFields;
                foreach (var field in request.CustomFieldIDs)
                {
                    if (fieldIDDic.ContainsKey(field.Key))
                    {
                        var jiraCustomFieldID = fieldIDDic[field.Key];
                        issue.CustomFields.Add(jiraCustomFieldID, field.Value);
                    }
                }
            }

            if(request.Labels?.Length > 0)
                issue.Labels.Add(request.Labels);

            return issue;
        }
    }
}
