using Atlassian.Jira;
using GamaJira.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GamaJira.Models
{
    public class GamaIssueRequest : GamaIssue
    {
        /// <summary> 
        /// CreateIssue時使用的附件路徑
        /// </summary> 
        public string[] AttachmentsPath { get; set; }

        /// <summary> 
        ///標籤 
        /// </summary> 
        public string[] Labels { get; set; }

        /// <summary>
        /// 優先權
        /// </summary>
        public JiraIssuePriority Priority { get; set; }

        /// <summary> 
        ///自訂欄位值 
        /// </summary> 
        public Dictionary<string,string> CustomFieldIDs { get; set; }
    }
}
