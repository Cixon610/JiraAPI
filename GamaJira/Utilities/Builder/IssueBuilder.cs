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
        private IEnumerable<string> attachmentPathList { get; set; }

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
            if(!string.IsNullOrEmpty(assignee))
                _issue.Assignee = assignee;

            return this;
        }

        public IssueBuilder SetReporter(string reporter)
        {
            if (!string.IsNullOrEmpty(reporter))
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

        public IssueBuilder SetAttachmentsPath(IEnumerable<string> attachmentsPath)
        {

            if (attachmentsPath?.Count() > 0)
                attachmentPathList = attachmentsPath;
            return this;
        }

        public IssueBuilder SetLabels(IEnumerable<string> labels)
        {
            if (labels?.Count() > 0)
                _issue.Labels.Add(labels.ToArray());
            return this;
        }

        public IssueBuilder SetPriority(JiraIssuePriority priority)
        {
            _issue.Priority = priority.ToString();
            return this;
        }

        /// <summary>
        /// 截止日
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public IssueBuilder SetDueDate(DateTime? datetime)
        {
            _issue.DueDate = datetime;
            return this;
        }

        /// <summary>
        /// 客製化欄位
        /// </summary>
        /// <param name="customFields"></param>
        /// <returns></returns>
        public IssueBuilder SetCustomFields(Dictionary<string, string> customFields)
        {
            if (customFields?.Count > 0)
            {
                //對應customfieldID
                var fieldIDDic = _issueType.CustomFieldIDs;
                foreach (var field in customFields)
                {
                    if (fieldIDDic.ContainsKey(field.Key))
                    {
                        var jiraCustomFieldID = fieldIDDic[field.Key];
                        _issue.CustomFields.AddById(jiraCustomFieldID, field.Value);
                    }
                }
            }
            return this;
        }

        public Issue Build()
        {
            //建立Issue，並取得單號
            _issue.SaveChanges();

            //取得單號後才可上傳附件
            if(attachmentPathList.Count() > 0)
                _issue.AddAttachment(attachmentPathList.ToArray());
            _issue.SaveChanges();

            return _issue;
        }
    }
}