using Atlassian.Jira;
using GamaJira.Constant;
using GamaJira.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamaJira.Utilities.Builder
{
    public class GamaIssueRequestBuilder
    {
        private readonly GamaIssueRequest _issueRequest;

        public GamaIssueRequestBuilder()
        {
            _issueRequest = new GamaIssueRequest();
        }

        public GamaIssueRequestBuilder SetKey(ComparableString key)
        {
            _issueRequest.Key = key;
            return this;
        }

        public GamaIssueRequestBuilder SetSummary(string summary)
        {
            _issueRequest.Summary = summary;
            return this;
        }

        public GamaIssueRequestBuilder SetDescription(string description)
        {
            _issueRequest.Description = description;
            return this;
        }

        public GamaIssueRequestBuilder SetAssignee(string assignee)
        {
            _issueRequest.Assignee = assignee;
            return this;
        }

        public GamaIssueRequestBuilder SetProject(string project)
        {
            _issueRequest.Project = project;
            return this;
        }

        public GamaIssueRequestBuilder SetReporter(string reporter)
        {
            _issueRequest.Reporter = reporter;
            return this;
        }

        public GamaIssueRequestBuilder SetStatus(IssueStatus status)
        {
            _issueRequest.Status = status;
            return this;
        }

        public GamaIssueRequestBuilder SetType(IssueType type)
        {
            _issueRequest.Type = type;
            return this;
        }

        public GamaIssueRequestBuilder SetAttachmentsPath(string[] attachmentsPath)
        {
            _issueRequest.AttachmentsPath = attachmentsPath;
            return this;
        }

        public GamaIssueRequestBuilder SetLabels(string[] labels)
        {
            _issueRequest.Labels = labels;
            return this;
        }

        public GamaIssueRequestBuilder SetPriority(JiraIssuePriority priority)
        {
            _issueRequest.Priority = priority;
            return this;
        }

        public GamaIssueRequestBuilder SetCustomFields(Dictionary<string, string> customFields)
        {
            _issueRequest.CustomFieldIDs = customFields;
            return this;
        }

        public GamaIssueRequest Build() => _issueRequest;
    }

}
