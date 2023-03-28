using Atlassian.Jira;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamaJira.Models
{
    public class GamaIssueResponse : GamaIssue
    {
        public GamaIssueResponse(Issue issue)
        {
            MapIssue(issue);
        }

        /// <summary> 
        /// 附加欄位 
        /// </summary> 
        public IssueFields AdditionalFields { get; set; }

        /// <summary> 
        ///議題安全層級 
        /// </summary> 
        public IssueSecurityLevel SecurityLevel { get; set; }

        /// <summary> 
        ///票數 
        /// </summary> 
        public long? Votes { get; set; }

        /// <summary> 
        ///已投票 
        /// </summary> 
        public Boolean HasUserVoted { get; set; }

        /// <summary> 
        ///建立時間 
        /// </summary> 
        public DateTime? Created { get; set; }

        /// <summary> 
        ///到期日 
        /// </summary> 
        public DateTime? DueDate { get; set; }

        /// <summary> 
        ///更新時間 
        /// </summary> 
        public DateTime? Updated { get; set; }

        /// <summary> 
        ///解決結果時間 
        /// </summary> 
        public DateTime? ResolutionDate { get; set; }

        /// <summary> 
        ///標籤 
        /// </summary> 
        public IssueLabelCollection Labels { get; set; }

        /// <summary> 
        ///自訂欄位值 
        /// </summary> 
        public CustomFieldValueCollection CustomFields { get; set; }

        /// <summary> 
        ///優先權 
        /// </summary> 
        public IssuePriority Priority { get; set; }

        public void MapIssue(Issue issue)
        {
            this.AdditionalFields = issue.AdditionalFields;
            this.Assignee = issue.Assignee;
            this.Created = issue.Created;
            this.CustomFields = issue.CustomFields;
            this.Description = issue.Description;
            this.DueDate = issue.DueDate;
            this.HasUserVoted = issue.HasUserVoted;
            this.Key = issue.Key;
            this.Labels = issue.Labels;
            this.Priority = issue.Priority;
            this.Project = issue.Project;
            this.Reporter = issue.Reporter;
            this.ResolutionDate = issue.ResolutionDate;
            this.SecurityLevel = issue.SecurityLevel;
            this.Status = issue.Status;
            this.Summary = issue.Summary;
            this.Type = issue.Type;
            this.Updated = issue.Updated;
            this.Votes = issue.Votes;
        }

    }
}
