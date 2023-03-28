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
        public static Issue AssignFromGamaIssue(this Issue issue, GamaIssueRequest request)
        {
            issue.Assignee = request.Assignee;
            issue.Description = request.Description;
            issue.Priority = request.Priority.ToString();
            issue.Reporter = request.Reporter;
            issue.Summary = request.Summary;
            issue.Type = request.Type;

            if(request.AttachmentsPath?.Length > 0)
                issue.AddAttachment(request.AttachmentsPath);

            if(request.CustomFields?.Count > 0)
            {
                foreach(var field in request.CustomFields)
                {
                    issue.CustomFields.Add(field.Key, field.Value);
                }
            }

            if(request.Labels?.Length > 0)
                issue.Labels.Add(request.Labels);

            return issue;
        }
    }
}
