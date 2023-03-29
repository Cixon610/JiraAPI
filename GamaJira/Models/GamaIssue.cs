using Atlassian.Jira;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GamaJira.Models
{
    public class GamaIssue
    {
        public GamaIssue(Issue issue)
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
        /// <summary> 
        /// Jira Issue單號
        /// </summary> 
        public ComparableString Key { get; set; }

        /// <summary> 
        ///摘要 
        /// </summary> 
        [Required]
        public string Summary { get; set; }

        /// <summary> 
        ///描述 
        /// </summary> 
        [Required]
        public string Description { get; set; }

        /// <summary> 
        ///負責人 
        /// </summary> 
        public string Assignee { get; set; }

        /// <summary> 
        ///專案 
        /// </summary> 
        public string Project { get; set; }

        /// <summary> 
        ///回報人 
        /// </summary> 
        public string Reporter { get; set; }

        /// <summary> 
        ///議題狀態 
        /// </summary> 
        public IssueStatus Status { get; set; }

        /// <summary> 
        ///議題類型 
        /// </summary> 
        public IssueType Type { get; set; }

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
    }
    
}
