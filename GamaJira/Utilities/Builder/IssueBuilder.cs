using Atlassian.Jira;
using GamaJira.Constant;
using GamaJira.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamaJira.Utilities.Builder
{
    public class IssueBuilder
    {
        private readonly Issue _issue;
        private readonly GJIssueType _issueType;

        public IssueBuilder(Jira jira, string projectTag, GJIssueType issueType)
        {
            _issue = jira.CreateIssue(projectTag);
            _issueType = issueType;
        }

        public IssueBuilder SetSummary(string summary)
        {
            _issue.Summary = summary;
            return this;
        }

        public IssueBuilder SetDescription(string description)
        {
            _issue.Description = description;
            return this;
        }

        public IssueBuilder SetAssignee(string assignee)
        {
            _issue.Assignee = assignee;
            return this;
        }

        public IssueBuilder SetReporter(string reporter)
        {
            _issue.Reporter = reporter;
            return this;
        }
        /// <summary>
        /// Input IssueName or ID
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IssueBuilder SetType(string type)
        {
            _issue.Type = type.ToString();
            return this;
        }

        public IssueBuilder SetAttachmentsPath(string[] attachmentsPath)
        {
            if (attachmentsPath?.Length > 0)
                _issue.AddAttachment(attachmentsPath);
            return this;
        }

        public IssueBuilder SetLabels(string[] labels)
        {
            if (labels?.Length > 0)
                _issue.Labels.Add(labels);
            return this;
        }

        public IssueBuilder SetPriority(JiraIssuePriority priority)
        {
            _issue.Priority = priority.ToString();
            return this;
        }

        public IssueBuilder SetCustomFields(Dictionary<string, string> customFields)
        {
            if (customFields?.Count > 0)
            {
                //對應customfieldID
                var fieldIDDic = _issueType.CustomFields;
                foreach (var field in customFields)
                {
                    if (fieldIDDic.ContainsKey(field.Key))
                    {
                        var jiraCustomFieldID = fieldIDDic[field.Key];
                        _issue.CustomFields.Add(jiraCustomFieldID, field.Value);
                    }
                }
            }
            return this;
        }

        public Issue Build()
        {
            _issue.SaveChanges();
            return _issue;
        }
    }
}